using System;
using System.IO;


// Task:
// I am given a list of numbers like the one in calories.txt
// Each consecutive stream of numbers represents one reindeer
// Which one has the most calories and how many does it have?

public class Day1
{
    /*
     Current status:
        - the values from the text file are loaded into a list and are seperated by a 0
        - what I need to know is, who is the elf with the most calories and which one is it
        - my idea is that I make a dictoinary that sums up all the entries between 2 zeros and stores them under a number
        - this could be done by a foreach
        - the while loop builds the list

    ideas:
        - change the statement in the while loop to help with the selection process
        - create a dictionary with keys being the deers and values being a list of the associated calories
        - How can I determine when a new reindeer starts?
     */


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
                result = 000000000;
            }
            else
            {
                result = Int32.Parse(oneLine);
            }
            
            values.Add(result);

            oneLine = reader.ReadLine();
        }



        reader.Close();
        Console.ReadLine();

    }
}
