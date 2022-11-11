using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaR.Entities;

namespace VaR
{
    public partial class Form1 : Form
    {
        //A Form1 osztály szintjén példányosítsd az ORM objektumot!
        PortfolioEntities context = new PortfolioEntities();

        //A Form1 osztály szintjén hozz létre egy Tick típusú elemkből álló listára mutató referenciát. (Nem kell inicializálni new-val.)
        List<Tick> Ticks;

        //Hozz létre egy PortfolioItem típusú elemekből álló Portfolio nevű listát a Form1 szintjén
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();

            //A konstruktorban másold az adattábát a memóriába, majd töltsd fel vele a DataGridView-t!
            dataGridView1.DataSource = Ticks;
            CreatePortfolio();
        }

        //A függvényben vedd fel az alábbi három részvényt a Portfolio listába a kódminta szerint, majd a portfóliódat jelenítsd megy DataGridView-ban.
        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });
            dataGridView2.DataSource = Portfolio;
        }
    }
}
