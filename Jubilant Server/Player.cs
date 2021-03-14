using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server
{
    class Player
    {
        public Socket socket { get; set; }
        public Role role { get; set; }
        public int money { get; set; }
        public string username { get; set; }
        public Game game { get; set; }
        public int id { get; set; }

        public Player()
        {

        }

        public Player(int id, Socket socket, Role role, int money, string username, Game game)
        {
            this.id = id;
            this.socket = socket;
            this.role = role;
            this.money = money;
            this.username = username;
            this.game = game;
        }

    }
}
