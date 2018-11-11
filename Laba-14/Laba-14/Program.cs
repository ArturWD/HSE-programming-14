using AnimalsLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_14
{
    class Program
    {
        static void FillIn(Dictionary<string, List<Animal>> zoo)
        {
            var animal1 = new Animal("Big Bobby", 300);
            var animal2 = new Animal("Mad Creature", 100);
            var animal3 = new Animal("Destrouer", 30);
            var animal4 = new Animal("Quick as lightning", 3);
            var animal5 = new Animal("Light Elephant", 30000);
            var animal6 = new Animal("I", 60);
            var animal7 = new Animal("Human", 80);
            var animal8 = new Animal("BatPig", 700);
            var animal9 = new Animal("Glove head", 70);
            var animal10 = new Animal("Eleot", 200);
            var animal11 = new Animal("Deer", 300);
            var animal12 = new Animal("Croco", 300);

            var bird1 = new Bird("Red", 22, 7000);
            var bird2 = new Bird("Bomb", 30, 14000);
            var bird3 = new Bird("Yellow", 1, 700);
            var bird4 = new Bird("Egg thrower", 4, 2000);
            var bird5 = new Bird("Able to grow", 7, 6000);
            var bird6 = new Bird("Red Female", 3, 8000);

            zoo.Add("Birds", new List<Animal> { bird1, bird2, bird3, bird4, bird5, bird6 });
            zoo.Add("Random Animals", new List<Animal> {animal1, animal2, animal3, animal4, animal5,
                animal6, animal7, animal8, animal9, animal10, animal11, animal12, bird1, bird2, bird3, bird4});
        }

        // Select Linq
        static void First(Dictionary<string, List<Animal>> zoo)
        {
            // First Query
            Console.WriteLine("Select: Animals with spaces  in their names");
            Console.WriteLine();
            var spacy = (from animals in zoo["Random Animals"]
                         where animals.Name.Contains(" ")
                         orderby animals.Name descending
                         select animals);
            foreach (var item in spacy)
            {
                Console.WriteLine(item);
            }
        }
        // Count Linq
        static void Second(Dictionary<string, List<Animal>> zoo)
        {
            // Second
            Console.WriteLine("Count: The number of animals heavier than 40");
            Console.WriteLine();
            var heavyAnimals = (from animals in zoo["Random Animals"]
                                where animals.Weight > 40
                                select animals).Count<Animal>();
            Console.WriteLine(heavyAnimals);
            Console.WriteLine();
        }
        // Intersection linq
        static void Third(Dictionary<string, List<Animal>> zoo)
        {
            //Third
            Console.WriteLine("Intersection: Birds related to both 'Random Animals' and 'Birds' collections with fight distance fewer than 10000 ");
            Console.WriteLine();
            var birdsFromAnimals = (from animals in zoo["Random Animals"]
                                    select animals).Intersect(from birds in zoo["Birds"]
                                                              where ((Bird)birds).FlightDistance < 10000
                                                              select birds);
            foreach (var item in birdsFromAnimals)
            {
                ((Bird)item).ShowCreature();
            }

            Console.WriteLine();
        }
        // Linq Aggregate
        static void Fourth(Dictionary<string, List<Animal>> zoo)
        {
            //Fourth
            Console.WriteLine("Aggregate : First letters of every name (from birds)");
           
            Func<string, string, string> totalName = delegate (string a, string b) { return a + b; };
            string nameAbr = (from birds in zoo["Birds"]
                              select birds.Name.Substring(0, 1)).Aggregate(totalName);
            Console.WriteLine(nameAbr);
            Console.WriteLine();
        }

        // Extension Aggregate
        static void Fifth(Dictionary<string, List<Animal>> zoo)
        {
            //Fifth
            Console.WriteLine("Lambda: max weight of a bird with spaces in it's name");
            
            Func<Animal, double> weight = delegate (Animal b) { return b.Weight; };
            var maxDistance = zoo["Birds"].Where(b => b.Name.Contains(" ")).Select(weight).Max();
            Console.WriteLine(maxDistance);
            Console.WriteLine();

        }
        // Extension Count
        static void Sixth(Dictionary<string, List<Animal>> zoo)
        {
            Console.WriteLine("Lambda: the amount of birds with spaces in it's name");
            Console.WriteLine();
            Func<Animal, double> weight = delegate (Animal b) { return b.Weight; };
            var maxDistance = zoo["Birds"].Where(b => b.Name.Contains(" ")).Select(weight).Count();
            Console.WriteLine(maxDistance);
        }

        // Extension SelectMany
        static void Seventh(Dictionary<string, List<Animal>> zoo)
        {
            Console.WriteLine("Select many: options for birds accomodation");
            var combinations = (zoo.Keys).SelectMany(b => zoo["Birds"], (s, b) => new { Section = s, Name = b });
            foreach (var item in combinations)
            {
                Console.WriteLine(item.Section+"  "+item.Name);
            }
            Console.WriteLine();
        }

        // Extension Except 
        static void Eighth(Dictionary<string, List<Animal>> zoo)
        {
            Console.WriteLine("Except: Birds unique for birds section");
            var unique = zoo["Birds"].Except(zoo["Random Animals"].Where(a => a is Bird)).Select(a => new { Name = a.Name});
            foreach (var item in unique)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
        }
        // Custom Extension
        static void Nineth(Dictionary<string, List<Animal>> zoo)
        {
            Console.WriteLine("Birds from animals section");
            var birds = zoo["Random Animals"].GetBirds();
            foreach (var item in birds)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
        // One more for Linq
        static void Tentn(Dictionary<string, List<Animal>> zoo)
        {
            Console.WriteLine("Subquery and projection: name and flight distance of birds with weight higher than average");
            Console.WriteLine();
            var birds = zoo["Birds"]
                .Where(b => b.Weight > zoo["Birds"].Select(i => i.Weight).Average())
                .Select(b => new { Name = b.Name, FlightDistance = ((Bird)b).FlightDistance});
            foreach (var item in birds)
            {
                Console.WriteLine(item.Name +"  "+item.FlightDistance);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<Animal>> zoo = new Dictionary<string, List<Animal>>();
            FillIn(zoo);
            First(zoo);
            Second(zoo);
            Third(zoo);
            Fourth(zoo);
            Fifth(zoo);
            Sixth(zoo);
            Seventh(zoo);
            Eighth(zoo);
            Nineth(zoo);
            Tentn(zoo);


            Console.ReadLine();
        }
    }
}
