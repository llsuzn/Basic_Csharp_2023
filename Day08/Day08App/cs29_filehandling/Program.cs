using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace cs29_filehandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Directory == Folder
            // @"C:\\Dev" 리터럴은 여러줄도 가능
            string curDirectory = @"C:\Temp";   //C:\Dev는 절대경로  /  .은 현재 디렉토리(상대경로) / ..은 상위폴더

            Console.WriteLine("현재 디렉토리 정보");

            var dirs = Directory.GetDirectories(curDirectory);
            foreach (var dir in dirs)
            {
                var dirInfo = new FileInfo(dir);

                Console.Write(dirInfo.Name);
                Console.WriteLine(" [{0}]",dirInfo.Attributes);
            }

            Console.WriteLine("\n현재 디렉토리 파일정보");

            var files = Directory.GetFiles(curDirectory);
            foreach(var file in files)
            {
                var fileInfo = new FileInfo(file);

                Console.Write(fileInfo.Name);
                Console.WriteLine(" [{0}]", fileInfo.Attributes);
            }

            //특정 경로에 하위폴더 / 하위파일 조회
            string path = @"C:\Temp\CShap_Bank"; // 만들고자 하는 폴더
            string sfile = "Test.log";           // 생성할 파일

            if (Directory.Exists(path))
            {
                Console.WriteLine("경로가 존재하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile);   // C:\Temp\CShap_Bank\Test.log
            }
            else
            {
                Console.WriteLine($"해당경로가 없습니다 {path}");
                Directory.CreateDirectory(path);    // 디렉토리 만들기
                Console.WriteLine("경로가 생성하여 파일을 생성합니다.");
                File.Create(path + @"\" + sfile);   // C:\Temp\CShap_Bank\Test.log
            }
        }
    }
}
