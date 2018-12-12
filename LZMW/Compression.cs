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
            dict = DictInitialize.DictionaryInit();
        }

        public List<byte> Compress(string input)
        {


            string matchConcatenation = null; // spoprzednie dopasowanie plus aktualne dopasowanie
            string currentMatch = null; //aktualne dopasowanie
            string previousMatch = null; //poprzednie dopasowanie

            
            List<byte> output = new List<byte>();

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
                        int match = dict.Count(x => x.Key.Contains(signsConcatenation));

                        if (match == 1)
                        {
                            if (dict.Any(x => string.Compare(x.Key, signsConcatenation, StringComparison.OrdinalIgnoreCase) == 0))
                            {
                                currentMatch = signsConcatenation;
                                output.Add((byte)dict[currentMatch]);
                                break;
                            }
                            else
                            {
                                currentMatch = currentSign;
                                output.Add((byte)dict[currentMatch]);
                                break;
                            }

                        }
                        else if (match > 1)
                        {
                            currentSign = signsConcatenation;
                            continue;
                        }
                        else if (match == 0)
                        {
                            currentMatch = currentSign;
                            output.Add((byte)dict[currentMatch]);
                            break;
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
                    previousMatch = currentMatch;

                }
                else
                {

                    previousMatch = currentMatch;
                }


            }

            return output;

        }




    }
}
