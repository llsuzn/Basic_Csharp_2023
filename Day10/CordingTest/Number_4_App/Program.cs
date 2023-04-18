using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_4_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dicColor = new Dictionary<string, string>();
            dicColor["빨간색"] = "Red";
            dicColor["주황색"] = "Orange";
            dicColor["노란색"] = "Yellow";
            dicColor["초록색"] = "Green";
            dicColor["파란색"] = "Blue";
            dicColor["남색"] = "Indigo";
            dicColor["보라색"] = "Violet";
            ColorCheck();
            KeyValueCheck("보라색");

            void ColorCheck()
            {
                Console.Write("무지개 색은 ");
                foreach (string i in dicColor.Keys)
                {
                    Console.Write(i+", ");
                }
                Console.WriteLine("입니다.");
            }
            void KeyValueCheck(string color)
            {
                Console.WriteLine("Key와 Value 확인");
                Console.WriteLine(color+"은/는 "+dicColor[color]+"입니다.");
            }
        }
    }
}
