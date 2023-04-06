using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs16_Inheritance
{
    class Base
    {
        //자식클래스에서 상속받으려면 private는 사용 X
        protected string Name;
        private string Color;   //만약에 상속을 할거면 private을 protected로 변경!
        public int Age;

        public Base(string Name, string Color, int Age)
        {
            this.Name = Name;
            this.Color = Color;
            this.Age = Age;

            Console.WriteLine("{0}.Base()",Name);
        }
        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }

        public void GetColor()
        {
            Console.WriteLine("{0}.Base() {1}", Name, Color);
        }
    }

    class Child : Base      // 상속받은 이후 Base의 Name,Color,Age를 새로 만들거나 하지 않음
    {
        public Child(string Name,string Color,int Age) : base(Name, Color, Age)
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", Name);
        }
/*        public string GetColor()
        {
         //   return Color;       // 부모클래스에서 상속받은 Color가 private여서 접근 불가능
        }
*/
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Base B = new Base("NameB", "White",1);
            B.BaseMethod();
            B.GetColor();

            Console.WriteLine();

            Child C = new Child("NameC", "Black", 0);
            C.BaseMethod();
            C.ChildMethod();
            C.GetColor();       //Base.GetColor Black...C에서 Color 접근 불가
        }
    }
}
