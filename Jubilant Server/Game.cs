using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server
{
    class Game
    {
        private List<Player> players = new List<Player>();
        public int maxPlayers { get; set; }
        public string name { get; set; }
        public Player admin { get; set; }

        public int id { get; set; }
        public Game(string name, int maxPlayers, int id, Player admin)
        {
            this.name = name;
            this.maxPlayers = maxPlayers;
            this.id = id;
            this.admin = admin;
        }


    }
}
