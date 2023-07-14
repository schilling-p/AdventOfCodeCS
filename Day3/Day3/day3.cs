/*

DAY3 - RUCKSACKS AND COMPARTMENTS - Part 1

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


DAY3 - RUCKSACKS AND COMPARTMENTS - Part 2

What changed?
    - 3 Rucksacks in a row represent 3 elves that are in a group
    - Instead of finding the item that is present in both halves of one elves' backpack,
    I need to find the element that is present in 3 each other following backpacks,
    meaning I need to view them as whole backpacks
    
Input:
    - did not change

Sequence of Steps:
    - instead of making sub lists of halves I will now do sub lists that contain 3 backpacks
    - find the common element and calculate the priorities
    - sum up the priorities

Output:
    - did not change

 */

/*
Implementation:

Say we get the strings: "string" and "integers", "characters"

STEPS:
first:
    - [string, integers, characters]
second:
    - [ [ [s,t,r,i,n,g], [i,n,t,e,g,e,r,s], [ c,h,a,r,a,c,t,e,r,s ] ], [ new list of 3 backpacks] ]
third:
    - [ [ [s,t,r], [i,n,g], [i,n,t,e], [g,e,r,s] ] ]

 */

public class Solution
{
    public static void Main()
    {
        StreamReader reader = new StreamReader("/Users/paulschilling/Dokumente/Studium/Coding/C#/AdventOfCodeCs/Day3/Day3/backpacks.txt");
        string? oneLine = reader.ReadLine();

        List<string> backpacks = new List<string>();

        while (oneLine != null)
        {
            backpacks.Add(oneLine);
            oneLine = reader.ReadLine();
        }
        // this is a list that contains each of the input strings as a list of individual characters
        // [ [s,t,r,i,n,g], [i,n,t,e,g,e,r,s], [r,e,a,d,e,r], [o,n,e,l,i,n,e], [b,a,c,k,p,a,c,k], [l,i,s,t] ]
        List<List<char>> stringsAsCharactersList = new();

        foreach (string backpack in backpacks)
        {
            stringsAsCharactersList.Add(ReturnStringAsListOfChars(backpack));
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

        // Goal:
        // build a new list that groups together 3 adjacent elements of the characterList
        // [ [ [s,t,r,i,n,g], [i,n,t,e,g,e,r,s], [r,e,a,d,e,r] ], [ [o,n,e,l,i,n,e], [b,a,c,k,p,a,c,k], [l,i,s,t] ] ]

        // List that contains groups of 3 strings, each of which are lists of characters
        List<List<List<char>>> groupsOfThree = new();

        while (stringsAsCharactersList.Any())
        {
            int counter = 0;
            List<List<char>> oneGroupOfThreeStrings = new();
            
            while (counter < 3)
            {
                oneGroupOfThreeStrings.Add(stringsAsCharactersList[0]);
                stringsAsCharactersList.RemoveAt(0);
                counter += 1;
            }
            
            groupsOfThree.Add(oneGroupOfThreeStrings);
        }


        //PRINTING THE ELEMENTS OF 3 NESTED LISTS OUT:
        foreach (List<List<char>> groupOfThree in groupsOfThree)
        {
            Console.WriteLine("\nNew group: ");
            foreach (List<char> half in groupOfThree)
            {
                Console.WriteLine("New Third");
                foreach (char letter in half)
                {
                    Console.Write(letter);
                }
            }
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
        List<char> sharedLettersOfBackpacks = GetSharedLetters(groupsOfThree);
        foreach (char letter in sharedLettersOfBackpacks)
        {
            Console.Write(letter);
        }

        Console.WriteLine($"The sum of the priorities is: {GetSumOfPriorities(sharedLettersOfBackpacks, priorityDictionary)}");

        int GetSumOfPriorities(List<char> letterList, Dictionary<char, int> priorityLookUp)
        {
            int sumOfPriorities = 0;

            foreach (char letter in letterList)
            {
                sumOfPriorities += priorityLookUp[letter];
            }

            return sumOfPriorities;
        }
        
        
        // Compare each adjacent halves with each other and see which item is in both of them
        List<char> GetSharedLetters(List<List<List<char>>> listOfGroupsOfThree)
        {
            List<char> listOfSharedLetters = new();

            foreach (List<List<char>> groupOfThree in listOfGroupsOfThree)
            {
                listOfSharedLetters.Add(GetSharedLetterInGroupOfThreeLists(groupOfThree[0],groupOfThree[1], groupOfThree[2]));
            }

            return listOfSharedLetters;
        }
        
        char GetSharedLetterInGroupOfThreeLists(List<char> input1, List<char> input2, List<char> input3)
        {
            char sharedLetter = 'D';

            foreach (char letter in input1)
            {
                if (input2.Contains(letter) && input3.Contains(letter))
                {
                    sharedLetter = letter;
                }
            }
            
            return sharedLetter;
        }

    }
}