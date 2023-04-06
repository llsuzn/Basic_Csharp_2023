using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_Class
{
    class Cat  // 같은 namespace안에 있기 때문에 main에서 객체 생성 가능
    {
        #region <생성자>

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Cat()  
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }
        /// <summary>
        /// 사용자 지정 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        public Cat(string name, string color = "흰색", sbyte age = 1)
        {
            Name = name;
            Color = color;
            Age = age;
        }

    

        #endregion


        #region <멤버변수 - 속성>
        public string Name;           // 고양이 이름
        public string Color;          // 색상
        public sbyte Age;             // 고양이 0~255
        #endregion

        #region <멤버메소드 - 기능>
        public void Meow()           // 기본이 private임
        {
            Console.WriteLine("{0} - 야옹!!",Name);
        }
        public void Run()            // public은 main에서도 접근 가능
        {
            Console.WriteLine("{0} - 달린다.",this.Name);
        }
        #endregion

    }

    internal class Program          // Program.cs 전체에서 사용가능
    {
        static void Main(string[] args)
        {
            Cat helloKitty = new Cat();     // helloKitty 객체 생성
            helloKitty.Name = "헬로키티";
            helloKitty.Color = "흰색";
            helloKitty.Age = 50;
            helloKitty.Meow();
            helloKitty.Run();

            // 객체를 생성하면서 속성 초기화
            Cat nero = new Cat() {
                Name = "검은고양이 네로",
                Color = "검은색",
                Age = 27,
            };
            nero.Meow();
            nero.Run();

            Console.WriteLine("{0}의 색상은 {1} , 나이는 {2}세 입니다. ",helloKitty.Name,helloKitty.Color,helloKitty.Age);
            Console.WriteLine("{0}의 색상은 {1} , 나이는 {2}세 입니다. ",nero.Name,nero.Color,nero.Age);


            // 기본생성자
            Cat sujin = new Cat();
            Console.WriteLine("{0}의 색상은 {1} , 나이는 {2}세 입니다.",sujin.Name,sujin.Color,sujin.Age);
            Cat norang = new Cat("노랑이", "노란색");
            Console.WriteLine("{0}의 색상은 {1} , 나이는 {2}세 입니다.",norang.Name,norang.Color,norang.Age);
        }
    }
}
