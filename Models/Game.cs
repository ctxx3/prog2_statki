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
            SetupBoard(players[0]);
            SetupBoard(players[1]);
            // zaczęcie gry
            while (true)
            {
                // ruch gracza
                NextTurn(players[_Current_turn]);
                // sprawdzenie czy gra się skończyła
                if(IsGameOver()){
                    break;
                }
            }
            // koniec gry
        }

        private void SetupBoard(Player player){
            // Placeholder for setting up the board
        }
        private void NextTurn(Player player)
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