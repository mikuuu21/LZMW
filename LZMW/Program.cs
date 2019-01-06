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

            List<int> compressed = encoder.Compress(text);


            Decompression decoder = new Decompression();
            var decompressed = decoder.Decompress(compressed);

            bool compare = String.Compare(text, decompressed, StringComparison.Ordinal) == 0;
            Console.WriteLine(text);
            Console.WriteLine("before: " + text.Count() + " after: " + compressed.Count());
            Console.WriteLine(text + " = " + decompressed + " " + compare);
            Console.ReadLine();



        }
    }
}