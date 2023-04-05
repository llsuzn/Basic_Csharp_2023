using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs10_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 비트연산
            // <<는 *2와 같고
            // >>는 /2와 같다
            int firstval = 0b1111;              //15(1111)
            int secondval = firstval << 1;      //30(11110)
            Console.WriteLine("0b1111 : "+ firstval);
            Console.WriteLine("0b1111 shift << : " + secondval);

            firstval = 15;
            secondval = 30;
            Console.WriteLine("\n&비교 : {0}" , firstval&secondval);
            Console.WriteLine("|비교 : {0}", firstval | secondval);
            Console.WriteLine("~ 보수 : " + ~secondval); //보수

            //NULL 병합 연산자
            int? checkval = null;
            //3항연산자
            Console.WriteLine("\ncheckval == null -> {0}",checkval == null ? 0 : checkval);
            //NULL병합 연산자는 3항연산자를 더 축소시킨 것
            Console.WriteLine("checkval ?? 0 -> {0}",checkval ?? 0);
            checkval = 100;
            Console.WriteLine("checkval == null -> {0}", checkval == null ? 0 : checkval);
            Console.WriteLine("checkval ?? 0 -> {0}", checkval ?? 0);

        }
    }
}
