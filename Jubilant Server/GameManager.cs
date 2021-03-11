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
        private static Dictionary<int, Player> players = new Dictionary<int, Player>();

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
    }
}
