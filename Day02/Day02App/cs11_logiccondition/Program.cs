using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs11_logiccondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region <IF 구문>
            int a = 20;
            if (a == 20)  //처리하는 로직이 있으면 중괄호 필수!! 실수 줄일수 있음
            {
                Console.WriteLine("20입니다.");
                Console.WriteLine("두 번째 줄입니다.");
            }
            else if (a == 30) return; // 메서드를 완전히 빠져나가는 구문은 한 줄 가능
            #endregion

            #region <데이터타입 비교 Switch 구문>
            // 데이터타입 비교 switch문(C# 7.0부터)
            object obj = null;
            Console.WriteLine("입력하세요");
            string inputs = Console.ReadLine();          // 콘솔에서 입력 

            if (int.TryParse(inputs, out int ioutput))  // 예외가 발생하면 0
            {
                obj = ioutput; // 입력한 값이 정수라서 문자열을 정수로 반환
            }
            else if(float.TryParse(inputs, out float foutput))
            {
                obj = foutput; // 입력값이 실수라서 문자열을 실수 반환
            }
            else
            {
                obj = inputs;  // 이도 저도 아닌경우
            }

            Console.WriteLine("입력받은 데이터 : " + obj);
            
            switch (obj)
            {
                case int i:     //obj가 정수라면
                    Console.WriteLine("{0}는 int 형식입니다.",i);
                    break;
                case float f:   //obj가 실수라면
                    Console.WriteLine("{0}는 float 형식입니다.",f);
                    break;
                case string s:  // obj가 문자열이라면
                    Console.WriteLine("{0}은/는 string 형식입니다.",s);
                    break;
                default:
                    Console.WriteLine("알 수 없는 타입");
                    break;
            }
            #endregion

            #region <이중for문 - 구구단>
            for(int x=2;x<=9;x++)
            {
                for (int y = 1;y<=9;y++)
                {
                    Console.WriteLine("{0}*{1} = {2}", x, y, x * y);
                }
            }
            #endregion

            #region <Foreach>
            int[] arr = { 2, 4, 6, 8, 10 };  // 배열이나 컬렉션(리스트)
            foreach (int i in arr)
            {
                Console.WriteLine("{0} * 2 = {1}", i, i * 2);
            }
            // 위의 foreach와 같은 구문
            for (int i=0;i<arr.Length;i++)
            {
                Console.WriteLine("{0} * 2 = {1}", arr[i], arr[i] * 2);
            }
            #endregion
        }
    }
}
