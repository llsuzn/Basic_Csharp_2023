using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_15accessmodifier
{
    internal class WaterHeater  // class에 기본 접근한정자 internal
    {
        protected int temp;   // 내부 멤버함수에서 접근이 가능  ... 상속받은 자식클래스에선 접근이 가능

        public void SetTemp(int temp)
        {
            if(temp<-5 ||temp>40)
            {
                Console.WriteLine("범위 이탈");
                return;
            }
            this.temp = temp;
        }

        internal void TurnOnHeater()
        {
            Console.WriteLine("보일러 ON : {0}℃",temp);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WaterHeater boiler = new WaterHeater();
            boiler .SetTemp(3);
            boiler.TurnOnHeater();
        }
    }
}
