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

        public static Dictionary<string, int> DictionaryInit()
        {

             Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < 256; i++)
            {
                dict.Add(((char)i).ToString(), i);

            }

            return dict;

        }


    }
}
