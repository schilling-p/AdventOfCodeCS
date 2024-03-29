﻿/*
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
            Console.WriteLine();
            foreach (int[] section in listOfIndividualSectionsAsInts)
            {
                fullSections.Add(CreateArrayFromSection(section));
            }
            /*
            foreach (int[] fullSection in fullSections)
            {
                Console.WriteLine("New Section:");
                PrintValuesOfIntArray(fullSection);
            }
            */
            int[] CreateArrayFromSection(int[] section)
            {

                int[] wholeSection = new int[section[1] - section[0] + 1];

                for (int i = section[0]; i <= section[1]; i++)
                {
                    wholeSection[i - section[0]] = i;
                }

                return wholeSection;

            }

            int counter = 0;
            int contains = 0;
            
            while (counter < fullSections.Count)
            {
                if (SectionOverlapChecker(fullSections[counter], fullSections[counter + 1]))
                {
                    contains += 1;
                }

                counter += 2;
            }
            

            bool SectionContainChecker(int[] arr1, int[] arr2)
            {
                bool containing1 = true;
                bool containing2 = true;

                foreach (int number in arr1)
                {
                    if (!arr2.Contains(number))
                    {
                        containing1 = false;
                        break;
                    }
                }

                foreach (int number in arr2)
                {
                    if (!arr1.Contains(number))
                    {
                        containing2 = false;
                        break;
                    }
                }

                return containing1 || containing2;
            }

            bool SectionOverlapChecker(int[] arr1, int[] arr2)
            {
                bool contains1 = false;
                bool contains2 = false;
                
                foreach (int number in arr1)
                {
                    if (arr2.Contains(number))
                    {
                        contains1 = true;
                        break;
                    }
                }

                foreach (int number in arr2)
                {
                    if (arr1.Contains(number))
                    {
                        contains2 = true;
                        break;
                    }
                }
                
                return contains1 || contains2;
                
            }
            
            Console.WriteLine(fullSections.Count);
            Console.WriteLine(contains);

            /* TESTING */
            
            int[] test2 = { 1, 2, 3, 4, 5 };
            int[] test1 = { 1, 2, 3, 6};
            Console.WriteLine(SectionOverlapChecker(test1, test2));
            
            
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