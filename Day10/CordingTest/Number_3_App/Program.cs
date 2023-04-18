using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_3_App
{
    class Car
    {
        public string Name;
        public string Maker;
        public string Color;
        public int YearModel;
        public int MaxSpeed;
        public string UniqueNumber;
        public void Start()
        {
            Console.WriteLine($"{Name}의 시동을 겁니다.");
        }
        public void Accelerate()
        {
            Console.WriteLine($"최대시속 {MaxSpeed}Km/h로 가속합니다.");
        }
        public void TurnRight()
        {
            Console.WriteLine($"{Name}를 우회전합니다.");
        }
        public void Break()
        {
            Console.WriteLine($"{Name}의 브레이크를 밟습니다.");
        }
    }
    class ElectricCar : Car
    {
        public void Recharge()
        {
            Console.WriteLine("달리면서 전기 배터리를 충전합니다.");
        }
    }
    class HybridCar : ElectricCar
    {
        public new void Recharge()
        {
            Console.WriteLine("달리면서 수소 배터리를 충전합니다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ionic = new HybridCar();
            ionic.Name = "아이오닉";
            ionic.Maker = "현대자동차";
            ionic.Color = "White";
            ionic.YearModel = 2018;
            ionic.MaxSpeed = 220;
            ionic.UniqueNumber = "54라 3346";

            ionic.Start();
            ionic.Accelerate();
            ionic.Recharge();
            ionic.TurnRight();
            ionic.Break();
            
        }
    }
}
