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
                    CreateNewPlayer(package.socket).Send();                    
                    break;
                case PackageType.WelcomeReceived:
                    break;
                default:
                    break;
            }
        }

        private static WelcomeReceivedPackage CreateNewPlayer(Socket socket)
        {
            return new WelcomeReceivedPackage(counter++, socket);
        }
    }
}
