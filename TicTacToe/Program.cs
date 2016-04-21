using System;

/******************************************************************
* Author: Thomas Kramer                                           *
* Purpose: A two player game of tic tac to                        *
* Date: 21/04/2016 3:10pm                                         *
******************************************************************/

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean gameLoop = true;
            while (gameLoop == true) { 
            char replay;
            Boolean validInput = false;
                Console.Clear();
            runGame();

                while (validInput == false)
                {
                    Console.WriteLine("Would you like to play again? Y/N");
                    var playAgain = Console.ReadLine();


                  

                    if (!string.IsNullOrEmpty(playAgain) == true) { 

                        replay = Char.ToUpper(playAgain[0]);

                        if (replay == 'Y' || replay == 'N')
                        {

                            if (replay == 'Y')
                            {
                                break;
                            }
                            else
                            {
                                gameLoop = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
        }
        }  
            

        public static void runGame()
        {

            Boolean playerOneTurn = true;
            int userRow;
            int userColumn;
            char[,] board = new char[,]
            {
                {'^', '^', '^' },
                  {'^', '^', '^' },
                  {'^', '^', '^' },
            };


            print(board);

            Boolean rowSelectLoop = true;
            Boolean columnSelectLoop = true;
            Boolean runGame = CheckAvaliable(board);
            char placement;
            do
            {
                columnSelectLoop = true;
                rowSelectLoop = true;
                while (rowSelectLoop == true)
                {
                    if (playerOneTurn == true)
                    {
                        Console.WriteLine("It is player ones turn!");
                    }
                    else
                    {
                        Console.WriteLine("It is player twos turn!");
                    }

                    Console.WriteLine("Please select a row 0, 1, 2:");
                    string userRowString = Console.ReadLine();
                    if (int.TryParse(userRowString, out userRow))
                    {

                        if (userRow == 0 || userRow == 1 || userRow == 2)
                        {


                            while (columnSelectLoop == true)
                            {
                                Console.WriteLine("Please select a column 0, 1, 2:");
                                string userColumnString = Console.ReadLine();
                                rowSelectLoop = false;
                                if (int.TryParse(userColumnString, out userColumn))
                                {

                                    if (userColumn == 0 || userColumn == 1 || userColumn == 2)
                                    {
                                        if (playerOneTurn == true)
                                        {
                                            placement = 'O';
                                        }
                                        else
                                        {
                                            placement = 'X';
                                        }

                               //If the selected place space is Avaliable replace that spots value with placement and switch players.
                                        if (CheckSpaceAvaliable(board, userRow, userColumn) == true)
                                        {
                                            board[userRow, userColumn] = placement;
                                            playerOneTurn = !playerOneTurn;
                                        }
                                        else
                                        {
                                            Console.WriteLine("That spot is already taken!");
                                            Console.ReadLine();
                                        }
                               //Clear and reprint board as it may have updated.
                                        Console.Clear();
                                        print(board);
                              //Check if there are 3 in a row if so stop running game and congradulate player
                                        if (threeInARow(placement, board) == true)
                                        {
                                            runGame = false;
                                            Console.WriteLine("Congradulations, player {0}! You won!", placement);
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                     //Keeps running game as long as there are places avaliable.
                                            runGame = CheckAvaliable(board);
                                        }
                                        columnSelectLoop = false;

                                    }
                                    else
                                    {
                                        Console.WriteLine("That is not a valid column");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("That is not a valid column");

                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("That is not a valid row");
                        }


                    }
                    else
                    {
                        Console.WriteLine("That is not a valid row");
                    }

                }
            } while (runGame == true);
        }

/******************************************************************
* Author: Thomas Kramer                                           *
* Purpose: Prints the board to console                            *
* Date: 21/04/2016 3:10pm                                         *
******************************************************************/
        public static void print(char[,] board)
        {
            
            for (int j = 0; j <= 2; j++)
            {
                for (int i = 0; i <= 2; i++)
                {
                    Console.Write(" " + board[j, i] + " | ");



                }
                Console.WriteLine("\n-------------\n");
            }

            


        }
/******************************************************************
* Author: Thomas Kramer                                           *
* Purpose: Checks if any places are left on the board             *
* Date: 21/04/2016 3:10pm                                         *
******************************************************************/
        public static Boolean CheckAvaliable(char[,] board)
        {
            var found = false;
            foreach(var spots in board)
            {
                if (spots == '^') {
                    found = true;
                    break;
                }
                else
                {
                    found = false;   
                }
                
            }
            return found;

        }
/******************************************************************************
* Author: Thomas Kramer                                                       *
* Purpose: Checks to see if the selected spot has been taken by another player*
* Date: 21/04/2016 3:10pm                                                     *
******************************************************************************/
        public static Boolean CheckSpaceAvaliable(char[,] board, int rows, int columns)
        {
            Boolean spotTaken;
            if (board[rows, columns] == '^')
                spotTaken = true;
            else
                spotTaken = false;
            return spotTaken;
        }
/******************************************************************************
* Author: Thomas Kramer                                                       *
* Purpose: Checks to see if a player has 3 placments in a row                 *
* Date: 21/04/2016 3:10pm                                                     *
******************************************************************************/
        public static Boolean threeInARow(char playerNumber, char[,] board)
        {
            Boolean threeInARow = false;
            //Horizontal lines
            if(board[0,0] == playerNumber && board[0, 1] == playerNumber && board[0, 2] == playerNumber)
                threeInARow = true;  
            if (board[1, 0] == playerNumber && board[1, 1] == playerNumber && board[1, 2] == playerNumber)
                threeInARow = true;
            if (board[2, 0] == playerNumber && board[2, 1] == playerNumber && board[2, 2] == playerNumber)
                threeInARow = true;

            //Vertical lines
            if (board[0, 0] == playerNumber && board[1, 0] == playerNumber && board[2, 0] == playerNumber)
                threeInARow = true;
            if (board[0, 1] == playerNumber && board[1, 1] == playerNumber && board[2, 1] == playerNumber)
                threeInARow = true;
            if (board[0, 2] == playerNumber && board[1, 2] == playerNumber && board[2, 2] == playerNumber)
                threeInARow = true;


            //Diaganol lines

            if (board[0, 0] == playerNumber && board[1, 1] == playerNumber && board[2, 2] == playerNumber)
                threeInARow = true;
            if (board[0, 2] == playerNumber && board[1, 1] == playerNumber && board[2, 0] == playerNumber)
                threeInARow = true;
            return threeInARow;
        }

    }
}
