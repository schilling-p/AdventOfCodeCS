using System;
using System.IO;

// Task:
// I am given a list of numbers like the one in calories.txt
// Each consecutive stream of numbers represents one reindeer
// Which one has the most calories and how many does it have?

public class Day1
{

    public static void Main()
    {
        List<int> values = new List<int>();

        string? oneLine;
        StreamReader reader = new StreamReader("/Users/paulschilling/Dokumente/Studium/Coding/C#/AdventOfCodeCs/Day1/calories.txt");

        oneLine = reader.ReadLine();

        while (oneLine != null)
        {
            int result;

            if (oneLine == "")
            {
                result = 0;
            }
            else
            {
                result = Int32.Parse(oneLine);
            }
            
            values.Add(result);

            oneLine = reader.ReadLine();
        }

        int currentElf = 1;
        int totalCalories = 0;
        Dictionary<int, int> elfCalories = new Dictionary<int, int>();

        foreach (int calories in values)
        {

            if (calories == 0)
            {
                elfCalories.Add(currentElf, totalCalories);

                currentElf++;
                totalCalories = 0;
            }

            else
            {
                totalCalories += calories;
            }
        }

        elfCalories.Add(currentElf, totalCalories);

        List<int> winner = new List<int>(FindElfWithMostCalories(elfCalories));

        List<int> FindElfWithMostCalories(Dictionary<int, int> elfDictionary)
        {
            int elfWithMostCalories = elfDictionary.First().Key;
            foreach (KeyValuePair<int, int> pair in elfDictionary)
            {
                if (pair.Value > elfDictionary[elfWithMostCalories])
                {
                    elfWithMostCalories = pair.Key;
                }
            }

            List<int> winner = new List<int>();
            winner.Add(elfWithMostCalories);
            winner.Add(elfDictionary[elfWithMostCalories]);

            return winner;
        }

        Console.WriteLine($"The Elf with the most calories is Elf #{winner[0]} with a total of {winner[1]}.");

        reader.Close();
    }
}
