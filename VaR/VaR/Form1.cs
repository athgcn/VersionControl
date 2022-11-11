using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<PortfolioItem> Nyereségek = new List<PortfolioItem>();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();

            //A konstruktorban másold az adattábát a memóriába, majd töltsd fel vele a DataGridView-t!
            dataGridView1.DataSource = Ticks;
            CreatePortfolio();

            List<decimal> Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());

        }

        //A függvényben vedd fel az alábbi három részvényt a Portfolio listába a kódminta szerint, majd a portfóliódat jelenítsd megy DataGridView-ban.
        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });
            dataGridView2.DataSource = Portfolio;
        }

        //Hozd létre az alábbi függvényt a portfólió érték kiszámításához.
        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        //Egy gombra kattintva jöjjön fel egy mentés ablak, ahol a felhasználó megadhatja, hová szeretné elmenteni a nyereség listát
        private void button1_Click(object sender, EventArgs e)
        {
            //A fájl első sorában szerepeljen a fejléc, mely az "Időszak" és a "Nyereség" szavakat tartalmazza
            //A sorokban először a lista aktuális elemszáma, majd a megfelelő elem értéke jelenjen meg
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog () !=DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                sw.Write("Időszak");
                sw.Write(";");
                sw.Write("Nyereség");
                int counter = 0;

                foreach(var s in Nyereségek)
                {
                    counter++;
                    sw.WriteLine();
                    sw.Write(counter);
                    sw.Write(";");
                    sw.Write(s.ToString());
                }
            }   
         
        }   

    }
}
