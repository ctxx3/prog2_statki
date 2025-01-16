namespace prog2_statki.Models
{
    public class Player{
        Map map = new Map();

        private int _Id;

        public Player(int id){
            // Placeholder for player constructor
            _Id = id;
            Console.WriteLine("Player created");
        }

        public void SetupBoard(){
            // Placeholder for setting up the board
            Console.WriteLine("Setting up the board");
        }
    }
}