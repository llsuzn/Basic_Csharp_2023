using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs03_object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // object 형식
            // int == System.Int32
            Int32 idata = 1024;
            Int64 idata64 = 1024;
            Console.WriteLine(idata);
            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(long));
            Console.WriteLine(idata.GetType());
            Console.WriteLine(idata64.GetType());

            object iobj = (object)idata;        // 박싱 : 데이터타입 값을 object로 담음
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            int udata = (int)iobj;              // 언박싱 : object를 원래 데이터타입으로 바꿈
            Console.WriteLine(udata);
            Console.WriteLine(udata.GetType());

            double ddata = 3.141592;
            object pobj = (object)ddata;
            double pdata = (double)pobj;

            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            short sdata = 32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata);
            indata = (int)lndata;
            Console.WriteLine(indata);

            // float double 간의 형변환
            float fval = 3.141592f;         //float 타입은 마지막에 f를 써줘야함
            Console.WriteLine("fval = " + fval);
            double dval = (double)fval;
            Console.WriteLine("dval = " + dval);
            Console.WriteLine(fval == dval);
            Console.WriteLine(dval == 3.141592);

            //정말 중요!! 실무에서
            int numival = 1024;
            string strival = numival.ToString();
            //Console.WriteLine(numival == strival);
            Console.WriteLine(strival.GetType());

            double numdval = 3.1415928974651;
            string strdval = numdval.ToString();
            Console.WriteLine(strdval);

            // 문자열을 숫자로 _ 숫자만 바꿀 수 있음...특수문자가 포함되면 예외발생
            // 문자열내에 숫자가 아닌 특수문자나 정수인데 소수점이 있으면
            string originstr = "30000000";
            int convval = Convert.ToInt32(originstr);       // int.Parse() 동일
            Console.WriteLine(convval);
            originstr = "1.2345";
            float convfloat = float.Parse(originstr);
            Console.WriteLine(convfloat);

            //예외발생하지 않게 형변환 하는 방법
            originstr = "123.4c";       // 문자가 들어있으니 원래는 예외가 발생
            // TryParse를 사용하면 0이 반환
            float ffval;
            // TryParse는 예외가 발생하면 값은 0으로 반환하고, 예외가 없으면 원래값으로
            float.TryParse(originstr,out ffval);        //형변환 할 수 없다면 0반환
            Console.WriteLine(ffval);

            const double pi = 3.1415924574645874;       //const는 값 변환이 안 됨(상수화)
            Console.WriteLine(pi);


        }
    }
}
