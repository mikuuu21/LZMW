using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class Decompression
    {
        public Dictionary<string, int> dict;

        //public Compression()
        //{
        //    DictBuilder table = new DictBuilder();

        //    dict = table.Dictionary;
        //}

        public Decompression()
        {
            dict = DictInitialize.DictionaryInit();
        }


        public string Decompress(List<byte> compressedFile)
        {

            return "";
        }
    }
}

