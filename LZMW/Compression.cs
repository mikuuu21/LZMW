using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZMW
{
    class Compression
    {

        public Dictionary<string, int> dict;
        int codeLen = 8;

        //public Compression()
        //{
        //    DictBuilder table = new DictBuilder();

        //    dict = table.Dictionary;
        //}

        public Compression()
        {
            dict = DictInitialize.DictionaryInit();
        }

        public List<int> Compress(string input)
        {



            string s = "";

            List<int> output = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {

                int c = input[i];
                string sc = s + c;

                if (dict.ContainsKey(sc))
                {
                    s = sc;
                    
                }
                else
                {


                    output.Add(dict[s]);
                    dict.Add(sc, dict.Count());
                    s = input[i].ToString();
                }

              
            }

            return output;


            //StringBuilder sb = new StringBuilder();
            //int i = 0;
            //string w = "";
            //while (i < input.Length)
            //{
            //    w = input[i].ToString();

            //    i++;

            //    while (dict.ContainsKey(w) && i < input.Length)
            //    {
            //        w += input[i];
            //        i++;
            //    }

            //    if (dict.ContainsKey(w) == false)
            //    {
            //        string matchKey = w.Substring(0, w.Length - 1);
            //        sb.Append(Convert.ToString(dict[matchKey], 2).FillWithZero(codeLen));

            //        if (Convert.ToString(dict.Count, 2).Length > codeLen)
            //            codeLen++;

            //        dict.Add(w, dict.Count);
            //        i--;
            //    }
            //    else
            //    {
            //        sb.Append(Convert.ToString(dict[w], 2).FillWithZero(codeLen));

            //        if (Convert.ToString(dict.Count, 2).Length > codeLen)
            //            codeLen++;

            //    }
        }

       


    }
}
