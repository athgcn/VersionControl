using _7het.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7het.Entities
{
    //A BallFactory osztály ősei közé sorold fel az IToyFactory interfészt.
    //Írd át a CreateNew függvény visszatérési értékét Toy típusra
    public class BallFactory: IToyFactory
    {
        //Az osztálynak legyen egy publikus függvénye CreateNew néven Ball visszatérési értékkel
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
