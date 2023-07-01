/*
What is the input like and what is the task?
    - Input is a strategy guide that shows 2 letters like "C Y"
    - A, B, C and X, Y, Z stand for Rock Paper and Scissors
    - The task is:
        - read the strategy guide
        - award points for each round and add them together
        - return the points

What do I need to know?
    - Who chose what sign? The first one is mine, the second one is from my opponent
    - Which sign beats which sign?
    - There is a score system:
        - 1st score for the hand chosen (1 for Rock, 2 for Paper, 3 for Scissors)
        - 2nd score is for the outcome of the round (0 if loose, 3 if draw and 6 if won)

Milestones:
    - first part done and the correct answer was gotten on the first try: 9177

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
        // build a list of possible values
        foreach(char sign in possibleSignsInAString)
        {
            possibleSigns.Add(sign);
        }
        // build a list consisting of each round as a seperate list
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

            oneLine = reader.ReadLine();
        }

        RockPaperScissors game = new RockPaperScissors();

        int totalScore = 0;
        foreach (List<char> round in rounds)
        {
            int roundScore = game.GetMyScore(round);
            Console.WriteLine(roundScore);
            totalScore += roundScore;
        }

        Console.WriteLine($"Your total score is: {totalScore}.");

    }
}

public class RockPaperScissors
{
    public int GetMyScore(List<char> round)
    {
        int score = 0;
        score += scoreLookUpDict[DetermineMyHand(round)];
        score += scoreLookUpDict[round[1]];

        return score;
    }

    private readonly Dictionary<char, string> handlookUpDict = new Dictionary<char, string>
    { 
        { 'A', "Rock" },
        { 'B', "Paper" },
        { 'C', "Scissors" },
        { 'X', "Loose" },
        { 'Y', "Draw" },
        { 'Z', "Win" }
    };

    private Dictionary<char, int> scoreLookUpDict = new Dictionary<char, int>
    {
        { 'R', 1 },
        { 'P', 2 },
        { 'S', 3 },
        { 'X', 0 },
        { 'Y', 3 },
        { 'Z', 6 }
    };
    
    private char DetermineMyHand(List<char> round)
    {
        string handOpponent = handlookUpDict[round[0]];
        string desiredOutCome = handlookUpDict[round[1]];

        if (handOpponent == "Rock")
        {
            if (desiredOutCome == "Draw")
            {
                return 'R';
            }
            else if (desiredOutCome == "Loose")
            {
                return 'S';
            }
            else if (desiredOutCome == "Win")
            {
                return 'P';
            }
        }
        else if (handOpponent == "Paper")
        {
            if (desiredOutCome == "Draw")
            {
                return 'P';
            }
            else if (desiredOutCome == "Loose")
            {
                return 'R';
            }
            else if (desiredOutCome == "Win")
            {
                return 'S';
            }
        }
        else if (handOpponent == "Scissors")
        {
            if (desiredOutCome == "Draw")
            {
                return 'S';
            }
            else if (desiredOutCome == "Loose")
            {
                return 'P';
            }
            else if (desiredOutCome == "Win")
            {
                return 'R';
            }
        }
        return 't';
    }
}
