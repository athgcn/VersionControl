using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7het.Abstractions
{
    public abstract class Toy:Label
    {
        //Hozz létre egy új absztrakt osztályt Toy néven egy Abstractions mappába, és másold át bele a Ball osztály teljes kódját.
        public Toy()
        {
            //A konstruktorban állítsd be az AutoSize tulajdonságot hamisra, és a labda méretét 50x50 pixelre.
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Toy_paint;
        }

        //rendelj eseménykezelőt a Paint eseményéhez.
        private void Toy_paint(object sender, PaintEventArgs e)
        {
            //Hívd meg a Paint eseménykezelőjéből a DrawImage függvényt
            DrawImage(e.Graphics);
        }

        //Hozz létre egy új függvényt DrawImage néven és Graphics típusú bemeneti paraméterrel
        protected abstract void DrawImage(Graphics g);
       /* {
            //metódusban rajzolj ki egy a vezérlőbe illeszkedő, kitöltött kék kört a Graphics osztály segítségével.
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }*/

        //Hozz létre egy publikus függvényt MoveBall néven. A függvényben növeld meg eggyel az aktuális Ball Left tulajdonságát.
        public virtual void MoveToy()
        {
            Left += 1;
        }
    }
}
