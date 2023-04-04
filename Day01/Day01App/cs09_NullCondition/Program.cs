using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs09_NullCondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo myFoo = null;
            /*
            int? bar; // null값을 받을 수 있는 변수 생성(int?)
            if(myFoo != null)
            {
                bar = myFoo.member;
            }
            else
            {
                bar = null;
            }*/
            // 위의 주석부분을 한줄로 줄인 코드
            int? bar = myFoo?.member;
            Console.WriteLine(bar);
        }
    }
}

class Foo
{
    public int member;
}