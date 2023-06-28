/*
What is the input like and what is the task?
    - Input is a strategy guide that shows 2 letters like "C Y"
    - A, B, C and X, Y, Z stand for Rock Paper and Scissors

What do I need to know?
    - Who chose what sign? The first one is mine, the second one is from my opponent
    - Which sign beats which sign?
    - There is a score system:
        - 1st score for the hand chosen (1 for Rock, 2 for Paper, 3 for Scissors)
        - 2nd score is for the outcome of the round (0 if loose, 3 if draw and 6 if won)
 
 */

public class Solution
{

    public static void Main()
    {
        string? oneLine;
        StreamReader reader = new("/Users/paulschilling/Dokumente/Studium/Coding/C#/AdventOfCodeCS/Day2/Day2/strategy_guide.txt");        

        oneLine = reader.ReadLine();

        List<char> possibleSigns = new ();
        string possibleSignsInAString = "ABCXYZ";

        foreach(char sign in possibleSignsInAString)
        {
            possibleSigns.Add(sign);
        }

        List<List<char>> rounds = new List<List<char>>();

        while (oneLine != null)
        {
            List<char> oneRound = new();

            while(oneRound.Count < 2)
            {
                foreach (char letter in oneLine)
                {
                    if (possibleSigns.Contains(letter))
                    {
                        oneRound.Add(letter);
                    }
                }

            }

            rounds.Add(oneRound);
            oneRound.Clear();

            oneLine = reader.ReadLine();
        }

        foreach (List<char> round in rounds)
        {
            foreach(char sign in round)
            {
                Console.WriteLine(sign);
            }
        }        
    }
}
