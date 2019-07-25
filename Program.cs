// Daft Punk's song 'Harder, Better, Faster, Stronger',
// Original C# Code by  Wil Dobson (wdobson@pixelsyndicate.com) 
// https://github.com/pixelsyndicate/DaftPunkLyrics
// Original JavaScript programmer unknown

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PontusDacke.DaftPunkHBFSLyrics
{
    class Program
    {
        static Dictionary<Expression<Func<int, bool>>, Func<string, string>> everAfterWorkIsOver 
            = new Dictionary<Expression<Func<int, bool>>, Func<string, string>>
            {
                { a => a == 0, s => s },
                { a => true, s => "" }
            };

        static Dictionary<Expression<Func<int, bool, bool, bool>>, Func<string, string, string>> workItDoItHarderBetterFasterStrongerMakeItMakesUs
            = new Dictionary<Expression<Func<int, bool, bool, bool>>, Func<string, string, string>>
            {
                { (i, skip14th, firstTwo) => i <= 1, (s1, s2) => s1 },
                { (i, skip14th, firstTwo) => skip14th && i == 14, (s1, s2) => "" },
                { (i, skip14th, firstTwo) => !firstTwo && true, (s1, s2) => s1 + s2 },
                { (i, skip14th, firstTwo) => firstTwo, (s1, s2) => "" },
            };

        static Dictionary<Expression<Func<int, bool>>, Func<string, string, string>> moreThanHourOurNever 
            = new Dictionary<Expression<Func<int, bool>>, Func<string, string, string>>
            {
                { a => a == 0, (s1, s2) => s1 },
                { a => a == 1, (s1, s2) => "" },
                { a => true, (s1, s2) => s1 + s2 }
            };

        static void Main(string[] args)
        {
            Console.WriteLine(" - Daft Punk Lyrics - ");
            WorkIt();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        private static void WorkIt()
        {
            for (int k = 0; k < 16; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                Better(j, k, "Work it ", "Harder ", "More than ", "Ever ", false);
                                break;
                            case 1:
                                Better(j, k, "Make it ", "Better ", "Hour ", "After ", true);
                                break;
                            case 2:
                                Better(j, k, "Do it ", "Faster ", "Our ", "Work is ", false);
                                break;
                            case 3:
                                Better(j, k, "Makes us ", "Stronger ", "Never ", "Over ", true);
                                break;
                        }
                    }
                }
            }
        }

        private static void Better(int j, int k, string a, string b, string c, string d, bool skip14th)
        {
            switch (j)
            {
                case 0:
                    Console.WriteLine(workItDoItHarderBetterFasterStrongerMakeItMakesUs.First(x => x.Key.Compile()(k, skip14th, false)).Value(a, b));
                    break;
                case 1:
                    Console.WriteLine(workItDoItHarderBetterFasterStrongerMakeItMakesUs.First(x => x.Key.Compile()(k, false, true)).Value(b, ""));
                    break;
                case 2:
                    Console.WriteLine(moreThanHourOurNever.First(x => x.Key.Compile()(k)).Value(c, d));
                    break;
                case 3:
                    Console.WriteLine(everAfterWorkIsOver.First(x => x.Key.Compile()(k)).Value(d));
                    break;
            }
        }
    }
}