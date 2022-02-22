using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // data class -> record, incepand cu C# 9.0
            // sintaxa cu data class a fost eliminata

            Developer ana = new Developer { FirstName = "Ana", LastName = "Marinescu", FavoriteLanguage = "C#" };

            Developer bogdan = new Developer("Bogdan", "Pop", "PHP");

            Developer mihai = new Developer { FirstName = "Mihai", LastName = "Apetrei", FavoriteLanguage = "C#" };

            TeamLeader leader = new TeamLeader
            {
                FirstName = mihai.FirstName,
                LastName = mihai.LastName,
                FavoriteLanguage = mihai.FavoriteLanguage,
                Team = "BLUE",
                TeamSize = 3
            };

            var newLeader = leader with { FirstName = "Mihail", Team = "BLUE SKY", TeamSize = 5 };

            TeamLeader leader2 = new TeamLeader(newLeader.FirstName, newLeader.LastName, newLeader.FavoriteLanguage, newLeader.Team, newLeader.TeamSize);

            Console.WriteLine($"{leader.FirstName} {leader.LastName} leads: {leader.Team} ({leader.TeamSize})");
            Console.WriteLine($"{newLeader.FirstName} {newLeader.LastName} leads: {newLeader.Team} ({newLeader.TeamSize})");
            Console.WriteLine($"{leader2.FirstName} {leader2.LastName} leads: {leader2.Team} ({leader2.TeamSize})");

            Person p = new("Alex", "Jones", "12121221");
            Teacher t = new("Anna", "Smith", "3232323232", "Philosophy");

            Console.WriteLine(p);
            Console.WriteLine(t);

            //Immutable stack
            ImmutableStack<Developer> devs1 = ImmutableStack.Create<Developer>(ana);
            ImmutableStack<Developer> devs2 = devs1.Push(bogdan);

            ////Parcurgere cu foreach:
            foreach (var dev in devs2)
            {
                Console.WriteLine($"Dev: {dev.FirstName} {dev.LastName}");
            }

            //alte moduri de parcurgere a unui ImmutableStack: (Enumerator)
            var enu = devs2.GetEnumerator();

            if (enu.MoveNext())
            {
                Console.WriteLine("Dev: " + enu.Current);
            }
            if (enu.MoveNext())
            {
                Console.WriteLine("Dev: " + enu.Current);
            }
            if (enu.MoveNext())
            {
                Console.WriteLine("________");
            }

            //sau altfel scris:
            while (enu.MoveNext())
            {
                Console.WriteLine("Current: " + enu.Current);
            }

            //Q: iterarea cu TPL: este eficienta dpdv al timpului, dar strica ordinea => in ce cazuri este recomandat sa o folosim ?
            //A: Cand fiecare dintre task-urile de efectuat nu depinde de un altul 
            //Ex: chores din casa: gatit o supa, dat cu aspiratorul, udat plantele, dus gunoiul. 
            //In cazul ideal, am putea asigna 4 persoane, fiecare pt o treaba din aceste 4. 
            //Daca efectuarea acestor sarcini nu incurca/afecteaza efectuarea celorlalte
            //este caz ideal de a paraleliza
            //Sau alt exemplu mai tehnic pt operatiune ideal de "paralelizat": inserarea unei cantitati mari de obiecte intr-o BD (2000/5000 etc)

            //Q: -  Entity Framework: functionalitatea de Change Tracking este acelasi lucru cu conceptul de migratii?
            //A: - Sunt lucruri diferite. ChangeTracking e modul intern al EF in care tine evidenta starii entitatilor.
            // Migratiile tin de structura obiectelor cu care lucram, despre ce proprietati au obiectele, despre cum le modificam 
            // De exemplu: de-a lungul timpului, entitatile noastre pot avea nevoie de modificari in structura (adaugarea unui camp nou, 
            // redenumirea unui camp existent, stergerea unui camp, adaugarea unui nou tip de entitate, etc). Migratiile intervin aici.
            //Putem prelua exemplul de la: https://github.com/entityframeworktutorial/EF6-Code-First-Demo
            //(proiectul: EF6CodeFirstDemo)

            //Dependency injection:
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHrService, HRService>()
                .AddSingleton<IAccountingService, AccountingService>()
                .BuildServiceProvider();

            var hr = serviceProvider.GetService<IHrService>();
            var accounting = serviceProvider.GetService<IAccountingService>();

            Dashboard today = new Dashboard(accounting, hr);

            today.Show();
        }
    }

    //Immutable types: mostenire
    public record Developer 
    {
        public Developer(string firstName, string lastName, string favoriteLanguage)
        {
            FirstName = firstName;
            LastName = lastName;
            FavoriteLanguage = favoriteLanguage;
        }
        public Developer()
        {

        }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FavoriteLanguage { get; init; }
    }

    public record TeamLeader : Developer 
    {
        public TeamLeader()
        {

        }
        public TeamLeader(string firstName, string lastName, string favoriteLanguage, string team, int teamSize) 
            : base(firstName, lastName, favoriteLanguage)
        {
            FirstName = firstName;
            LastName = lastName;
            FavoriteLanguage = favoriteLanguage;
            Team = team;
            TeamSize = teamSize;
        }
        public string Team { get; init; }
        public int TeamSize { get; init; }
    }


    public record Person(string firstName, string lastName, string phoneNumber);

    public record Teacher(string firstName, string lastName, string phoneNumber, string domain) : Person(firstName, lastName, phoneNumber);
}
