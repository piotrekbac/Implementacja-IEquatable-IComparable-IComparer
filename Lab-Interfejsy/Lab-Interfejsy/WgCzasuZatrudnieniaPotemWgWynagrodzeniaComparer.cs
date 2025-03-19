using Lab_interfejssy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Interfejsy
{
    public class WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer : IComparer<Pracownik>
    {
        public int Compare(Pracownik x, Pracownik y)
        {
            if (x is null && y is null) return 0;
            if (x is null && !(y is null)) return -1;
            if (!(x is null) && y is null) return +1;

            //x oraz y nie są null
            if (x.CzasZatrudnienia() != y.CzasZatrudnienia())
                return (x.CzasZatrudnienia()).CompareTo(y.CzasZatrudnienia());

            //daty są takie same
            return x.Wynagrodzenie.CompareTo(y.Wynagrodzenie);
        }
    }
}