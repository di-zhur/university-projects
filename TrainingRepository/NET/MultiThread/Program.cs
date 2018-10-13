using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultiThread.Tasks;

namespace MultiThread
{
    class Program
    {
        static void Main()
        {
            var dir = @"C:\Users\dmitr\Desktop\project\TrainingRepository\NET\TempForTest\";
            var dirs = new DirectoryInfo(dir).Parent;
            var files = Directory.GetFiles(dir);


            foreach (var file in files)
            {
                Task.Factory.StartNew(() => ReadInfo(file));
                Console.WriteLine(file);
            }
           
            // ReadCount("file2.txt");

            Console.ReadKey();
        }


        static async Task<long> ReadInfo(string fileName)
        {
            
            
            int longLines = File.ReadAllBytes(fileName).Length;
            var fI = new FileInfo(fileName);
            var lines = File.ReadAllLines(fileName);
            var linesCount = File.ReadAllBytes(fileName);
            Console.WriteLine(lines);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            
            //using (var fs = new FileStream(path, FileMode.Open))
            //using (TextReader reader = new StreamReader(fs))
            //{
            //    var i = 0;
            //    var result = new byte[fs.Length];
            //    var res = await fs.ReadAsync(result, 0, (int)fs.Length);
            //    var lines =  reader.ReadLineAsync();
            //    Console.WriteLine(lines);
            //}
            //Console.WriteLine(longLines);
            return 0;
        }
    }
}