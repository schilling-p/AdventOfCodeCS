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

using System.Reflection;

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

        /*

        I need a nice way to split a string in half and I don't know how to do that yet
            - maybe add all the individual chars to a list and split that one in half
            - then do the comparison thing on it

         */


        // this is a list that contains each of the input strings as a list of individual characters
        List<List<char>> characterList = new();

        foreach (string backpack in backpacks)
        {
            characterList.Add(ReturnStringAsListOfChars(backpack));
        }

        List<char> ReturnStringAsListOfChars(string input)
        {
            List<char> stringAsChar = new();
            foreach (char letter in input)
            {
                stringAsChar.Add(letter);
            }

            return stringAsChar;
        }

        // list of all the halves of strings
        List<List<List<char>>> halvesOfStrings = new();

        foreach (List<char> listOfCharacters in characterList)
        {
            halvesOfStrings.Add(SplitListOfCharsInHalf(listOfCharacters));
        }

        List<List<char>> SplitListOfCharsInHalf(List<char> stringList)
        {
            List<List<char>> halves = new();
            List<char> fistHalf = new();
            List<char> secondHalf = new();

            int middle = stringList.Count / 2;

            foreach (char character in stringList.GetRange(0, middle))
            {
                fistHalf.Add(character);
            }

            foreach (char character in stringList.GetRange(middle, count: middle))
            {
                secondHalf.Add(character);
            }

            halves.Add(fistHalf);
            halves.Add(secondHalf);

            return halves;
        }
        /*
        foreach (char letter in stringList)
        {
            int middle = stringList.Count / 2;


            /*
            if (stringList.IndexOf(letter) < middle)
            {
                fistHalf.Add(letter);
            }
            else if (stringList.IndexOf(letter) == middle)
            {
                secondHalf.Add(letter);
            }
            else
            {
                secondHalf.Add(letter);
            }
            */
        /*

        Current implementation:

        Say we get the strings: "string" and "integers"

        STEPS:
        first:
            - [string, integers]
        second:
            - [ [s,t,r,i,n,g], [i,n,t,e,g,e,r,s] ]
        third:
            - [ [ [s,t,r], [i,n,g], [i,n,t,e], [g,e,r,s] ] ]

         */

        // Compare each adjacent halves with each other and see which item is in both of them

        foreach (List<List<char>> stringContainningTwoHalves in halvesOfStrings)
        {
            Console.WriteLine("\nNew string: ");
            foreach (List<char> half in stringContainningTwoHalves)
            {
                Console.WriteLine("\n\tNew half: ");
                foreach (char letter in half)
                {
                    Console.Write(letter);
                }
            }
        }
    }
}