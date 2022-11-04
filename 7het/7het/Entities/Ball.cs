using _7het.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7het.Entities
{
    //Label helyett a Toy osztályból származzon. 
    public class Toy : Abstractions.Toy
    {
        public SolidBrush BallColor { get; private set; }
        /*
         public Ball()
         {
             //A konstruktorban állítsd be az AutoSize tulajdonságot hamisra, és a labda méretét 50x50 pixelre.
             AutoSize = false;
             Width = 50;
             Height = Width;
             Paint += Ball_Paint;
         }

         //rendelj eseménykezelőt a Paint eseményéhez.
         private void Ball_Paint(object sender, PaintEventArgs e)
         {
             //Hívd meg a Paint eseménykezelőjéből a DrawImage függvényt
             DrawImage(e.Graphics);
         }

         //Hozz létre egy új függvényt DrawImage néven és Graphics típusú bemeneti paraméterrel
         */

        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
        }

        protected override void DrawImage(Graphics g)
        {
            //metódusban rajzolj ki egy a vezérlőbe illeszkedő, kitöltött kék kört a Graphics osztály segítségével.
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

        /*
        //Hozz létre egy publikus függvényt MoveBall néven. A függvényben növeld meg eggyel az aktuális Ball Left tulajdonságát.
        public void MoveBall()
        {
            Left += 1;
        }
        */

        public 
    } 
}
