using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleApplication43
{
    class Animal
    {
        public int age;
        public string name;

        public Animal(string name, int age)
        {
            this.age = age;
            this.name = name;
        }
        public void eat()
        {
            Console.WriteLine("먹는다!");
        }
        public void sleep()
        {
            Console.WriteLine("잔다!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("고양이", 4);
            Type type = animal.GetType();

            ConstructorInfo[] coninfo = type.GetConstructors();
            Console.Write("생성자(Constructor) : ");
            foreach (ConstructorInfo tmp in coninfo)
                Console.WriteLine("\t{0}", tmp);
            Console.WriteLine();

            MemberInfo[] meminfo = type.GetMethods();
            Console.Write("메소드(Method) : ");
            foreach (MethodInfo tmp in meminfo)
                Console.Write("\t{0}", tmp);
            Console.WriteLine();

            FieldInfo[] fieldinfo = type.GetFields();
            Console.Write("필드(Field) : ");
            foreach (FieldInfo tmp in fieldinfo)
                Console.Write("\t{0}", tmp);
            Console.WriteLine();
        }
    }
}