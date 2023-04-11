using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs23_collection
{
    class CustomEnumerator : IEnumerable    //foreach를 쓸 수 있는 객체로 만들어줌 (IEnumerable)
    {
        int[] list = { 1, 3, 5, 7, 9 };

        public IEnumerator GetEnumerator()
        {
            yield return list[0];   // 메서드를 빠져나가지 않고 값만 반환
            yield return list[1];   // 리턴과는 달리 값을 보내주고 멈춰있음
            yield return list[2];
            yield return list[3];
            //yield break;
            yield return list[4];
        }
    }

    class MyArrayList : IEnumerator,IEnumerable
    {
        int[] array;            // 배열값을 집어넣는 곳
        int position = -1;      // 인덱스

        public MyArrayList()
        {
            this.array = new int[3];        //기본크기 3으로 초기화
        }

        //인덱서 프로퍼티
        public int this[int index]
        {
            get { return this.array[index]; }
            set 
            { 
                if(index >= this.array.Length)
                {
                    Array.Resize<int>(ref this.array, index + 1);
                    Console.WriteLine("MyListList Resize : {0} ", array.Length);
                }
                array[index] = value;
            }
        }

        #region <IEnumerable 인터페이스 구현>
        public IEnumerator GetEnumerator()
        {
            for(var i = 0;i <array.Length;i++)
            {
                yield return array[i];
            }
        }

        public object Current
        {
            get
            {
                return array[position];
            }
        }
        #endregion

        #region <IEnumerator 인터페이스 구현>
        public bool MoveNext()
        {
            if(position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new CustomEnumerator();

            foreach (int item in obj)
            {
                Console.WriteLine(item);
            }

            var myArrayList = new MyArrayList();
            for(var i = 0;i<=5;i++)
            {
                // indexer 프로퍼티 만들어서 구현 가능
                myArrayList[i] = i;
            }
            // IEnumerable 인터페이스 구현해서 사용가능
            foreach(var item in myArrayList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
