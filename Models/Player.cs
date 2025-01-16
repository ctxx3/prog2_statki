namespace prog2_statki.Models
{
    public class Player
    {
        public int[,] board = new int[8, 8];
        private int _Id;

        private readonly int[] _Ships = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

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
            bool accepted = false;
            int currentShip = 0;

            while (!accepted)
            {
                // Redraw the board
                Console.Clear();
                Console.WriteLine("Player " + _Id + " setup board");
                DrawBoard(cursor[0], cursor[1]);
                Console.WriteLine("Current piece: " + currentShip + " / " + _Ships.Length);
                Console.WriteLine("Rotated: " + rotated);
                Console.WriteLine("Arrows: move cursor, Space: rotate, Enter: place, R: reset");

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
                    case ConsoleKey.Spacebar:
                        rotated = !rotated;
                        break;
                    case ConsoleKey.Enter:
                        if(PlaceShip(cursor[0], cursor[1], rotated, _Ships[currentShip])){
                            currentShip++;
                            if(currentShip == _Ships.Length){
                                accepted = true;
                            }
                        }
                        break;
                    case ConsoleKey.R:
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                board[i, j] = 0;
                            }
                        }
                        break;
                }
            }
        }

        private bool PlaceShip(int x, int y, bool rotated, int length)
        {
            // Check if the ship goes outside the board
            if (rotated)
            {
                if (y + length > 8) return false;
            }
            else
            {
                if (x + length > 8) return false;
            }

            // Check if any spot is already occupied
            for (int i = 0; i < length; i++)
            {
                if (rotated)
                {
                    if (board[y + i, x] != 0) return false;
                }
                else
                {
                    if (board[y, x + i] != 0) return false;
                }
            }

            // Place the ship
            for (int i = 0; i < length; i++)
            {
                if (rotated)
                {
                    board[y + i, x] = 1;
                }
                else
                {
                    board[y, x + i] = 1;
                }
            }
            return true;
        }

        private void DrawBoard(int x = -1, int y = -1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == y && j == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@");
                    }
                    else
                    {
                        switch (board[i, j])
                        {
                            case 0:
                                Console.Write(" ");
                                break;
                            case 1:
                                Console.Write("O");
                                break;
                            case 2:
                                Console.Write("X");
                                break;
                            default:
                                Console.Write(" ");
                                break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}