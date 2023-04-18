using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_5_App
{

    interface IAnimal
    {
        void Sleep();
        void Eat();
        void Sound();
    }
    class Dog : IAnimal
    {
        public string Name;
        public Dog(string Name) => this.Name = Name;
        public int Age;
        public void Eat()
        {
            Console.WriteLine($"{Name}이/가 밥을 먹습니다.");
        }
        public void Sound()
        {
            Console.WriteLine("멍멍!");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}이/가 잠을 잡니다.");
        }
    }
    class Cat : IAnimal
    {
        public string Name;
        public Cat(string Name) => this.Name = Name;
        public int Age;
        public void Eat()
        {
            Console.WriteLine($"{Name}이/가 밥을 먹습니다.");
        }
        public void Sound()
        {
            Console.WriteLine("야옹!");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}이/가 잠을 잡니다.");
        }

    }
    class Horse : IAnimal
    {
        public string Name;
        public Horse(string Name) => this.Name = Name;
        public int Age;
        public void Eat()
        {
            Console.WriteLine($"{Name}이/가 밥을 먹습니다.");
        }
        public void Sound()
        {
            Console.WriteLine("히이잉!");
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name}이/가 잠을 잡니다.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("바둑이");
            dog.Eat();
            dog.Sound();
            Cat cat = new Cat("크림이");
            cat.Sound();
            Horse horse = new Horse("마알");
            horse.Eat();
            horse.Sound();
            horse.Sleep();
        }
    }
}
