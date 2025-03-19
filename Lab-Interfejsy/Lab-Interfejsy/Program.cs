using Lab_interfejssy;
using Lab_Interfejsy;

var p = new Pracownik();
Console.WriteLine(p);

var q = new Pracownik("Molenda", new DateTime(2020, 1, 1), 10000);
Console.WriteLine(q);

var r = new Pracownik("     Molenda", DateTime.Parse("2020-01-01"), 10000);
Console.WriteLine(r);

Console.WriteLine(q == r);

//var r1 = new Pracownik("Kowalski", DateTime.Parse("2026-03-01"), 5000);           //wyjście błędne - zła data na poczet naszych testów
//Console.WriteLine(r1);

var lista = new List<Pracownik>();
lista.Add(new Pracownik("Molenda A", new DateTime(2010, 10, 12), 9500));
lista.Add(new Pracownik("Molenda C", new DateTime(2011, 10, 12), 8500));
lista.Add(new Pracownik("Molenda D", new DateTime(2013, 10, 12), 1500));
lista.Add(new Pracownik("Molenda A", new DateTime(2011, 10, 21), 7500));
lista.Add(new Pracownik("Molenda E", new DateTime(2014, 10, 12), 7500));

Console.WriteLine();
Console.WriteLine(lista); //wypisuje typ a nie wartość listy
Console.WriteLine();

Console.WriteLine("--Wariant 1--");
foreach (var pracownik in lista)
{
    Console.WriteLine(pracownik);
}
Console.WriteLine();

Console.WriteLine("-- Wariant 2 --");
lista.ForEach((p) => { Console.Write(p + ","); });
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("-- Wariant 3 --");
Console.WriteLine(string.Join('\n', lista));
Console.WriteLine();

lista.Sort();

Console.WriteLine("Po posortowaniu:");
foreach (var pracownik in lista)
    Console.WriteLine(pracownik);

var lista1 = new List<Pracownik>();
lista1.Add(new Pracownik("CCC", new DateTime(2010, 10, 02), 1050));
lista1.Add(new Pracownik("AAA", new DateTime(2010, 10, 01), 100));
lista1.Add(new Pracownik("DDD", new DateTime(2010, 10, 03), 2000));
lista1.Add(new Pracownik("AAA", new DateTime(2011, 10, 01), 1000));
lista1.Add(new Pracownik("BBB", new DateTime(2010, 10, 01), 1050));

Console.WriteLine(lista1); //wypisze typ, a nie zawartość listy
foreach (var pracownik in lista1)
    System.Console.WriteLine(pracownik);

Console.WriteLine("--- Zewnętrzny porządek - obiekt typu IComparer" + Environment.NewLine
                    + "najpierw według czasu zatrudnienia (w miesiącach), " + Environment.NewLine
                    + "a później według wynagrodzenia - wszystko rosnąco");

lista.Sort(new WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer());
foreach (var pracownik in lista1)
    System.Console.WriteLine(pracownik);

Console.WriteLine("--- Zewnętrzny porządek - delegat typu Comparison" + Environment.NewLine
                       + "kolejno: malejąco według wynagrodzenia, " + Environment.NewLine
                       + "później rosnąca według czasu zatrudnienia");
//budujemy warunek wyrażeniem warunkowym ()?:
lista.Sort((p1, p2) => (p1.Wynagrodzenie != p2.Wynagrodzenie) ?
                            (-1) * (p1.Wynagrodzenie.CompareTo(p2.Wynagrodzenie)) :
                            p1.CzasZatrudnienia().CompareTo(p2.CzasZatrudnienia())
            );
foreach (var pracownik in lista)
    System.Console.WriteLine(pracownik);