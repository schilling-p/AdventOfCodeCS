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
        // this is a list that contains each of the input strings as a list of individual characters
        // [ [s,t,r,i,n,g], [i,n,t,e,g,e,r,s] ]
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
        // - [ [ [s,t,r], [i,n,g], [i,n,t,e], [g,e,r,s] ] ]
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

            foreach (char character in stringList.GetRange(middle, middle))
            {
                secondHalf.Add(character);
            }

            halves.Add(fistHalf);
            halves.Add(secondHalf);

            return halves;
        }
        /*
        List<char> testList1 = new List<char>{'a', 'b', 'c', 'd', 'e'};
        List<char> testList2 = new List<char>{'f', 'g', 'h', 'i', 'e'};
        char testing = GetSharedLetterInTwoLists(testList1, testList2);
        Console.WriteLine(testing);
        
        foreach (List<List<char>> stringContainingTwoHalves in halvesOfStrings)
        {
            Console.WriteLine("\nNew string: ");
            foreach (List<char> half in stringContainingTwoHalves)
            {
                Console.WriteLine("\n\tNew half: ");
                foreach (char letter in half)
                {
                    Console.Write(letter);
                }
            }
        }
        */
        
        // Compare each adjacent halves with each other and see which item is in both of them
        List<char> GetSharedLetters(List<List<List<char>>> halvesList)
        {
            List<char> listOfSharedLetters = new();

            foreach (List<List<char>> stringList in halvesList)
            {
                listOfSharedLetters.Add(GetSharedLetterInTwoLists(stringList[0],stringList[1]));
            }

            return listOfSharedLetters;
        }
        
        char GetSharedLetterInTwoLists(List<char> input1, List<char> input2)
        {
            char sharedLetter = 'D';

            foreach (char letter in input1)
            {
                if (input2.Contains(letter))
                {
                    sharedLetter = letter;
                }
            }
            
            return sharedLetter;
        }
        
        // building the lookup dictionary with ASCII values
        Dictionary<char, int> priorityDictionary = new();
        for (int i = 97; i <= 122; i++)
        {
            char letter = (char)i;
            int number = i - 96;
            priorityDictionary[letter] = number;
        }

        for (int i = 65; i <= 90; i++)
        {
            char letter = (char)i;
            int number = i - 38;
            priorityDictionary[letter] = number;
        }
        
        // This is a list that contains the letters that are in both compartments for each backpack
        List<char> sharedLettersOfBackpacks = GetSharedLetters(halvesOfStrings);
        foreach (char letter in sharedLettersOfBackpacks)
        {
            Console.Write(letter);
        }

        Console.WriteLine($"The sum of the priorities is: {GetSumOfPriorities(sharedLettersOfBackpacks, priorityDictionary)}");

        int GetSumOfPriorities(List<char> letterList, Dictionary<char, int> priorityLookUp)
        {
            int priority = 0;

            foreach (char letter in letterList)
            {
                priority += priorityLookUp[letter];
            }

            return priority;
        }
        
        


    }
}