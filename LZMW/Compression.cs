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

        //public Compression()
        //{
        //    DictBuilder table = new DictBuilder();

        //    dict = table.Dictionary;
        //}

        public Compression()
        {
            dict = DictInitialize.CompressDictionaryInit();
        }

        public List<int> Compress(string input)
        {


            //string w = string.Empty;
            //List<int> compressed = new List<int>();

            //foreach (char c in input)
            //{
            //    string wc = w + c;
            //    if (dict.ContainsKey(wc))
            //    {
            //        w = wc;
            //    }
            //    else
            //    {
            //        // write w to output
            //        compressed.Add(dict[w]);
            //        // wc is a new sequence; add it to the dictionary
            //        dict.Add(wc, dict.Count);
            //        w = c.ToString();
            //    }
            //}

            //// write remaining output if necessary
            //if (!string.IsNullOrEmpty(w))
            //    compressed.Add(dict[w]);

            //return compressed;


            string matchConcatenation = null; // spoprzednie dopasowanie plus aktualne dopasowanie
            string currentMatch = null; //aktualne dopasowanie
            string previousMatch = null; //poprzednie dopasowanie


            //for (var i = 0; i < 256; i++)
            //{
            //    var e = new List<byte> { (byte)i };
            //   // dictionary.Add(i, e);
            //}
            List<int> output = new List<int>();

            for (int i = 0; i < input.Length; i += currentMatch.Length)
            {
                string currentSign = null;

                currentSign = input[i].ToString();

                int matches = dict.Count(x => x.Key.Contains(currentSign));

                if (matches > 1 && i + 1 < input.Length)
                {
                    string signsConcatenation = null;


                    for (int j = i + 1; j < input.Length; j++)
                    {
                        int match = 0;

                        signsConcatenation = currentSign + input[j];

                        if ((dict.Any(x => string.Compare(x.Key, signsConcatenation, StringComparison.Ordinal) == 0)))
                        {
                             match = dict.Count(x => x.Key.Contains(signsConcatenation));
                        }


                        if (match == 1 || match == 0)
                        {
                            if (dict.Any(x => string.Compare(x.Key, signsConcatenation, StringComparison.Ordinal) == 0))
                            {
                                currentMatch = signsConcatenation;
                                output.Add(dict[currentMatch]);
                                break;
                            }
                            else /*if (dict.Any(x => string.Compare(x.Key, currentSign, StringComparison.Ordinal) == 0))*/
                            {
                                currentMatch = currentSign;
                                output.Add(dict[currentMatch]);
                                break;
                            }
                            //else
                            //{
                            //    for (int z = currentSign.Length -1;z == 0 ;z--)
                            //    {
                            //        currentMatch = currentSign.Remove(z);
                            //        if (dict.Any(x => string.Compare(x.Key, currentMatch, StringComparison.Ordinal) == 0))
                            //        {
                            //            output.Add(dict[currentMatch]);
                            //            break;

                            //        }
                            //    }

                            //}

                        }
                        else if (match > 1)
                        {
                            currentSign = signsConcatenation;
                            continue;
                        }

                        else if (match == 0)
                        {
                            //if (dict.Any(x => string.Compare(x.Key, currentSign, StringComparison.Ordinal) == 0))
                            //{
                                currentMatch = currentSign;
                                output.Add(dict[currentMatch]);
                                break;
                            //}
                            //else
                            //{
                            //    for (int z = currentSign.Length - 1; z == 0; z--)
                            //    {
                            //        currentMatch = currentSign.Remove(z);
                            //        if (dict.Any(x => string.Compare(x.Key, currentMatch, StringComparison.Ordinal) == 0))
                            //        {
                            //            output.Add(dict[currentMatch]);
                            //            break;

                            //        }

                            //    }
                            //}


                        }

                    }

                }
                else
                {
                    currentMatch = currentSign;
                    output.Add((byte)dict[currentMatch]);
                }

                matchConcatenation = previousMatch + currentMatch;


                if (!dict.ContainsKey(matchConcatenation))
                {

                    dict.Add(matchConcatenation, dict.Count());


                }


                previousMatch = currentMatch;

                //Console.WriteLine(dict[currentMatch]);

            }

            //Console.ReadKey();

            return output;

        }




    }
}
