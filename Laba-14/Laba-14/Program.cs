using AnimalsLib;
using System;
using System.Linq;

namespace Laba_14
{
    class Program
    {
        static void Main(string[] args)
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

            var bird1 = new Bird("Red", 3, 7000);
            var bird2 = new Bird("Bomb", 30, 14000);
            var bird3 = new Bird("Yellow", 1, 700);
            var bird4 = new Bird("Egg thrower", 3, 2000);
            var bird5 = new Bird("Able to grow", 3, 6000);
            var bird6 = new Bird("Red Female", 3, 8000);

            Collections<Animal> linqCollection = new Collections<Animal>();

            linqCollection.zoo.Add(animal1);
            linqCollection.zoo.Add(animal2);
            linqCollection.zoo.Add(animal3);
            linqCollection.zoo.Add(animal4);
            linqCollection.zoo.Add(animal5);
            linqCollection.zoo.Add(animal6);
            linqCollection.zoo.Add(animal7);
            linqCollection.zoo.Add(animal8);
            linqCollection.zoo.Add(animal9);
            linqCollection.zoo.Add(animal10);
            linqCollection.zoo.Add(animal11);
            linqCollection.zoo.Add(animal12);
            linqCollection.zoo.Add(bird1);
            linqCollection.zoo.Add(bird2);
            linqCollection.zoo.Add(bird3);
            linqCollection.zoo.Add(bird4);
            linqCollection.zoo.Add(bird5);

            linqCollection.birdSection.Add(bird1);
            linqCollection.birdSection.Add(bird2);
            linqCollection.birdSection.Add(bird3);
            linqCollection.birdSection.Add(bird4);
            linqCollection.birdSection.Add(bird5);
            linqCollection.birdSection.Add(bird6);

            // First Query
            Console.WriteLine("Select: Animals with spaces  in their names");
            Console.WriteLine();
            var spacy = (from animals in linqCollection.zoo
                         where animals.Name.Contains(" ")
                         orderby animals.Name descending
                         select animals);
            foreach (var item in spacy)
            {
                Console.WriteLine(item);
            }

            // Second
            Console.WriteLine("Count: The number of animals heavier than 40");
            Console.WriteLine();
            var heavyAnimals = (from animals in linqCollection.zoo
                         where animals.Weight > 40
                         select animals).Count<Animal>();
            Console.WriteLine(heavyAnimals);
            Console.WriteLine();

            //Third
            Console.WriteLine("Intersection: Birds from animals collection with fight distance fewer than 8000 ");
            Console.WriteLine();
            var birdsFromAnimals = (from animals in linqCollection.zoo
                                    select animals).Intersect(from birds in linqCollection.birdSection
                                                              where ((Bird)birds).FlightDistance < 8000
                                                              select birds);
            foreach (var item in birdsFromAnimals)
            {
                ((Bird)item).ShowCreature();
            }

            Console.WriteLine();


            //Fourth
            Console.WriteLine("Aggregate");
            Console.WriteLine();
            Func<int, int, int> summa = delegate (int a, int b) { return a + b; };
            int sum2 = arr1.Aggregate<int>(summa);

            Console.WriteLine();


            //Fifth
            Console.WriteLine("Animals with spaces  in their names");
            Console.WriteLine();



            Console.ReadLine();
        }
    }
}
