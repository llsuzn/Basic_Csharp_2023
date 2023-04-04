using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_04Program
{
    internal class Program
    {
        enum HomeTown
        {
            SEOUL,
            DAEJEON,
            DAEGU,
            BUSAN,
            JEJU
        }

        static void Main(string[] args)
        {
            HomeTown myHomeTown;
            myHomeTown = HomeTown.BUSAN;

            if(myHomeTown == HomeTown.SEOUL)
            {
                Console.WriteLine("서울 출신이시군요!");
            }
            else if (myHomeTown == HomeTown.BUSAN)
            {
                Console.WriteLine("부산 출신이시군요!");
            }
            else if (myHomeTown == HomeTown.DAEGU)
            {
                Console.WriteLine("대구 출신이시군요!");
            }
            else if (myHomeTown == HomeTown.DAEJEON)
            {
                Console.WriteLine("대전 출신이시군요!");
            }
            else if (myHomeTown == HomeTown.JEJU)
            {
                Console.WriteLine("제주 출신이시군요!");
            }
            else { Console.WriteLine("지방 출신이시군요!"); }
        }
    }
}
