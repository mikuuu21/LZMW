using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LZMW
{
    class ReadFromFile
    {
        public static string FileReader(string path)
        {


            string input = File.ReadAllText(path, ASCIIEncoding.Default);
            //byte[] input = File.ReadAllBytes(path);


            if (input.Count() == 0)
            {
                throw new CustomExceptions("Plik nie zawiera żadnych znaków");
            }




            return input;





        }
    }


}


/*
 * 
 * 
             byte[] inputa = File.ReadAllBytes(path);
            var str = System.Text.Encoding.ASCII.GetString(inputa);
  
 kod do użycia przy typie zwracanych danych: dynamic

             if (path.Contains(".gif"))
        {
            byte[] input = File.ReadAllBytes(path);

            if (input.Count() == 0)
            {
                throw new CustomExceptions("Plik nie zawiera żadnych znaków");
            }

            return input;
        }
        else
        {


            string input = File.ReadAllText(path, ASCIIEncoding.Default);

            if (input.Count() == 0)
            {
                throw new CustomExceptions("Plik nie zawiera żadnych znaków");
            }

            return input;
        }

 */

