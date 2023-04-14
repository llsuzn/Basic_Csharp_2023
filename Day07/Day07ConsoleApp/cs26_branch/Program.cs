using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs26_branch
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            object[] obj = new object[2];
            obj[0] = 100;
            obj[1] = 3.14159265f;

            for(int j = 0; j < 2;j++)
            {
                switch (obj[j])
                {
                    case int i:
                        Console.WriteLine($"int형 data : {obj[j]}");
                        break;
                    case float f:
                        Console.WriteLine($"float형 data : {obj[j]}");
                        break;
                }
            }
        }
    }
}
