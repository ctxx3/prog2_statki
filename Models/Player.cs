namespace prog2_statki.Models
{
    public class Player{
        public int[,] board = new int[8,8];
        private int _Id;

        private readonly int[] _Ships = {4, 3, 3, 2, 2, 2, 1, 1, 1, 1};

        public Player(int id){
            // Placeholder for player constructor
            _Id = id;
            Console.WriteLine("Player created");
        }

        public void SetupBoard(){
            Console.WriteLine("Setting up the board");
        }

        private void DrawBoard(){

        }
    }
}