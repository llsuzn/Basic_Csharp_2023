using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepcopy
{
    class SomeClass
    {
        public int SomeField1;
        public int SomeField2;

        public SomeClass DeepCopy()
        {
            SomeClass newCopy = new SomeClass();
            newCopy.SomeField1 = this.SomeField1;       //Call by value
            newCopy.SomeField2 = this.SomeField2;

            return newCopy;
        }

        #region < this >
        class Employee
        {
            private string Name;

            public void SetName(string Name)
            {
                this.Name = Name;       // 멤버변수(속성)과 메서드의 매개변수 이름이 대소문자까지 완전 똑같을때
            }
        }

        class ThisClass
        {
            int a, b, c;

            public ThisClass()
            {
                this.a = 1;
            }
            public ThisClass(int b):this()
            {
                this.b = b;
            }

            public ThisClass(int a, int b, int c) : this(b)
            {
                this.c = c;
            }
        }

        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얕은 복사 시작");      // source와 targer이 (주소를 복사) 값이 공유됨

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source;
            target.SomeField2 = 300;

            Console.WriteLine("source.SomeField1 => {0} source.SomeField1 => {1}", source.SomeField1, source.SomeField2);
            Console.WriteLine("target.SomeField1 => {0} target.SomeField1 => {1}", target.SomeField1, target.SomeField2);


            Console.WriteLine("깊은 복사 시작");

            SomeClass s = new SomeClass();
            s.SomeField1 = 100;
            s.SomeField2 = 200;

            SomeClass t = s.DeepCopy();         //깊은 복사
            t.SomeField2 = 300;
            Console.WriteLine("s.SomeField1 => {0} s.SomeField1 => {1}", s.SomeField1, s.SomeField2);
            Console.WriteLine("t.SomeField1 => {0} t.SomeField1 => {1}", t.SomeField1, t.SomeField2);

        }
    }
}
