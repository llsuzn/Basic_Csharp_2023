using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs01_variable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte bdata = byte.MaxValue;
            Console.WriteLine(bdata);

            bdata = byte.MinValue;
            Console.WriteLine(bdata);

            long ldata = long.MaxValue;
            Console.WriteLine(ldata);
            ldata = long.MinValue;
            Console.WriteLine(ldata);

            ldata--;
            Console.WriteLine(ldata);

            int binVal = 0b11111111;          // 0b : 이진수표현 .. 10(2)
            Console.WriteLine(binVal);

            int hexVal = 0xFF;                // 0x : 십육진수
            Console.WriteLine(hexVal);

            float fdata = float.MaxValue;
            Console.WriteLine(fdata);   

            fdata = float.MinValue;
            Console.WriteLine(fdata);

            double ddata = double.MaxValue; 
            Console.WriteLine(ddata);   

            ddata = double.MinValue;    
            Console.WriteLine(ddata);   

        }
    }
}

