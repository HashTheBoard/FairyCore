using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;
using System;
using System.Linq;

namespace CoreEssential.commands
{
    internal class InventoryManage : IScript
    {
        public InventoryManage()
        {
            CommandHandler.RegisterCommand("clearinventory", new Action<ShPlayer, ShPlayer>(clearinventory), null, null);
            CommandHandler.RegisterCommand("invsee", new Action<ShPlayer, ShPlayer>(invsee), null, null);
        }

        public void clearinventory(ShPlayer player, ShPlayer other)
        {
            foreach (var item in other.myItems.ToList())
            {
                other.TransferItem(DeltaInv.RemoveFromMe, item.Key);
            }
            player.svPlayer.SendGameMessage("&0[RF-&cSTAFF&0] &6Tu as bien clear " + other.username + " tous les items de son inventaire");
            other.svPlayer.SendGameMessage("&0[RF-&cSTAFF&0] &6Ton inventaire a été clear");
        }

        public void invsee(ShPlayer player, ShPlayer other)
        {
            player.svPlayer.SvSearch(other.ID);
            player.svPlayer.SendTextMenu("&0[RF-&cSTAFF&0] &6L'inventaire du joueur : " + other, $" le joueur {other.username} as les objets : ");
        }
    }
}