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
            var bird6 = new Bird("Red Female", 3, 7000);

            MyQueue<Animal> zoo = new MyQueue<Animal>();
            MyQueue<Bird> birdSection = new MyQueue<Bird>();

            zoo.Enqueue(animal1);
            zoo.Enqueue(animal2);
            zoo.Enqueue(animal3);
            zoo.Enqueue(animal4);
            zoo.Enqueue(animal5);
            zoo.Enqueue(animal6);
            zoo.Enqueue(animal7);
            zoo.Enqueue(animal8);
            zoo.Enqueue(animal9);
            zoo.Enqueue(animal10);
            zoo.Enqueue(animal11);
            zoo.Enqueue(animal12);
            zoo.Enqueue(bird1);
            zoo.Enqueue(bird2);
            zoo.Enqueue(bird3);
            zoo.Enqueue(bird4);
            zoo.Enqueue(bird5);

            birdSection.Enqueue(bird1);
            birdSection.Enqueue(bird2);
            birdSection.Enqueue(bird3);
            birdSection.Enqueue(bird4);
            birdSection.Enqueue(bird5);
            birdSection.Enqueue(bird6);


            Console.ReadLine();
        }
    }
}
