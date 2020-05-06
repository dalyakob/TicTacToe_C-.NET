using System;

namespace TicTacToe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello there! Welcome to David's Tic Tac Toe game.");

            do
            {
                //declaring char board array
                var board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                DisplayBoard(board);

                int i = 0;
                bool isX;

                do
                {
                    // alternating X/O after loop
                    isX = i % 2 == 0;

                    PlaceMarker(isX, board);
                    DisplayBoard(board);
                    i++;

                } while (!Victory(isX, board) && !BoardFull(board));


                Console.WriteLine("Would you like to play again? (y/n)");
            } while (Console.ReadLine().ToLower() == "y");
        }

        
        public static void DisplayBoard(char[] board)
        {
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  " );
            Console.WriteLine($" ---------------");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  " );
            Console.WriteLine($" ---------------");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  " );
        }


        public static bool PositionTaken(char[] board, uint position)
        {
            if (board[position - 1] == 'X' || board[position - 1] == 'O')
                return true;
            
            return false;
        }

        public static bool Victory(bool isX, char[] board)
        {                                                                                                           // Winning conditions
            if (   (board[0] == board[1] && board[1] == board[2]) || (board[3] == board[4] && board[4] == board[5]) // ---
                || (board[6] == board[7] && board[7] == board[8]) || (board[0] == board[4] && board[4] == board[8]) // --- & \
                || (board[0] == board[3] && board[6] == board[7]) || (board[1] == board[4] && board[4] == board[7]) // |||
                || (board[2] == board[5] && board[5] == board[8]) || (board[2] == board[4] && board[4] == board[6]))// ||| & /
            { 
                if (isX)
                    Console.WriteLine("\n X wins!!!   X wins!!!   X wins!!!\n");

                else
                    Console.WriteLine("\n O wins!!!   O wins!!!   O wins!!!\n");

                return true;
            }
            return false;
        }

        public static bool BoardFull(char[] board)
        {
            foreach (var temp in board)
            {
                if (!(temp == 'X' || temp == 'O'))
                    return false;
            }

            return true;
        } 

        public static void PlaceMarker(bool playerX, char[] board)
        {
            uint position;
            do
            {
                Console.WriteLine("Enter a position for your marker to go: ");
            } while (!uint.TryParse(Console.ReadLine(), out position) || position > 9 || position == 0 || PositionTaken(board, position));

            if (playerX)
                board[position-1] = 'X';
            else
                board[position-1] = 'O';
        }

    }
}
