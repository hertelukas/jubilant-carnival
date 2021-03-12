using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server.Packages
{
    class GameCreated : Package
    {
        private Game game;
        public GameCreated(Game game)
        {
            this.game = game;
            packageId = PackageType.GameCreated;
        }

        public override string GetContent()
        {
            return $"{game.name},{game.maxPlayers},{game.id}";
        }
    }
}
