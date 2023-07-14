/*
 Day4 of the Advent of Code Challenge

Input:
    - there will be a list of pairs of ranges such as 2-4, 6-8
    - the numbers represent sections that the elf shall clean
    - it is meant to be inclusive, meaning that 2 - 4 represents 2,3,4
    
Output:
    - for which of the pairs of the two elves does 1 fully contain the sections of the other?
    - output will be the number of times that has happened ( integer )

Sequence of Steps:
    - read the puzzle input
    - create a list of lists where each nested list contains 1 pair
        - [[2-4, 6-8], [2-4, 4-5]]

Context of Execution:
    - I can expect the input to consist of integers only
 */


using System.Xml.XPath;

namespace Day4
{
    class Solution
    {
        public static void Main()
        {
            StreamReader reader =
                new StreamReader(
                    "/Users/paulschilling/Dokumente/Studium/Coding/C#/AdventOfCodeCs/Day4/Day4/section_assignments.txt");
            string? oneLine = reader.ReadLine();
            List<string> sectionPairs = new();
            while (oneLine != null)
            {
                sectionPairs.Add(oneLine);
                oneLine = reader.ReadLine();
            }

            List<string[]> listOfSectionsAsStrings = new List<string[]>();
            List<int[]> listOfSections = new List<int[]>();
            char[] delimiters = { ',', '-' };
            
            foreach (string sectionPair in sectionPairs)
            {
                string[] sectionPairNumbersAsStrings = sectionPair.Split(delimiters);

                listOfSectionsAsStrings.Add(sectionPairNumbersAsStrings);
            }

            foreach (string[] section in listOfSectionsAsStrings)
            {
                foreach (string letter in section)
                {
                    int[] sectionPairNumbers = {int.Parse(letter)};
                    listOfSections.Add(sectionPairNumbers);
                }
            }

            foreach (int[] section in listOfSections)
            {
                foreach (int number in section)
                {
                    Console.Write(number);
                }
            }
            
            /* TESTING */
            
            int[] testSection = { 5, 5 };

            int[] CreateArrayFromSection(int[] section)
            {

                int[] wholeSection = new int[section[1] - section[0] + 1];

                for (int i = section[0]; i <= section[1]; i++)
                {
                    wholeSection[i - section[0]] = i;
                }

                return wholeSection;

            }

            int[] testing = CreateArrayFromSection(testSection);
            foreach (int number in testing)
            {
                Console.WriteLine(number);
            }




        }
    }
}