/*

DAY3 - RUCKSACKS AND COMPARTMENTS

Input:
    - multiple sequences of characters
    - each sequence represents 1 Rucksack
    - each sequence's half of items represent a compartment

Sequence of steps:
    - take the input and split it in half to get the compartments
    - find the element that occurs in both compartments
    - for that element, find a priority
        - a - z = 1 - 26
        - A - Z = 27 - 52
    - add up all the priorities and return the value

Output:
    - integer that is the sum of the priorities


 */

public class Solution
{
    public static void Main()
    {
        string? oneLine;
        StreamReader reader = new StreamReader("/Users/paulschilling/Dokumente/Studium/Coding/C#/AdventOfCodeCs/Day3/Day3/backpacks.txt");
        oneLine = reader.ReadLine();

        List<string> backpacks = new List<string>();

        while (oneLine != null)
        {
            backpacks.Add(oneLine);
            oneLine = reader.ReadLine();
        }

        List<string> halves = new();

        /*

        I need a nice way to split a string in half and I don't know how to do that yet
            - maybe add all the individual chars to a list and split that one in half
            - then do the comparison thing on it

         */


        foreach (string backpack in backpacks)
        {
            int middleOfString = backpack.Length / 2;
            int currentPosition = 0;
            string? firstHalf = null;
            string? secondHalf = null;

            firstHalf += backpack.Min<char>();
            currentPosition += 1;

        }



        foreach (string half in halves)
        {
            Console.WriteLine(half);

        }
    }
}