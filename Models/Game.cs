using System.Reflection.Metadata.Ecma335;

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
            _Current_turn = (_Current_turn + 1) % 2;
            Console.ReadKey();
        }

        private bool IsGameOver()
        {
            // Placeholder for checking if the game is over
            return false;
        }
    }
}