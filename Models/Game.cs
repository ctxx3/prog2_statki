using System.Reflection.Metadata.Ecma335;

namespace prog2_statki.Models
{
    public class Game
    {
        private int _Current_turn;

        private Player[] players = new Player[2];

        public void Start()
        {
            // ustawianie plansz
            players[0].SetupBoard();
            players[1].SetupBoard();
            // zaczęcie gry
            while (true)
            {
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
        }

        private bool IsGameOver()
        {
            // Placeholder for checking if the game is over
            return false;
        }
    }
}