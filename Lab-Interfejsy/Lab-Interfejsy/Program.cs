﻿using Lab_interfejssy;
    
var p = new Pracownik();
Console.WriteLine(p);

var q = new Pracownik("Molenda", new DateTime(2020, 1, 1), 10000);
Console.WriteLine(q);

var r = new Pracownik("     Molenda", DateTime.Parse("2020-01-01"), 10000);
Console.WriteLine(r);

Console.WriteLine(q == r);

//var r1 = new Pracownik("Kowalski", DateTime.Parse("2026-03-01"), 5000);           //wyjście błędne - zła data na poczet naszych testów
//Console.WriteLine(r1);

