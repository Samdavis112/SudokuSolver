using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Sudoku Solver";
            char[,] sudoku = new char[9, 9];
            Console.WriteLine("Navigate with the arrow keys, input numbers and then hit enter...");
            Console.ReadKey();
            Console.Clear();
            Inputting(sudoku);
            Console.WriteLine("\n\nSolution: \n");
            solveSudoku(sudoku);
            DrawBoard(sudoku);
            Console.ReadLine();
        }
        private static void solveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            solve(board);
        }
        private static bool solve(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (isValid(board, i, j, c))
                            {
                                board[i, j] = c;

                                if (solve(board))
                                    return true;
                                else
                                    board[i, j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool isValid(char[,] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                //check row  
                if (board[i, col] != '.' && board[i, col] == c)
                    return false;
                //check column  
                if (board[row, i] != '.' && board[row, i] == c)
                    return false;
                //check 3*3 block  
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c)
                    return false;
            }
            return true;
        }
        private static char[,] Setup(char[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = '.';
                }
            }
            return sudoku;
        }
        private static void DrawBoard(char[,] sudoku)
        {
            int y = 0;
            for (int l = 0; l < 9; l++)
            {
                if (y == 3 || y == 6)
                {
                    Console.WriteLine("\n---------------------");
                }
                else if(y > 0)
                {
                    Console.WriteLine();
                }
                int f = 0;
                for (int z = 0; z < 9; z++)
                {
                    if (f == 2 || f == 5)
                    {
                        Console.Write(sudoku[l, z] + " | ");
                    }
                    else
                    {
                        Console.Write(sudoku[l, z] + " ");
                    }
                    f++;
                }
                y++;
            }
        }
        private static void InputtingDrawBoard(char[,] sudoku, int cursorX, int cursorY)
        {
            int y = 0;
            for (int l = 0; l < 9; l++)
            {
                if (y == 3 || y == 6)
                {
                    Console.WriteLine("\n---------------------");
                }
                else if (y > 0)
                {
                    Console.WriteLine();
                }
                int f = 0;
                for (int z = 0; z < 9; z++)
                {
                    if (f == 2 || f == 5)
                    {
                        if (cursorX == z && cursorY == l)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(sudoku[l, z]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" | ");
                        }
                        else
                        {
                            Console.Write(sudoku[l, z] + " | ");
                        }
                    }
                    else
                    {
                        if (cursorX == z && cursorY == l)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(sudoku[l, z]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write(sudoku[l, z] + " ");
                        }
                    }
                    f++;
                }
                y++;
            }
            Console.WriteLine();
        }
        private static char[,] Inputting(char[,] sudoku)
        {
            //Adding dots
            Setup(sudoku);

            //Loop to input
            int cursorX = 0;
            int cursorY = 0;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                InputtingDrawBoard(sudoku, cursorX, cursorY);
                var keyPressed = Console.ReadKey().Key;

                // Movement
                #region movement
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (cursorY > 0)
                    {
                        cursorY--;
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (cursorX < 8)
                    {
                        cursorX++;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (cursorY < 8)
                    {
                        cursorY++;
                    }
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (cursorX > 0)
                    {
                        cursorX--;
                    }
                }
                #endregion

                // Numbers
                #region numbers
                else if (keyPressed == ConsoleKey.D1)
                {
                    sudoku[cursorY, cursorX] = '1';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if(cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D2)
                {
                    sudoku[cursorY, cursorX] = '2';
                    if (cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D3)
                {
                    sudoku[cursorY, cursorX] = '3';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D4)
                {
                    sudoku[cursorY, cursorX] = '4';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D5)
                {
                    sudoku[cursorY, cursorX] = '5';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D6)
                {
                    sudoku[cursorY, cursorX] = '6';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D7)
                {
                    sudoku[cursorY, cursorX] = '7';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D8)
                {
                    sudoku[cursorY, cursorX] = '8';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                else if (keyPressed == ConsoleKey.D9)
                {
                    sudoku[cursorY, cursorX] = '9';
                    if(cursorX < 8)
                    {
                        cursorX++;
                    }
                    else
                    {
                        if (cursorY != 8)
                        {
                            cursorX = 0;
                            cursorY++;
                        }
                    }
                }
                #endregion

                // Enter
                else if (keyPressed == ConsoleKey.Enter)
                {
                    break;
                }
            }
            return sudoku;
        }
    }
}