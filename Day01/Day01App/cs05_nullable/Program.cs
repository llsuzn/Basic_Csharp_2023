using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs05_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = null;              // int a는 null 값을 담을 수 없음 
            int? a = null;               // C# 6.0 Nullable

            Console.WriteLine(a == null);
            // Console.WriteLine(a.GetType()); 예외발생 : 널형태는 없음

            int b = 0;
            Console.WriteLine(b == null);
            Console.WriteLine(b.GetType());

            // 값형식 byte, short, int, long, float, double, char 등은 null을 할당 X
            // null을 할당할 수 있도록 만드는 방식 : type? 형태로 만들어주면 됨

            float? c = null;
            Console.WriteLine(c.HasValue); // false(null이라서)
            // Console.WriteLine(c.Value); 에러발생
            Console.WriteLine(c);

            c = 3.1415f;
            Console.WriteLine(c.HasValue); // true(null이 아니라서)
            Console.WriteLine(c.Value);
            Console.WriteLine(c);
        }
    }
}
