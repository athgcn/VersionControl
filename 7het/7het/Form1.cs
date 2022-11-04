using _7het.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7het
{
    private Toy _nextToy;

    public partial class Form1 : Form
    {
        //Hozz létre a Form1 osztály szintjén egy Ball típusú elemekből álló listát _balls néven.
        //private List<Ball> _balls = new List<Ball>();
        private List <Toy> _toys = new List<Toy> ();

        //Hozz létre egy BallFactory típusú kifejtett propertyt is Factory néven
        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                   DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();

            //A konstruktorban töltsd fel a Factory változót egy BallFactory példánnyal
            Factory = new IToyFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            /*Factory CreateNew metódusát felhasználva hozz létre egy Ball példányt. Add hozzá a _balls listához, 
            * és a mainPanel vezérlőihez. A Left tulajdonságát pedig állítsd a szélessége negatív értékére. 
            * (Ezzel a képernyőn kívül jön majd létre a labda és a futószalagon szép 
            * folyamatosan úszik majd be.)*/

            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            /*foreach segítségével menj végig a _balls listán és hívd meg mindegyik elemének a MoveBall metódusát. 
             * Ezen felül egy a cikluson kívüli segédváltozóval tárold le a leginkább jobbra levő Ball példány pozícióját.*/

            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = Toy.Left;
            }

            //A ciklus után, ha a legnagyobb pozíció eléri az 1000-et akkor tárold le egy változóba a _balls lista
            //első elemét és töröld ki a listából és a Form vezérlőiből is.
            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }


        }

        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();

        }

        private void btnSelectBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = lblNext.Top + lblNext.Height + 20;
            _nextToy.Left = lblNext.Left;
            Controls.Add(_nextToy);
        }
    }
}
