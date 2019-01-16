using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class Decompression
    {
        public Dictionary<int, string> dict;

        //public Compression()
        //{
        //    DictBuilder table = new DictBuilder();

        //    dict = table.Dictionary;
        //}

        public Decompression()
        {
            dict = DictInitialize.DeompressDictionaryInit();
        }


        public string Decompress(List<int> compressedFile)
        {

            string w = dict[compressedFile[0]];
            compressedFile.RemoveAt(0);
            StringBuilder decompressed = new StringBuilder(w);

            foreach (int k in compressedFile)
            {
                string entry = null;
                if (dict.ContainsKey(k))
                    entry = dict[k];
                else if (k == dict.Count)
                    entry = w + w[0];

                decompressed.Append(entry);

                dict.Add(dict.Count, w + entry[0]);

                w = entry;
            }
            return decompressed.ToString();

            //string oldCharacter = dict[compressedFile[0]];
            //int prevCode = compressedFile[0];
            //int currCode;
            //string entry;
            //string result = dict[prevCode];
            //char ch;
            //for (int i = 1; i < compressedFile.Count(); i++)
            //{
            //    currCode = compressedFile[i];
            //    if (dict.ContainsKey(currCode))
            //    {
            //        entry = dict[currCode];
            //    }
            //    else
            //    {
            //        entry = dict[prevCode] + oldCharacter[0];
            //    }

            //    result += entry;
            //    ch = entry[0];
            //    dict.Add(dict.Count(), dict[prevCode] + ch);
            //    prevCode = currCode;
            //}


            //return result;


        }
    }
}

