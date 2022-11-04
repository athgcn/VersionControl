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
    public partial class Form1 : Form
    {
        //Hozz létre a Form1 osztály szintjén egy Ball típusú elemekből álló listát _balls néven.
        private List<Ball> _balls = new List<Ball>();

        //Hozz létre egy BallFactory típusú kifejtett propertyt is Factory néven
        private BallFactory _factory;

        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();

            //A konstruktorban töltsd fel a Factory változót egy BallFactory példánnyal
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            /*Factory CreateNew metódusát felhasználva hozz létre egy Ball példányt. Add hozzá a _balls listához, 
            * és a mainPanel vezérlőihez. A Left tulajdonságát pedig állítsd a szélessége negatív értékére. 
            * (Ezzel a képernyőn kívül jön majd létre a labda és a futószalagon szép 
            * folyamatosan úszik majd be.)*/

            var ball = Factory.CreateNew();
            _balls.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            /*foreach segítségével menj végig a _balls listán és hívd meg mindegyik elemének a MoveBall metódusát. 
             * Ezen felül egy a cikluson kívüli segédváltozóval tárold le a leginkább jobbra levő Ball példány pozícióját.*/

            var maxPosition = 0;
            foreach (var ball in _balls)
            {
                ball.MoveBall();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            //A ciklus után, ha a legnagyobb pozíció eléri az 1000-et akkor tárold le egy változóba a _balls lista
            //első elemét és töröld ki a listából és a Form vezérlőiből is.
            if (maxPosition > 1000)
            {
                var oldestBall = _balls[0];
                mainPanel.Controls.Remove(oldestBall);
                _balls.Remove(oldestBall);
            }


        }
    }
}
