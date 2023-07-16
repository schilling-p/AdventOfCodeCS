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
            List<string> sectionPairsFromInput = new();
            while (oneLine != null)
            {
                sectionPairsFromInput.Add(oneLine);
                oneLine = reader.ReadLine();
            }

            List<string[]> listOfSectionsAsStrings = new List<string[]>();
            List<int[]> listOfIndividualSectionsAsInts = new List<int[]>();
            char[] delimiters = { ',' };
            
            foreach (string sectionPair in sectionPairsFromInput)
            {
                string[] sectionPairNumbersAsStrings = sectionPair.Split(delimiters);

                listOfSectionsAsStrings.Add(sectionPairNumbersAsStrings);
            }
            
            foreach (string[] section in listOfSectionsAsStrings)
            {
                foreach (string character in section)
                {
                    string[] oneSectionAsString = character.Split("-");
                    
                    int[] oneSectionAsInts = Array.ConvertAll(oneSectionAsString, int.Parse);
                    
                    listOfIndividualSectionsAsInts.Add(oneSectionAsInts);
                }
            }
            // Now there is a list of arrays where each array represents a section
            // I know that 2 arrays following each other represent a line from the input
            // [2-4],[6-8]
            //Console.WriteLine(listOfIndividualSectionsAsInts[0][0]);


            // This list contains all the sections but written out in full length
            List<int[]> fullSections = new();
            foreach (int[] section in listOfIndividualSectionsAsInts)
            {
                fullSections.Add(CreateArrayFromSection(section));
            }

            foreach (int[] fullSection in fullSections)
            {
                Console.WriteLine("New Section:");
                PrintValuesOfIntArray(fullSection);
            }
            
            int[] CreateArrayFromSection(int[] section)
            {

                int[] wholeSection = new int[section[1] - section[0] + 1];

                for (int i = section[0]; i <= section[1]; i++)
                {
                    wholeSection[i - section[0]] = i;
                }

                return wholeSection;

            }
            


            /* TESTING */
            
            
            // Build a method that takes 2 arrays of type int as arguments
            // and returns true if one is fully contained in the other
            
            
            void PrintValuesOfArray(Object[] myArr)
            {
                foreach (Object i in myArr)
                {
                    Console.WriteLine(i);
                }
            }
            
            void PrintValuesOfIntArray(int[] myArr)
            {
                foreach (int i in myArr)
                {
                    Console.WriteLine(i);
                }
            }

            

            




        }
    }
}