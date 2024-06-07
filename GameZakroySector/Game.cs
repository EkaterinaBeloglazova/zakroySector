using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZakroySector
{
    public class Game
    {
        public List<Player> players;
        public List<Round> rounds;
        public Dictionary<string, int> total_score;

        public Game()
        {
            players = new List<Player>();
            rounds = new List<Round>();
            total_score = new Dictionary<string, int>();
        }

        public void CountTotalScore()
        {
            foreach (Player player in players)
                total_score[player.name] = rounds.Sum(x => x.score[player.name]);
        }

        public void CreatePlayer(string name)
        {
            players.Add(new Player(name));
        }

        public void CreateRound() 
        {
            rounds.Add(new Round());
        }

        public int CastLot(int player)
        {
            Random rand = new Random();
            int res = rand.Next(1, 7);
            players[player].value = res;
            return res;
        }

        public void OrderPlayers()
        {
            players = players.OrderByDescending(x => x.value).ToList();
        }
    }
}
