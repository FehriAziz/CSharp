using System;
using System.Collections.Generic;

// Puzzles
// The following problems are just continuing practice on all the things we have learned so far.

// Random Array
// Create a function called RandomArray() that returns an integer array

// Place 10 random integer values between 5-25 into the array
// Print the min and max values of the array
// Print the sum of all the values
// Coin Flip
// Create a function called TossCoin() that returns a string

// Have the function print "Tossing a Coin!"
// Randomize a coin toss with a result signaling either side of the coin 
// Have the function print either "Heads" or "Tails"
// Finally, return the result
// Create another function called TossMultipleCoins(int num) that returns a Double

// Have the function call the tossCoin function multiple times based on num value
// Have the function return a Double that reflects the ratio of head toss to total toss
// Names
// Build a function Names that returns a list of strings.  In this function:

// Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
// Shuffle the list and print the values in the new order
// Return a list that only includes names longer than 5 characters

namespace Puzzles
{
    class Program
    {

        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] result = { rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26), rand.Next(5, 26) };
            int min = result[0];
            int max = result[0];
            int sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] > max)
                {
                    max = result[i];
                }
                if (result[i] < min)
                {
                    min = result[i];
                }
                sum += result[i];
            }
            foreach (int num in result)
            {
                System.Console.WriteLine(num);
            }
            System.Console.WriteLine($"MAX: {max}  MIN: {min}  SUM: {sum}");
            return result;
        }

        public static string TossCoin()
        {
            System.Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            string result = "";
            if (rand.Next(0, 2) == 0)
            {
                result = "Heads";
                System.Console.WriteLine(result);
            }
            else
            {
                result = "Tails";
                System.Console.WriteLine(result);
            }
            return result;
        }

        public static double TossMultipleCoins(int num)
        {
            double result = 0;
            int heads = 0;
            for (int i = 1; i <= num; i++)
            {
                if (TossCoin() == "Heads")
                {
                    heads++;
                }
            }
            result = (double)heads / (double)num;
            return result;
        }


        public static List<string> Names(List<string> test)
        {
            List<string> result = new List<string>();

            Random rnd = new Random();
            for (int i = 0; i < test.Count; i++)
            {
                int k = rnd.Next(0, i);
                string value = test[k];
                test[k] = test[i];
                test[i] = value;
            }

            foreach (string name in test)
            {
                System.Console.WriteLine(name);
            }

            foreach (string name in test)
            {
                if (name.Length > 5)
                {
                    result.Add(name);
                }
            }
            // foreach (string name in result)
            // {
            //     System.Console.WriteLine(name);
            // }
            return result;
        }

        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            System.Console.WriteLine("Now tossing multiple coins");
            System.Console.WriteLine(TossMultipleCoins(5));

            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");

            Names(names);
        }
    }
}
