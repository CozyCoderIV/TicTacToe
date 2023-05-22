using System;

namespace Game
{
    class TicTacToe
    {   // Attributes
        static bool playGame = true;
        static bool victory = false;
        static bool defeat = false;
        static String[,] tacBoard = { {"[]", "[]", "[]"},
                                      {"[]", "[]", "[]"},
                                      {"[]", "[]", "[]"}
        };
        static int[,] markBoard = { {0, 0, 0 },
                                    {0, 0, 0 },
                                    {0, 0, 0 }
        };
        static char playerLetter, cpuLetter;
        static bool first;
        static int playerTurns, cpuTurns;

        // Methods
        static void Main(string[] args)
        {

            // Game Rules Display
            Console.WriteLine("Welcome to Tic Tac Toe");
            Console.WriteLine("________________________");
            Console.WriteLine("\nGuidelines :");
            Console.WriteLine("1. Select A Letter (X or O)");
            Console.WriteLine("2. Select A Position On The Board Following " +
                              "(Row, Column) Syntax :");
            Console.WriteLine("\ta. Enter Row: R");
            Console.WriteLine("\tb. Enter Column: C");
            Console.WriteLine("\n** ( All rows and columns follow array index " +
                              "syntax ) **\n");

            // Debug (print markBoard)
            Console.Write("Spaces open : ");
            foreach (int item in markBoard)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            Console.Write("Current Board : ");
            foreach (String item in tacBoard)
            {
                Console.Write($"{item} ");
            }

            // Initial User Input (Select X ￼or O)
            Console.WriteLine("\n\nPlease Type In Desired Letter: ");
            Console.WriteLine("[A] : X");
            Console.WriteLine("[B] : O\n");
            playerLetter = Convert.ToChar(Console.ReadLine());

            if(playerLetter == 'O')
            {
                cpuLetter = 'X';
            } else
            {
                cpuLetter = 'O';
            }

            // Game Set Up
            Console.WriteLine("\n=============================");
            Console.WriteLine("|\tTic Tac Toe\t    |");
            Console.WriteLine("=============================\n");

            // Display Board
            displayBoard(tacBoard);

            Console.WriteLine("\n\n=============================");

            // Determine First
            Random random = new Random();
            int a = random.Next(2);
            if (a == 1)
            {
                first = true;
                playerTurns = 5;
                Console.WriteLine("\nPlayer Goes First !!!\n");
            }
            if (a == 0)
            {
                first = false;
                playerTurns = 4;
                Console.WriteLine("\nCPU Goes First !!!\n");

                // Update Board
            }

            // Game Loop
            int iteration = 0;
            if (a == 1)
            {   while(iteration < 5)
                {
                    // If Condition
                    if((victory == true || defeat == true))
                    {   break;
                    }

                    // Player Turn
                    Console.Write("\nEnter row position : ");
                    int tempA = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter column position : ");
                    int tempB = Convert.ToInt32(Console.ReadLine());

                    // Update Board (2D Array)
                    if (tacBoard[tempA, tempB] == "[]" && markBoard[tempA, tempB] == 0)
                    {
                        tacBoard[tempA, tempB] = Convert.ToString(playerLetter);
                        markBoard[tempA, tempB] = 1;
                    }

                    // Run Board Check
                    boardCheck(tacBoard); // (victory | defeat) condition check

                    // CPU Turn
                    int tempC = random.Next(3);
                    int tempD = random.Next(3);

                    // Duplication Check
                    if ((markBoard[tempC, tempD] == 1) ||
                        (tempC == tempA && tempD == tempB))
                    {
                        while ((markBoard[tempC, tempD] == 1) && (tempC == tempA && tempD == tempB))
                        {
                            tempC = random.Next(2);
                            tempD = random.Next(2);
                        }

                    }
                    Console.WriteLine($"CPU position : {tempC} {tempD}\n");

                    // Update Board (2D Array)
                    if (tacBoard[tempC, tempD] == "[]" && markBoard[tempC, tempD] == 0)
                    {
                        tacBoard[tempC, tempD] = $"{cpuLetter}";
                        markBoard[tempC, tempD] = 1;
                    }

                    // Debug (print markBoard)
                    Console.Write("Spaces open : ");
                    foreach (int item in markBoard)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine("");
                    Console.Write("Current Board : ");
                    foreach (String item in tacBoard)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine("");

                    // Run Board Check
                    boardCheck(tacBoard); // (victory | defeat) condition check

                    iteration++;
                }
            } else {
                while (iteration < 4)
                {
                    // If Condition
                    if ((victory == true || defeat == true))
                    {    break;
                    }

                    // CPU Turn
                    int tempA = random.Next(3);
                    int tempB = random.Next(3);

                    // Duplication Check
                    if (markBoard[tempA, tempB] == 1 && tacBoard[tempA, tempB] != "[]")
                    {
                        // until I find an open space

                        while (markBoard[tempA, tempB] == 1)
                        {
                            tempA = random.Next(2);
                            tempB = random.Next(2);
                        }
                    }

                    // Update Board (2D Array)
                    if (tacBoard[tempA, tempB] == "[]" && markBoard[tempA, tempB] == 0)
                    {
                        tacBoard[tempA, tempB] = $"{cpuLetter}";
                        markBoard[tempA, tempB] = 1;
                    }

                    Console.WriteLine($"\nCPU position : {tempA} {tempB}");
                   

                    // Run Board Check
                    boardCheck(tacBoard); // (victory | defeat) condition check

                    // Player Turn
                    Console.Write("Enter row position : ");
                    int tempC = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter column position : ");
                    int tempD = Convert.ToInt32(Console.ReadLine());

                    // Update Board (2d Array)
                    if (tacBoard[tempC, tempD] == "[]" && markBoard[tempC, tempD] == 0)
                    {
                        tacBoard[tempC, tempD] = Convert.ToString(playerLetter);
                        markBoard[tempC, tempD] = 1;
                    }
                

                    // Debug (print markBoard)
                    Console.Write("\nSpaces open : ");
                    foreach (int item in markBoard)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine("");
                    Console.Write("Current Board : ");
                    foreach (String item in tacBoard)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine("\n");

                    // Run Board Check
                    boardCheck(tacBoard); // (victory | defeat) condition check

                    iteration++;
                }

            }
            Console.WriteLine("\nDraw !!!");
            displayBoard(tacBoard);
            Console.WriteLine("\nThanks For Playing !!!!");

            Console.ReadKey();
        }

        // Methods
        public static void displayBoard(String[,] array)
        {
            // Display Board
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (j == 1)
                    {
                        Console.Write("| " + array[i, j] + " |");
                        continue;
                    }
                    else if (j != 0 && j % 2 == 0)
                    {
                        Console.Write(" " + array[i, j] + " ");
                        continue;
                    }
                    Console.Write(i + " \t" + array[i, j] + " ");
                }
                if (i == 2) { continue; }
                Console.WriteLine("\n\t_____________\n");
            }

        }
        public static void boardCheck(String[,] array)
        {
            int xCount = 0;
            int oCount = 0;

            // track array
            int[,] xcoordinates = { };
                
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {

                    if (array[i, j] == "X") {
                        xCount++;
                    }
                    if (array[i, j] == "O") {
                        oCount++;
                    }

                    // horizontal check
                    if(xCount >= 3)
                    { 

                    }

                    // vertical check

                    // diagonal check
                }
            }
        }
    }
}