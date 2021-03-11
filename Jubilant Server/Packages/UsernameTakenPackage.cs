using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server.Packages
{
    class UsernameTakenPackage : Package
    {

        public UsernameTakenPackage(int id, Socket socket) : base("", socket)
        {
            playerId = id;
            packageId = PackageType.UsernameTaken;
        }
    }
}
