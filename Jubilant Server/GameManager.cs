using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server
{
    static class GameManager
    {

        private static int counter = 0;
        private static int gameCounter = 0;
        public static Dictionary<int, Player> players = new Dictionary<int, Player>();
        public static Dictionary<int, Game> games = new Dictionary<int, Game>();

        public static void HandlePackage(string data, Socket socket)
        {
            Package package = new Package(data, socket);
            HandlePackage(package);
        }

        public static void HandlePackage(Package package)
        {
            Console.WriteLine($"Handling Package {package.packageId}. Sender: {package.playerId}");

            switch (package.packageId)
            {
                case PackageType.Welcome:
                    CreateNewPlayer(package.socket, package.content).Send();                    
                    break;
                case PackageType.WelcomeReceived:
                    break;
                case PackageType.CreateGame:
                    CreateNewGame(package.content, package.playerId).SendToAllPlayers();
                    break;
                default:
                    break;
            }
        }

        private static Package CreateNewPlayer(Socket socket, string username)
        {
            foreach (var player in players)
            {
                if (player.Value.username == username) return new Packages.UsernameTakenPackage(-1, socket);
            }

            Player newPlayer = new Player(socket, Role.Unknown, 0, username, null);
            players.Add(counter++, newPlayer);
            return new Packages.WelcomeReceivedPackage(counter, socket);
        }

        private static Package CreateNewGame(string content, int player)
        {
            string[] data = content.Split(",");
            int maxPlayers = 15;
            try
            {
                maxPlayers = Int32.Parse(data[1]);
            }
            catch(Exception)
            {
                Console.WriteLine("Unable to parse maxPlayers. Setting to default");
            }
            Game newGame = new Game(data[0], maxPlayers, gameCounter++, players.GetValueOrDefault(player));
            games.Add(gameCounter, newGame);
            return new Packages.GameCreated(newGame);
        }
    }
}
