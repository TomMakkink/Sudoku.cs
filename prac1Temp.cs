// Sudoku 
// Compilers Practical 1 Tom, Luke, Jeff 
using Library;
using System;
using System.Collections.Generic;


class Sudoko
{

    public static void writeBoard()
    {

    }

    public static string [] getInputFromUser()
    {
        IO.WriteLine("Please enter a row, column and value. e.g. 0 2 5");
        // Problem with the readLine 
        string s = IO.ReadLine();
        return s.Split(' ');
    }

    public static bool validateInput(string [] userInput)
    {
        // row columns value 
        if (userInput.Length == 3)
        {
            // Check that the row and column values are valid 
            if (Convert.ToInt32(userInput[0]) >= 0 && Convert.ToInt32(userInput[0]) < 9 && Convert.ToInt32(userInput[1]) >= 0 && Convert.ToInt32(userInput[1]) < 9)
            {
                // Check that the value is valid
                if (Convert.ToInt32(userInput[2]) > 0 && Convert.ToInt32(userInput[2]) < 10)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static List<int> convertToIntList(string [] userInput)
    {
        // We know it is a 3 element input, as we have checked it
        List<int> userMove = new List<int> { };
        for (int i = 0; i < 3; i++)
        {
            userMove.Add(Convert.ToInt32(userInput[i]));
        }
        return userMove;
    }

    public static List<IntSet> readInBoard(InFile data)
    {
        // Read in all of the rows 
        List<InSet> rowList = new List<InSet> { };
        for (int i = 0; i < 9; i++)
        {

        }
    }



    public static void Main(string[] args)
    {

        //List<string> temp = new List<string> { };
        //Screen MainScreen = new Screen();
        Screen.ClrScr();
        Screen.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
        //Screen.DefaultColor();
        Screen.TextColor(0);
        Screen.BackgroundColor(3);
        InFile data = new InFile(args[0]);
        if (data.OpenError())
        {
            Console.WriteLine("cannot open " + args[0]);
            System.Environment.Exit(1);
        }
        int i = 0;
        int tempInt = 9*9;
        IntSet mySet = new IntSet(1, 2, 3, 4, 5, 6, 7, 8, 9);
        
        List<IntSet> mySets = new List<IntSet>();
        List<List<IntSet>> board = new List<List<IntSet>>();
        //bool SolutionStarts = false;
        while (i < tempInt)
        {
            IntSet tempSet = new IntSet();
            int temp = data.ReadInt();
            tempSet.Incl(temp);
            if (temp != 0) mySets.Add(tempSet);
            if (temp == 0) mySets.Add(mySet);
            IO.Write(temp);
            i = i + 1;
            if (i != 0 && i % 9 == 0)
            {
                IO.Write('\n');
                board.Add(mySets);
                List<IntSet> tempSet2 = new List<IntSet>();
                mySets = tempSet2;
            }
            
            
        }
        IO.Write('\n');
        //IO.WriteLine(mySets.Count);
        //IO.WriteLine(board[1][0]);
        //IO.WriteLine(board[2][0]);
        IO.WriteLine("Please may you about to begin a new Game of Sudoku.");
        writeBoard();
        IO.WriteLine("Please may you you either type in (S)tart or (Q)uite");
        char T= IO.ReadChar();
        if (T=='S' || T == 's')
        {
            bool GameNotFinished = true;
            while (GameNotFinished)
            {
                // Get input from user 
                string [] userInput = getInputFromUser();
                while (!validateInput(userInput))
                {
                    IO.WriteLine("Invalid Input.");
                    userInput = getInputFromUser();
                }
                // List of valid input 
                List<int> userMove = convertToIntList(userInput);
            }
        }
        if(T=='q' || T == 'Q') { Screen.ClrScr(); System.Environment.Exit(1);}


    }

}
