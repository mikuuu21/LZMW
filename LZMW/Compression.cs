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


            string SpS = null;
            string S = null;
            string Sp = null;

            
            List<int> output = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {

                string c = input[i].ToString();
                var matches = dict.Count(x => x.Key.Contains(c));
                if(matches > 1)
                {
                    string cs = null;
                    for (int j = i+1 ; j < matches ; j++)
                    {
                        cs = c + input[j];
                        var match = dict.Count(x => x.Key.Contains(cs));
                        if (match == 1)
                        {
                            S = cs;
                            output.Add(dict[S]);

                        }
                        else if (match > 1)
                        {
                            c = cs;
                            continue;
                        }
                        else if (match == 0)
                        {
                            S = c;
                            output.Add(dict[S]);
                        }
                        
                    }

                }
                else
                {

                    S = c;
                    output.Add(dict[S]);
                }

                SpS = S + Sp;

                if (dict.ContainsKey(SpS))
                {

                    dict.Add(SpS, dict.Count());
                    Sp = S;

                }
                else
                {

                    Sp = S;
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
