using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7het.Abstractions
{
    /*Hozz létre egy új interfészt az Abstractions mappába IToyFactory néven.
     * (A legegyszerűbb, ha a Class-t hozol létre, és egyszerűen utólag átírod a class szót interface-re.)*/

    public interface IToyFactory
    {
        /* Ebben az interfészben adj meg egy olyan függvényt, aminek a neve CreateNew,
         * és a visszatérési értéke Toy típusú. Az interfészekben megadott elemeknek mindig publikusnak kell lenniük,
         * ezért itt ezt az előtagot nem kell leírni, és az absztrakt függvényekhez hasonlóan a kapcsos zárójelek helyett
         * itt is csak egy pontosvessző szerepel.*/

        Toy CreateNew();
    }
}
