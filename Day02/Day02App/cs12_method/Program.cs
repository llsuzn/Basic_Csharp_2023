using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs12_method
{
    class Calculator
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a,int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        /// <summary>
        /// 실행 시 메모리에 최초 올라가야 하기 때문에 static이 되어야 하고
        /// 메서드 이름이 main이면 실행될 때 알아서 제일 처음에 실행이 된다
        /// </summary>
        /// <param name="args"></param>
        /// 


        // static은 최초실행 될 때 메모리에 바로 올라가기 때문에 클래스 객체를 만들 필요가 없음
        static void Main(string[] args)     // static 선언 안하면 실행이 안 됨 -> 메모리에 바로 올라가기 때문에 바로 실행
        {
            #region <static>
            int result = Calculator.Plus(1, 2); 
            Console.WriteLine("Plus : " + result);
            // Calculator.Minus(3, 2); 마이너스는 static이 아니라 접근 불가(객체 생성해야 가능)
            result = new Calculator().Minus(3, 2);
            Console.WriteLine("Minus : " + result);
            #endregion
            #region <CallByREference>
            int a = 5, b = 10;
            Swap(ref a, ref b); // ref : 변수의 주소를 전달  Call By Reference == Pointer
            Console.WriteLine("{0} {1}", a, b);
            #endregion

            #region < out 매개변수>
            int divid = 30;
            int divor = 2;
            int rem = 0;
            Divide(divid, divor,ref result,out rem);  //ref 와 out 차이 없음
            Console.WriteLine("나누기 값 : {0}\n나머지 : {1}", result, rem);

            (result, rem) = Divide(20, 6);          // 튜플
            Console.WriteLine("나누기 값 : {0}\n나머지 : {1}", result, rem);

            #endregion

            #region <가변길이 매개변수>

            Console.WriteLine(Sum(1,2,3,4,5,6,7,8,9,10));

            #endregion

            #region < ref getnum>
            Console.WriteLine(GetNum());
            #endregion
        }

        /*        static int Divide(int x,int y)
                {
                    return x / y;
                }
                static int Reminder(int x, int y)
                {
                    return x % y;
                }*/
        static void Divide(int x, int y, ref int val, out int rem)
        {
            val = x / y;
            rem = x % y;
        }
        static (int result, int rem) Divide(int x,int y)
        {
            return (x / y, x % y);      // C# 7.0 이후 지원
        }


        public static void Swap(ref int a, ref int b)   // 메인 메서드와 같은 메서드에 있는 메서드들은 전부 static이 되어야 한다(무조건!)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;

            Console.WriteLine("{0} {1}", a, b);
        }

        static int val = 100;
        public static ref int GetNum()
        {
            return ref val;
        }

        public static int Sum(params int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
    }
}
