using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

namespace ConcatTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables to set iterations and track times
            int operationIts = 1000;
            int collectionIts = 100000;
            Stopwatch sw = new Stopwatch();
            // path and reader for file input
            string inFilePath = @"c:\repos\RopeTests\foxText.txt";
            StreamReader readFile = new StreamReader(inFilePath);
            // path and reader for file output
            // string outFilePath = @"c:\repos\RopeTests\TODO";
            // StreamWriter writeFile = new StreamWriter(TODO);

            // read in small string file; create data structures to be tested
            string stringSmall = File.ReadAllText(inFilePath);
            Console.WriteLine(stringSmall.ToString());
            Console.ReadLine();
            // Stringbuilder only has append, insert, remove and replace
            StringBuilder builderSmall = new StringBuilder();
            // BigList doesn't have a concat either
            BigList<string> biglistSmall = new BigList<string>();
            // LeapRope<string> leapSmall; -- placeholder for rope structure

            // fill structures with initial instance of string
            builderSmall.Append(stringSmall);
            biglistSmall.Add(stringSmall);

            // build a collection of strings
            sw.Start();
            for (int i = 0; i < collectionIts; i++)
            {
                builderSmall.Append(stringSmall);
            }
            sw.Stop();
            long timeBuilderCollection = sw.ElapsedMilliseconds;

            // test concatenations of structures
            string testString = "";
            sw.Start();
            for (int i = 0; i < operationIts; i++)
            {
                // test of simple string concatenation
                // testString = string.Concat(testString, stringSmall);
                testString = string.Concat(testString, builderSmall[i]); // this returns i chars
            }
            sw.Stop();
            long timeStringConcat = sw.ElapsedMilliseconds;

            // View contents of structures
            Console.WriteLine("String concatenation - " + operationIts + " iterations: " + timeStringConcat + " ms");
            //Console.WriteLine("Stringbuilder contents: " + builderSmall.ToString());
            Console.WriteLine("String contents: " + testString.ToString());
            Console.WriteLine("Collection building - " + collectionIts + " iterations: " + timeBuilderCollection + " ms");
            Console.WriteLine("Stringbuilder length: " + builderSmall.Length);
            Console.WriteLine("Small string length: " + stringSmall.Length + " times stringbuilder: " + (stringSmall.Length * collectionIts));
            Console.ReadLine();
        }
    }
}
