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
            bool last = false;


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

                        signsConcatenation = currentSign + input[j];

                        if (i + signsConcatenation.Length >= input.Length)
                        {
                            for (int z = currentSign.Length - 1; z >= 0; z--)
                            {
                                currentMatch = currentSign.Remove(z);
                                if (dict.Any(x => string.Compare(x.Key, currentMatch, StringComparison.Ordinal) == 0))
                                {
                                    output.Add(dict[currentMatch]);
                                    break;

                                }
                            }
                            break;
                        }

                        int match = dict.Count(x => x.Key.Contains(signsConcatenation));



                        if (match == 1 || match == 0 || j == input.Length - 1)
                        {
                            if (dict.Any(x => string.Compare(x.Key, signsConcatenation, StringComparison.Ordinal) == 0))
                            {
                                currentMatch = signsConcatenation;
                                output.Add(dict[currentMatch]);
                                break;
                            }
                            else if (dict.Any(x => string.Compare(x.Key, currentSign, StringComparison.Ordinal) == 0))
                            {
                                currentMatch = currentSign;
                                output.Add(dict[currentMatch]);
                                break;
                            }
                            else
                            {
                                for (int z = currentSign.Length - 1; z >= 0; z--)
                                {
                                    currentMatch = currentSign.Remove(z);
                                    if (dict.Any(x => string.Compare(x.Key, currentMatch, StringComparison.Ordinal) == 0))
                                    {
                                        output.Add(dict[currentMatch]);
                                        break;

                                    }
                                }
                                break;

                            }

                        }
                        else if (match > 1)
                        {
                            currentSign = signsConcatenation;
                            continue;
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

                //if (last == true)
                //{
                //    break;
                //}

                //if (i + currentMatch.Length >= input.Length)
                //{
                //    i = input.Length - 1;
                //    last = true;
                //}
                //else
                //{
                //    i += currentMatch.Length;
                //}

                //if (last == true)
                //{
                //    break;
                //}
                //else if (i + currentMatch.Length < input.Length)
                //{
                //    i += currentMatch.Length;
                //}

                //{
                //    for (int c = currentMatch.Length - 1; c > 0; c--)
                //    {
                //        if (i + c < input.Length)
                //        {
                //            i += c;
                //            last = true;
                //            break;
                //        }
                //    }
                //}
                

                //Console.WriteLine(dict[currentMatch]);

            }

            //Console.ReadKey();

            return output;

        }




    }
}
