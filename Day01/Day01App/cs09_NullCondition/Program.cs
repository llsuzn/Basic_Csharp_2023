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
            int? bar;
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
        }
    }
}

class Foo
{
    public int member;
}