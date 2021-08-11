/*using System;
using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace FairyCore.Commands
{
    internal class RobAppartement : IScript
    {
        public RobAppartement()
        {
            CommandHandler.RegisterCommand("fouille", new Action<ShPlayer, ShEntity>(this.Coffrefouille), null, null);
        }

        public void Coffrefouille(ShPlayer player, ShEntity entity)
        {
            list<ShEntity> cible = new list<ShEntity>();
            if (player.HasItem(itemIndex: -1092231192) && player.GetPlace.Equals(0))
            {
                entity = player.svPlayer.LocalEntitiesAll();
            }
        }
    }
}*/