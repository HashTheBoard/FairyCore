using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System.Collections;
using UnityEngine;

namespace FairyCore.Commands
{
    class ID : IScript
    {
        public const string ddn = "ddn";
        public const string sexe = "sexe";
        public const string taille = "taille";
        public const string poid = "poid";

        public ID()
        {
            CommandHandler.RegisterCommand("createid", new Action<ShPlayer>(createid), null, null);
            CommandHandler.RegisterCommand("id", new Action<ShPlayer, ShPlayer>(giveID),null,null);
            CommandHandler.RegisterCommand("getid", new Action<ShPlayer, ShPlayer>(giveID), null, null);
        }
        public void createid(ShPlayer player)
        {           
            player.svPlayer.StartCoroutine(coroutine(player));
        }

        private IEnumerator coroutine(ShPlayer player)
        {
            player.svPlayer.SendGameMessage("écrit ton âge rp:");
            yield return new WaitForSecondsRealtime(1);
            yield break;
        }

        [Target(GameSourceEvent.PlayerGlobalChatMessage, ExecutionMode.Event)]
        public void globalmessage(ShPlayer player, string r)
        {
            if (!r.Contains("/") && r.Length == 20)
            {
                if (coroutine(player).MoveNext())
                {

                }
            }
        }

        public void giveID(ShPlayer player, ShPlayer other)
        {
            player.svPlayer.SendGameMessage($"nom et prenom{player.username}");
            player.svPlayer.SendGameMessage($"âge{player}");
        }
    }
}
