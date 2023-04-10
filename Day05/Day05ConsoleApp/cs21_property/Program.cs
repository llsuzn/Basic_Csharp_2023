using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Car
    {
        int year;
        string fuelType;
        string company;
        int door;
        int price;


        //  필터링이 필요없으면 멤버변수 없이 프로퍼티로 사용
        public string Name { get; set; }
        public string Color { get; set; }
        //  들어오는 데이터를 필터링 할 땐 private 멤버변수와 public 프로퍼트 둘 다 사용
        public int Year
        {
            get { return year; } // ==> get => year; (람다식) 
            set
            {
                if (value <= 1900 || value >= 2023)
                {
                    value = 2023;
                }
                else
                {
                    Year = value;
                }
            }
        }
        public string FuelType
        {
            get => fuelType;
            set
            {
                if (value != "휘발유" || value != "경유")
                {
                    value = "휘발유";
                }
                fuelType = value;
            }
        }
        public int Door 
        { 
            get { return door; } 
            set
            {
                if (value != 2 || value != 4)
                {
                    value = 4;
                }
                door = value;
            } 
        }
        public string TireType { get; set; }
        public string Company { get; set; } = "현대자동차";
        public int Price { get => price; set => price = value; }
        public string CarIdNumber { get; set; }
        public string CarPlateNumber { get; set; }
    }

    interface IProduct
    {
        string ProductName { get; set; }

        void Produce();
    }

    class MyProduct:IProduct
    {
        private string productName;

        public string ProductName { 
            get { return productName; }
            set { productName = value; }
        }

        public void Produce()
        {
            Console.WriteLine("{0}을(를) 생산합니다.", ProductName);
        }
    }
      

    internal class Program
    {
        static void Main(string[] args)
        {
            Car genesis = new Car();
            genesis.Color = "red";
            Console.WriteLine(genesis.Color);
            genesis.FuelType = "올리브유";
            Console.WriteLine(genesis.FuelType);

            // 생성할 때 프로퍼티로 초기화
            Car K9 = new Car()
            {
                Name = "케이나인",
                FuelType = "식용유",
                Color = "검정색",
                Door = 4,
                TireType = "광폭타이어",
                Year = 0,
            };

            Console.WriteLine("자동차 제조회사는 {0}",K9.Company);
            Console.WriteLine("자동차 제조년도는 {0}년",K9.Year);
            Console.WriteLine("자동차 연료는 {0}",K9.FuelType);
            Console.WriteLine("자동차 문 개수 {0}개", K9.Door);

        }
    }
}
