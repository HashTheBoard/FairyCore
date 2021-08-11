using BrokeProtocol.API;
using System;
using BrokeProtocol.Entities;
using System.Collections.Generic;
using BrokeProtocol.Utility;

namespace FairyCore.Commands
{
    class RoleCommand : IScript
    {
        public RoleCommand()
        {   
            CommandHandler.RegisterCommand("Annonce", new Action<ShPlayer, String>(CommandAnnonce), null, null);
            CommandHandler.RegisterCommand("me", new Action<ShPlayer, String>(CommandMe), null, null);
            CommandHandler.RegisterCommand(new List<string>{"ooc","/","hrp"}, new Action<ShPlayer, String>(CommandOcc), null, null);
            CommandHandler.RegisterCommand("crime", new Action<ShPlayer, String>(CommandCrime), null, null);
            CommandHandler.RegisterCommand("it", new Action<ShPlayer, String>(CommandObjectI), null, null);
            CommandHandler.RegisterCommand("roll", new Action<ShPlayer>(roletest), null, null);
            CommandHandler.RegisterCommand("Anon", new Action<ShPlayer, string>(CommandObjetAnon), null, null);
        }

        public void roletest(ShPlayer player) {
            Random rand = new Random();
            ChatHandler.SendToAll($"*{player.username} à tiré un {rand.Next(0,100)}");
        }

        public void CommandAnnonce(ShPlayer player, String message) {
            ChatHandler.SendToAll("&4[ Annonce ] : &f" + message);
        }

        public void CommandOcc(ShPlayer player, String message) {
            ChatHandler.SendToAll("&d[ OOC ] | " + player.username + ": &f" + message);
        }
        
        public void CommandMe(ShPlayer player, String message) {
            ChatHandler.SendToAll("&7* " + player.username + " : " + message);
            player.svPlayer.SvLocalChatMessage(message);
        }

        public void CommandCrime(ShPlayer player, String message) {
            ChatHandler.SendToAll("&4[ CRIME ] : " + message);
        }

        public void CommandObjectI(ShPlayer player, String message) {
            ChatHandler.SendToAll("&a*" + player.username + message);
        }

        public void CommandObjetAnon(ShPlayer player, string message) {
            ChatHandler.SendToAll("&c[ Anonyme ] : &r" + message);
        }

    }
}
