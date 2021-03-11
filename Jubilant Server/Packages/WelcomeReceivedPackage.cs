

using System.Net.Sockets;

namespace Jubilant_Server.Packages
{
    class WelcomeReceivedPackage : Package
    {
        public WelcomeReceivedPackage(int id, Socket socket) : base("", socket)
        {
            playerId = id;
            packageId = PackageType.WelcomeReceived;
        }

        public override string GetContent()
        {
            return "Welcome received.";
        }
    }
}