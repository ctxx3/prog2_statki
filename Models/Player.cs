namespace prog2_statki.Models
{
    public class Player
    {
        public int[,] board = new int[8, 8];
        private int _Id;
        public int hits = 0;

        private readonly int[] _Ships = { 4, 3, 2, 2, 1, 1 };

        public Player(int id)
        {
            // Placeholder for player constructor
            _Id = id;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
            }
            Console.WriteLine("Player created");
        }

        public void SetupBoard()
        {
            Console.WriteLine("Setting up the board");
            int[] cursor = { 0, 0 };
            bool rotated = false;
            int currentShip = 0;

            while (currentShip < _Ships.Length)
            {
                // Redraw the board
                Console.Clear();
                DrawBoardPlacement(cursor[0], cursor[1], _Ships[currentShip], rotated);
                Console.WriteLine($"Player {_Id} setup board");
                Console.WriteLine($"Current piece: {currentShip} / {_Ships.Length}");
                Console.WriteLine($"Rotated: {rotated}");
                Console.WriteLine("Arrows: move cursor, Space: rotate, Enter: place, R: reset");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        cursor[1] = Math.Max(0, cursor[1] - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        cursor[1] = Math.Min(rotated ? 8 - _Ships[currentShip] : 7, cursor[1] + 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        cursor[0] = Math.Max(0, cursor[0] - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        cursor[0] = Math.Min(rotated ? 7 : 8 - _Ships[currentShip], cursor[0] + 1);
                        break;
                    case ConsoleKey.Spacebar:
                        rotated = !rotated;
                        break;
                    case ConsoleKey.Enter:
                        if (PlaceShip(cursor[0], cursor[1], rotated, _Ships[currentShip]))
                        {
                            currentShip++;
                        }
                        break;
                    case ConsoleKey.R:
                        Array.Clear(board, 0, board.Length);
                        currentShip = 0;
                        break;
                }
            }
        }

        private bool PlaceShip(int x, int y, bool rotated, int length)
        {
            // Check if the ship goes outside the board or any spot is already occupied
            for (int i = 0; i < length; i++)
            {
                int newX = rotated ? x : x + i;
                int newY = rotated ? y + i : y;
                if (newX >= 8 || newY >= 8 || board[newY, newX] != 0) return false;
            }

            // Place the ship
            for (int i = 0; i < length; i++)
            {
                int newX = rotated ? x : x + i;
                int newY = rotated ? y + i : y;
                board[newY, newX] = 1;
            }
            return true;
        }

        private void DrawBoardPlacement(int x = -1, int y = -1, int length = 1, bool rotated = false)
        {
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] switch
                    {
                        1 => "O",
                        _ => " "
                    });
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            for (int k = 0; k < length; k++)
            {
                Console.SetCursorPosition(rotated ? x : x + k, rotated ? y + k : y);
                Console.Write("@");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 8);
        }

        private void DrawBoardShooting(int x, int y, Player enemy)
        {
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(enemy.board[i, j] switch
                    {
                        2 => "X", // Hit
                        3 => ".", // Miss
                        _ => " "  // Unknown or ship
                    });
                }
                Console.WriteLine();
            }
        
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 8);
        }
        
        public int Shoot(Player enemy)
        {
            int[] cursor = { 0, 0 };
            bool shotTaken = false;
        
            while (!shotTaken)
            {
                Console.Clear();
                DrawBoardShooting(cursor[0], cursor[1], enemy);
                Console.WriteLine($"Player {_Id}'s turn to shoot");
                Console.WriteLine($"Hits: {hits}");
                Console.WriteLine("Arrows: move cursor, Enter: shoot");
        
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        cursor[1] = Math.Max(0, cursor[1] - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        cursor[1] = Math.Min(7, cursor[1] + 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        cursor[0] = Math.Max(0, cursor[0] - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        cursor[0] = Math.Min(7, cursor[0] + 1);
                        break;
                    case ConsoleKey.Enter:
                        if (enemy.board[cursor[1], cursor[0]] != 2 && 
                            enemy.board[cursor[1], cursor[0]] != 3)
                        {
                            if (enemy.board[cursor[1], cursor[0]] == 1)
                            {
                                enemy.board[cursor[1], cursor[0]] = 2; // Hit
                                hits++;
                                shotTaken = true;
                                return 1;
                            }
                            else
                            {
                                enemy.board[cursor[1], cursor[0]] = 3; // Miss
                                shotTaken = true;
                                return 0;
                            }
                        }
                        break;
                }
            }
            return 0;
        }
    }


}