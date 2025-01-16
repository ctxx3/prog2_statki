namespace prog2_statki.Models
{
    public class Game
    {
        private int _Current_turn;

        private Player[] players = new Player[2];

        public Game()
        {
            players[0] = new Player(0);
            players[1] = new Player(1);
            _Current_turn = 0;
        }

        public void Start()
        {
            // ustawianie plansz
            players[0].SetupBoard();
            players[1].SetupBoard();
            // zaczęcie gry
            while (true)
            {
                Console.WriteLine("Player " + _Current_turn + " turn");
                // ruch gracza
                NextTurn();
                // sprawdzenie czy gra się skończyła
                if(IsGameOver()){
                    break;
                }
            }
            // koniec gry
        }
        private void NextTurn()
        {

            if (players[_Current_turn].Shoot(players[1 - _Current_turn]) == 1)
            {
                Console.WriteLine("Hit");
            }
            else
            {
                Console.WriteLine("Miss");
            }
            
            
        }

        private bool IsGameOver()
        {
            if(players[0].hits == 20){
                Console.WriteLine("Player 0 wins");
                return true;
            }
            if(players[1].hits == 20){
                Console.WriteLine("Player 1 wins");
                return true;
            }
            
            
            return false;
        }
    }
}