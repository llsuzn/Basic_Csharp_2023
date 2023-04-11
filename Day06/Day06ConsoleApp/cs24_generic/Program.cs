using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs24_generic
{
    #region <일반화 클래스>
    class MyArray<T> where T : class    // 일반화 클래스 ... where T : class 사용할 타입은 무조건 클래스 타입이여야 한다
    {
        T[] array;
    }
    #endregion
    internal class Program  //일반화
    {
        #region <일반화 메소드>
        static void CopyArray<T>(T[] source, T[]target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        #endregion

        #region <일반화 전>
        /*
        // 하나로 만드려면 일반화 해야함
        static void CopyArray(int[] source, int[] target)
        {
            for(var i=0;i<source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        static void CopyArray(long[] source, long[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        static void CopyArray(float[] source, float[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        static void CopyArray(double[] source, double[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        static void CopyArray(string[] source, string[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }*/
        #endregion

        static void Main(string[] args)
        {
            #region < 일반화시키기 >
            int[] source = { 2, 4, 6, 8, 10 };
            int[] target = new int[source.Length];

            CopyArray(source, target);
            foreach(var item in target)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            long[] source2 = { 2100000, 2300000, 3300000, 5600000, 7800000 };
            long[] target2 = new long[source2.Length];
            CopyArray(source2, target2);
            foreach (var item in target2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            float[] source3 = { 3.14f, 3.15f, 3.16f };
            float[] target3 = new float[source3.Length];
            CopyArray(source3, target3);
            foreach (var item in target3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            // 일반화 컬렉션 제일 많이 사영
            List<int> list = new List<int>();
            for(var i = 10; i>0; i--)
            {
                list.Add(i);
            }
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            list.RemoveAt(3);       // index[3] 즉 7이 제거됨
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // 아래와 같은 일반화 컬렉션 자주 사용됨
            List<MyArray<string>> myStringArray = new List<MyArray<string>>();  

            // 일반화 스택
            Stack<float> stFloats = new Stack<float>();
            stFloats.Push(3.14f);
            stFloats.Push(7.26f);
            stFloats.Push(1.01f);
            
            while (stFloats.Count > 0)
            {
                Console.WriteLine(stFloats.Pop());  
            }
            Console.WriteLine();

            // 일반화 큐
            Queue<string> qStrings = new Queue<string>();
            qStrings.Enqueue("Hello");
            qStrings.Enqueue("World");
            qStrings.Enqueue("My");
            qStrings.Enqueue("C#");

            while(qStrings.Count > 0)
            {
                Console.WriteLine(qStrings.Dequeue());
            }
            Console.WriteLine() ;

            // 일반화 딕셔너리 .. 일반화 컬렉션 다음으로 많이 사용
            Dictionary<string, int> dicNumbers = new Dictionary<string, int>();
            dicNumbers["하나"] = 1;
            dicNumbers["둘"] = 2;
            dicNumbers["셋"] = 3;
            dicNumbers["넷"] = 4;

            Console.WriteLine(dicNumbers["셋"]);
        }
    }
}
