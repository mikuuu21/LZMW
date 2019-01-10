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


            List<int> output = new List<int>();
            Console.WriteLine("start...");
            for (int i = 0; i < input.Length; i += currentMatch.Length)
            {
               
                string currentSign = null;

                currentSign = input[i].ToString();
                Console.WriteLine("iteracja: " + i + " input: " +currentSign);
                Console.WriteLine("Dopasowania...");

                int matches = dict.Count(x => x.Key.Contains(currentSign));

                Console.WriteLine("liczba dopasowań: " + matches);

            
                if (matches > 1 && i + 1 < input.Length)
                {
                    string signsConcatenation = null;
                    Console.WriteLine("Znajdowanie najdłuższego dopasowania...");

                    for (int j = i + 1; j < input.Length; j++)
                    {
                        Console.WriteLine("iteracja j: " + j);
                        signsConcatenation = currentSign + input[j];
                        Console.WriteLine("obecna litera + następna: " + signsConcatenation);
                        int match = dict.Count(x => x.Key.Contains(signsConcatenation));
                        Console.WriteLine("liczba dopasowań połączenia liter: " + match );
                        if (match == 1 || match == 0)
                        {
                            Console.WriteLine("sprawdzanie dopasować dla match == 1||0");

                            if (dict.Any(x => string.Compare(x.Key, signsConcatenation, StringComparison.Ordinal) == 0))
                            {
                                Console.WriteLine("słowo jest dopasowane dokładnie jeden raz");
                                currentMatch = signsConcatenation;
                                Console.WriteLine("currentMatch = " + signsConcatenation);
                                output.Add(dict[currentMatch]);
                                Console.WriteLine("output: " + dict[currentMatch] + "koniec szukania najdłuższego dopasowania");
                                break;
                            }
                            else if (dict.Any(x => string.Compare(x.Key, currentSign, StringComparison.Ordinal) == 0))
                            {
                                Console.WriteLine("Dopasowanie currentSign: " + currentSign);
                                currentMatch = currentSign;
                                output.Add(dict[currentMatch]);
                                Console.WriteLine("output: " + dict[currentMatch] + "koniec szukania najdłuższego dopasowania");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Połączone słowo ani obecne nie było w słowniku więc szukamy cofając...");
                                for (int z = currentSign.Length - 1; z == 0; z--)
                                {
                                    Console.WriteLine("iteracja z: " + z);
                                    currentMatch = currentSign.Remove(z);
                                    Console.WriteLine("obecne słowo " + currentMatch);
                                    if (dict.Any(x => string.Compare(x.Key, currentMatch, StringComparison.Ordinal) == 0))
                                    {
                                        Console.WriteLine("Dopasowanie słowa: " + currentMatch);
                                        output.Add(dict[currentMatch]);
                                        Console.WriteLine("output: " + dict[currentMatch] + " koniec szukania najdłuższego dopasowania");
                                      
                                        break;

                                    }
                                }

                            }

                        }
                        else if (match > 1)
                        {
                            Console.WriteLine("match > 1");
                            currentSign = signsConcatenation;
                            continue;
                        }

                    }

                }
                else
                {
                    Console.WriteLine("dopasowanie aktualnego znaku z input...");
                    currentMatch = currentSign;
                    
                    output.Add((byte)dict[currentMatch]);
                    Console.WriteLine("output: " + dict[currentMatch]);
                }


                matchConcatenation = previousMatch + currentMatch;
                Console.WriteLine("MatchConcatenation: " + matchConcatenation);

                if (!dict.ContainsKey(matchConcatenation))
                {

                    dict.Add(matchConcatenation, dict.Count());
                    Console.WriteLine("Dodanie do słownika: " + matchConcatenation);

                }


                previousMatch = currentMatch;

                Console.WriteLine("previousMatch = currentMatch");

            }

            Console.ReadLine();

            return output;

        }




    }
}
