using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server
{
    public class Package
    {
        public int playerId { get; set; }
        public PackageType packageId { get; set; }
        public int gameId { get; set; }
        public string version { get; set; }
        public string content { get; set; }
        public Socket socket { get; set; }

        public Package(string data, Socket socket)
        {
            this.socket = socket;

            if (string.IsNullOrEmpty(data)) return;

            //Remove <EOF>
            data = data.Substring(0, data.Length - 5);

            //Split the package
            string[] information = data.Split(":");

            try
            {
                this.playerId = Int32.Parse(information[0]);
                this.packageId = (PackageType)Int32.Parse(information[1]);
                this.gameId = Int32.Parse(information[2]);
                this.version = information[3];
                this.content = information[4];
            }catch(Exception e)
            {
                Console.WriteLine($"Error processing package: {e}");
            }
        }

        private string GetData()
        {
            string result = $"{playerId}:{(int)packageId}:{gameId}:{version}:{GetContent()}<EOF>";
            return result;
        }

        public virtual string GetContent() { return content; }

        public void Send()
        {
            Program.Send(socket, GetData());
        }
    }
}
