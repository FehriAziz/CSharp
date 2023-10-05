using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
  class Program
  {
    static void Main(string[] args)
    {
      //Create an array to hold integer values 0 through 9
      int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      Console.WriteLine(numArray);

      // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
      string[] stringArray;
      stringArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };
      Console.WriteLine(stringArray);

      // Create an array of length 10 that alternates between true and false values, starting with true
      bool[] boolArray = new bool[10];
      boolArray[0] = true;
      boolArray[1] = false;
      boolArray[2] = true;
      boolArray[3] = false;
      boolArray[4] = true;
      boolArray[5] = false;
      boolArray[6] = true;
      boolArray[7] = false;
      boolArray[8] = true;
      boolArray[9] = false;
      Console.WriteLine(boolArray);
      // 		Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
      List<string> iceCream = new List<string>();
      iceCream.Add("Chocolate");
      iceCream.Add("Matcha");
      iceCream.Add("Durian");
      iceCream.Add("Longan");
      iceCream.Add("Black Sesame");
      iceCream.Add("Chocolate Vanilla");
      // Output the length of this list after building it
      Console.WriteLine($"The length of the iceCream list string is {iceCream.Count}.");
      // Output the third flavor in the list, then remove this value
      Console.WriteLine($"The third flavor of this list is {iceCream[2]}.");
      iceCream.Remove(iceCream[2]);
      // Output the new length of the list (It should just be one fewer!)
      Console.WriteLine($"The length of the iceCream list is now {iceCream.Count}.");

      // Create a dictionary that will store both string keys as well as string values
      Dictionary<string, string> iceCreamLovers = new Dictionary<string, string>();
      // Add key/value pairs to this dictionary where:
      // each key is a name from your names array
      // each value is a randomly select a flavor from your flavors list.
      Random rand = new Random();
      iceCreamLovers.Add(stringArray[0], iceCream[rand.Next(0, 4)]);
      iceCreamLovers.Add(stringArray[1], iceCream[rand.Next(0, 4)]);
      iceCreamLovers.Add(stringArray[2], iceCream[rand.Next(0, 4)]);
      iceCreamLovers.Add(stringArray[3], iceCream[rand.Next(0, 4)]);

      // Loop through the dictionary and print out each user's name and their associated ice cream flavor
      foreach (var item in iceCreamLovers)
      {
        Console.WriteLine(item.Key + " - " + item.Value);
      }
    }
  }
}
