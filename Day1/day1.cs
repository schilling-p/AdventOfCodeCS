// Task:
// I am given a list of numbers like the one in calories.txt
// Each consecutive stream of numbers represents one reindeer
// Which one has the most calories and how many does it have?

public class Day1
{

    public static void Main()
    {
        string? oneLine;
        StreamReader reader = new StreamReader("/Users/paulschilling/Dokumente/Studium/Coding/C#/AdventOfCodeCs/Day1/calories.txt");

        oneLine = reader.ReadLine();

        List<int> values = new();

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

        // generic method to build a dictionary out of the input given
        Dictionary<int, int> BuildElfDictionay(List<int> values)
        {
            Dictionary<int, int> elfCalories = new();

            int currentElf = 1;
            int totalCalories = 0;

            foreach (int value in values)
            {
                if (value == 0)
                {
                    elfCalories.Add(currentElf, totalCalories);

                    currentElf++;
                    totalCalories = 0;
                }

                else
                {
                    totalCalories += value;
                }
            }

            elfCalories.Add(currentElf, totalCalories);

            return elfCalories;
        }

        //build a list of the 3 biggest elements of a dictionary
        List<int> FindTopThreeElfesWithMostCalories(Dictionary<int, int> elfDictionary)
        {
            List<int> topthree = new();

            while (topthree.Count < 3)
            {

                int elfWithMostCalories = 1;

                foreach (KeyValuePair<int, int> pair in elfDictionary)
                {
                    if (pair.Value > elfDictionary[elfWithMostCalories])
                    {
                        elfWithMostCalories = pair.Key;
                    }
                }

                topthree.Add(elfDictionary[elfWithMostCalories]);
                elfDictionary.Remove(elfWithMostCalories);

            }            

            return topthree;
        }

        Dictionary<int, int> elfesAndCalories = BuildElfDictionay(values);

        List<int> topThreeElfsWithMostCalories = new(FindTopThreeElfesWithMostCalories(elfesAndCalories));

        // the solving of the puzzle
        int sumOfTopThree = 0;

        foreach (int calories in topThreeElfsWithMostCalories)
        {
            sumOfTopThree += calories;
        }

        Console.WriteLine(sumOfTopThree);

        reader.Close();
    }
}
