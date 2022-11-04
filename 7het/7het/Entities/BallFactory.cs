using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7het.Entities
{
    public class BallFactory
    {
        //Az osztálynak legyen egy publikus függvénye CreateNew néven Ball visszatérési értékkel
        public Ball CreateNew()
        {
            return new Ball();
        }
    }
}
