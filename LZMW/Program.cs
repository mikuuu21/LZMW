using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class Program
    {
        static void Main(string[] args)
        {



            string path = @"input.txt";

            var text = ReadFromFile.FileReader(path);

            Compression encoder = new Compression();
            encoder.Compress(text);
            


            Console.WriteLine();
            Console.ReadLine();



        }
    }
}