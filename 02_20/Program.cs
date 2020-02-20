using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_20
{
    struct Cica
    {
        public string Nev { get; set; }
        public int Kor { get; set; }
        public float Suly { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var cicak = new Cica[]
            {
                new Cica() { Nev = "Lukrécica", Kor = 14, Suly = 90.5F },
                new Cica() { Nev = "Botond", Kor = 4, Suly = 34F },
                new Cica() { Nev = "Lajcica", Kor = 6, Suly = 32.3F },
                new Cica() { Nev = "Pöttyös", Kor = 35, Suly = 30.8F },
                new Cica() { Nev = "Picica", Kor = 3, Suly = 10F }
            };

            var szamok = new int[] { 2, 3, 5, 6, 7, 10 };
            Console.WriteLine(szamok.Sum());
            Console.WriteLine(szamok.Average());
            Console.WriteLine(szamok.Min());
            Console.WriteLine(szamok.Max());
            Console.WriteLine(szamok.Count());

            Console.WriteLine();
            int coe = cicak.Sum(x => x.Kor);
            Console.WriteLine(coe);

            int coe2 = (from x in cicak select x.Kor).Sum();
            Console.WriteLine(coe2);


            Console.WriteLine();
            int lfck = cicak.Min(x => x.Kor);
            int lfck2 = (from x in cicak select x.Kor).Min();
            //
            //Cica[] lfcn = cicak.Where(c => c.Kor == cicak.Min(x => x.Kor)).ToArray();
            //Cica lfcn = cicak.Where(c => c.Kor == cicak.Min(x => x.Kor)).First();

            string lfcn = cicak
                .Where(y => y.Kor == cicak.Min(x => x.Kor))
                .Select(c => c.Nev)
                .First();

            string lfcn2 =
                (from c in cicak
                 where c.Kor == cicak.Min(x => x.Kor)
                 select c.Nev).First();

            Console.WriteLine(Convert.ToString(lfck), Convert.ToString(lfck2));
            //SELECT nev FROM cicak WHERE kor = min(kor)
            Console.WriteLine();


            //int coe = 0;
            //foreach (var c in cicak) coe += c.Kor;
            //Console.WriteLine(coe);

            //SQL
            //SELECT SUM(Kor) FROM cicak


            //120-kilós cica adatai
            Cica[] rendezettCicak =
                cicak.OrderByDescending(c => c.Kor)
                .ToArray();

            var szazHusz = cicak
                .Where(c => c.Suly == 120)
                .Select(c => c.Nev)
                .FirstOrDefault();

            if (szazHusz is null) Console.WriteLine("Nincs 120 kilós macska");
            else Console.WriteLine($"Van 120 kilós macska, a neve: {szazHusz}");

            Console.WriteLine();
            Console.WriteLine("5 évnél fiatalabb macskák:");
            cicak
                .Where(c => c.Kor > 5)
                .Select(c => c.Nev)
                .ToList()
                .ForEach(x => Console.WriteLine(x));



            Console.ReadKey();

        }
    }
}
