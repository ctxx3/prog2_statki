namespace prog2_statki.Models
{
    public class Player{
        public int[,] board = new int[8,8];
        private int _Id;
        public int hits = 0;

        private readonly int[] _Ships = {4, 3, 3, 2, 2, 2, 1, 1, 1, 1};

        public Player(int id){
            // Placeholder for player constructor
            _Id = id;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i,j] = 0;
                }
            }
            Console.WriteLine("Player created");
        }

        public void SetupBoard(){
            Console.WriteLine("Setting up the board");
            int[] cursor = {0, 0};
            bool rotated = false;
            bool accepted = false;
            int currentShip = 0;

            while(!accepted){
                // Redraw the board
                Console.Clear();
                Console.WriteLine("Player " + _Id + " setup board");
                DrawBoard();
                Console.WriteLine("Current piece: " + currentShip + " / " + _Ships.Length);
                Console.WriteLine("Rotated: " + rotated);
                Console.WriteLine("Arrows: move cursor, Space: rotate, Enter: place, R: reset");
                Console.ReadKey();
            }
        }

        private void DrawBoard(){
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (board[i,j])
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
                Console.WriteLine();
            }
        }

        public int Shoot(Player enemy)
        {
            Console.WriteLine("Enter coordinates to shoot (x y): ");
            string[] input = Console.ReadLine().Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            if (enemy.board[x, y] == 1)
            {
                enemy.board[x, y] = 2; // Mark as hit
                hits++;
                return 1;
            }
            else
            {
                enemy.board[x, y] = 3; // Mark as miss
                return 0;
            }
        }
    }
    
    
}