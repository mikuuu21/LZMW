using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class Program
    {
        static void Main(string[] args)
        {



            string path = @"indeks.jpg";
            

            var text = ReadFromFile.FileReader(path);

            Compression encoder = new Compression();

            List<int> compressed = encoder.Compress(text);


            Decompression decoder = new Decompression();
            var decompressed = decoder.Decompress(compressed);

            bool compare = String.Compare(text, decompressed, StringComparison.Ordinal) == 0;
            Console.WriteLine(text);
            Console.WriteLine("before: " + text.Count() + " after: " + compressed.Count());
            Console.WriteLine(decompressed + " " + compare);
            //byte[] data = Convert.FromBase64String(decompressed);
            //File.WriteAllBytes(@"C:\Users\miku\Desktop\wynik.jpg", data);
            //string decodedString = Encoding.UTF8.GetString(data);
           // File.WriteAllText(@"c:\folder\file.txt", decodedString);
            Console.ReadLine();



        }
    }
}