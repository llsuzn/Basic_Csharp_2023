using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs30_filereadwrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 읽기
/*            string line = string.Empty; // 텍스트를 읽어와서 출력
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@".\python.py"); //스트림리더 파일 연결

                line = reader.ReadLine();

                while(line != null)
                {
                    Console.WriteLine(line);        // 한 줄 읽은것 출력

                    line = reader.ReadLine();       // 다음 줄 읽음
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"예외 {e.Message}");
            }
            finally
            {
                reader.Close();     // 파일 읽으면 무조건 마지막에
            }*/


            // 쓰기
            StreamWriter writer = new StreamWriter(@".\pythonByCshap.py");

            try
            {
                writer.WriteLine("import.sys;");
                writer.WriteLine("");
                writer.WriteLine("print(sys.executable)");
            }
            catch (Exception e)
            {
                Console.WriteLine($"예외! {e.Message}");
            }
            finally
            {
                writer.Close();
            }
            Console.WriteLine("파일생성 완료");
        }
    }
}
