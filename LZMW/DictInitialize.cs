using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class DictInitialize
    {
        //private Dictionary<string, int> dictionary = new Dictionary<string, int>();

        //public Dictionary<string, int> Dictionary
        //{
        //    get
        //    {
        //        return dictionary;
        //    }
        //}



        //public DictInitialize()
        //{

        //    for (int i = 0; i < 256; i++)
        //    {
        //        dictionary.Add(((char)i).ToString(), i);

        //    }

        //}

        public static Dictionary<string, int> CompressDictionaryInit()
        {

             Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < 256; i++)
            {
               dict.Add(((char)i).ToString(), i);
               // dict.Add(System.Text.Encoding.Default.GetString(new byte[1] { Convert.ToByte(i) }), i);
            }

            return dict;

        }

        public static Dictionary<int, string> DeompressDictionaryInit()
        {

            Dictionary<int, string> dict = new Dictionary<int, string>();

            for (int i = 0; i < 256; i++)
            {
                dict.Add(i,((char)i).ToString());

            }

            return dict;

        }
    }
}
