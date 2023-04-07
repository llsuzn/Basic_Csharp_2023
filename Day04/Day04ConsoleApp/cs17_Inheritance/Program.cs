using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs17_Inheritance
{
    // 상속해줄 부모클래스
    class Parent
    {
        protected string Name;
        public Parent(string Name)
        {
            this.Name = Name;
            Console.WriteLine("{0} From Parent 생성자", Name);
        }

        public void ParentMethod()
        {
            Console.WriteLine("{0} From Parent 메소드" , Name);
        }
    }

    // 상속받을 자식클래스
    class Child : Parent
    {
        public Child(string Name) : base(Name)      // 부모클래스를 먼저 실행한 뒤 자신 생성자를 실행
        {
            Console.WriteLine("{0} From Child 생성자", Name);
        }
        public void ChildMethod()
        {
            Console.WriteLine("{0} From Child 메소드", Name);
        }
    }

    // 클래스간 형변환 DB처리, DI
    class Mammal //포유류
    {
        public string Name;
        public Mammal(string Name)
        {
            this.Name = Name;
        }
        public void Nurse()  // 젖 먹이기
        {
            Console.WriteLine("포유류 {0} 기르다", Name);
        }
    }
    class Dogs : Mammal
    {
        public Dogs(string Name):base(Name) { }
        public void Bark()
        {
            Console.WriteLine("{0} 멍멍!!",Name);
        }
    }
    class Cats : Mammal
    {
        public Cats(string Name) : base(Name) { }
        public void Meow()
        {
            Console.WriteLine("{0} 야옹~",Name);
        }
    }

    class Elephant:Mammal
    {
        public Elephant(string Name) : base(Name) { }
        public void Poo()
        {
            Console.WriteLine("{0} 뿌우ㅜ~~",Name);
        }
    }

    class ZooKeeper
    { 
        public void Wash(Mammal mammal)
        {
            if(mammal is Elephant)
            {
                var animal = mammal as Elephant;
                Console.WriteLine("{0} 을/를 씻깁니다.",animal.Name);
                animal.Poo();
            }
            else if(mammal is Dogs)
            {
                var animal = mammal as Dogs;
                Console.WriteLine("{0} 을/를 씻깁니다.",animal.Name);
                animal.Bark();
            }
            else if (mammal is Cats)
            {
                var animal = mammal as Cats;
                Console.WriteLine("{0} 을/를 씻깁니다.",animal.Name);
                animal.Meow();
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {  
            #region <기본상속 개념>
            /*
            Parent P = new Parent("P");
            P.ParentMethod();

            Console.WriteLine("자식클래스 생성");
            Child C = new Child("C");
            C.ParentMethod();       // 자식클래스는 부모클래스의 속성, 기능을 모두 쓸 수 있다(단, public, protected일때만)
            C.ChildMethod();
            */
            #endregion
            
            #region <클래스간 형식변환>

            Mammal Person = new Mammal("수진");
            Person.Nurse();
            //Dogs dogs = new Mammal(); 자식클래스 형식으로 부모클래스형식의 객체 생성 불가능

            Mammal dogs = new Dogs("바둑이");
            dogs.Nurse();
            // 클래스 형 변환
            if (dogs is Dogs)
            {
                Dogs midDog = dogs as Dogs; //(Dogs)dogs;
                midDog.Bark();
            }

            Cats cats = new Cats("크림이");
            cats.Nurse();
            cats.Meow();

            Elephant elephant = new Elephant("코끼링");


            ZooKeeper keeper = new ZooKeeper();
            keeper.Wash(dogs);
            keeper.Wash(cats);
            keeper.Wash(elephant);

            #endregion
        }
    }
}
