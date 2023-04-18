using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_1_2_App
{
    class Boiler
    {
        public string Brand;
        private int voltage;
        private int temperature;

        public int Voltage
        {
            get { return voltage; } 
            set
            {
                if (value != 110 && value != 220) 
                {
                    Console.WriteLine("전압을 다시 확인해주세요.");
                    value = 0;
                }
                else
                {
                    voltage = value;
                }
            }
        }

        public int Temperature 
        { 
            get
            {
                return this.temperature;
            }

            set
            {
                if (value <= 5)
                {
                    this.temperature = 5;
                }
                else if (value >= 70)
                {
                    this.temperature = 70;
                }
                else
                {
                    this.temperature = value;
                }
            }
        }


        public void PrintAll()
        {
            Console.WriteLine(Brand);
            Console.WriteLine(voltage);
            Console.WriteLine(temperature);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();
        }
    }
}
