using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaR
{
    public partial class Form1 : Form
    {
        //A Form1 osztály szintjén példányosítsd az ORM objektumot!
        PortfolioEntities context = new PortfolioEntities();

        //A Form1 osztály szintjén hozz létre egy Tick típusú elemkből álló listára mutató referenciát. (Nem kell inicializálni new-val.)
        List<Tick> Ticks;
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();

            //A konstruktorban másold az adattábát a memóriába, majd töltsd fel vele a DataGridView-t!
            dataGridView1.DataSource = Ticks;
        }
    }
}
