using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Lab_interfejssy
{
    public class Pracownik : IEquatable<Pracownik>, IComparable<Pracownik>
    {
        private string nazwisko;
        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko = value.Trim().ToUpper();
        }

        private DateTime dataZatrudnienia;

        public DateTime DataZatrudnienia
        {
            get => dataZatrudnienia;
            set => dataZatrudnienia = value > DateTime.Now
                                        ? throw new ArgumentException("zła data")       //użycie warunkowego operatora wyboru zamiast if
                                        : value;
        }

        private decimal wynagrodzenie;

        public decimal Wynagrodzenie
        {
            get => wynagrodzenie;                                    // jeśli wynagrdzenie jest mniejsze od 0 to wynagrodzenie = 0,                                                  
            set => wynagrodzenie = value < 0 ? 0 : value;            // przeciwnym wypadku wynagrodzenie = value */  

        }

        public override string ToString() => $"({Nazwisko}, {DataZatrudnienia} ({CzasZatrudnienia()}), {Wynagrodzenie} PLN)";

        public bool Equals(Pracownik? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;           //sprawdzam czy obiekt this przekazany jako other są tego samego typu i referencji

            return Nazwisko == other.Nazwisko 
                && DataZatrudnienia == other.DataZatrudnienia 
                && Wynagrodzenie == other.Wynagrodzenie;
        }

        public override bool Equals(object? obj)                     //Equals musi zwrócić prawdę albo fałsz, nie może zgłosić ona wyjątku
        {
            if (obj is null) return false;
            if (obj is Pracownik p)
            {
                //var p = (Pracownik)obj;                           //dzięki zmiennej p wyżej, nie musimy robić rzutowania Pracownika 
                return this.Equals(p);
            }

            return false;



            //if (obj is Pracownik)
            //{
            //    var p = (Pracownik)obj;
            //    return this.Equals(p);                             //w ten sposób pisaliśmy do c# 8.0
            //}

            // return false;
        }

        public override int GetHashCode()
        {                                                                                   //jeżeli wkładamy pracownika do jakiegoś zbioru 
            return HashCode.Combine(nazwisko, dataZatrudnienia, wynagrodzenie);             //musimy zadbać, aby HashCode był unikalny dla każdego użytkownika 
                                                                                            //każdemu pracownikowi przypisujemy unikalny HashCode, inną liczbę
        }

        public static bool operator ==(Pracownik? left, Pracownik? right) => Equals(left, right); //operator porównania
        public static bool operator !=(Pracownik? left, Pracownik? right) => !Equals(left, right); //operator porównania

        public Pracownik(string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;                                    //przypisanie Naziwsko wywołuje set do nazwisko w 9 linii kodu
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }

        public Pracownik() : this("Anonim", DateTime.Now, 0) { }    //konstruktor domyślny - łańcuchowanie konstruktorów

        public int CzasZatrudnienia() => (DateTime.Now - DataZatrudnienia).Days / 30; //metoda zwracająca ilość dni od zatrudnienia


        public int CompareTo(Pracownik other)
        {
            if (other is null) return 1; // w C#: null jest najmniejszą wartością (`this > null`)
            if (this.Equals(other)) return 0; //zgodność z Equals (`this == other`)

            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);

            // ponieważ nazwiska równe, porządkujemy wg daty
            if (!this.DataZatrudnienia.Equals(other.DataZatrudnienia)) // != zamiast !Equals
                return this.DataZatrudnienia.CompareTo(other.DataZatrudnienia);

            // ponieważ nazwiska równe i daty równe, porządkujemy wg wynagrodzenia
            return this.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
        }


    }
}
