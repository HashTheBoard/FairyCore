using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System;
using System.Collections;
using UnityEngine;

namespace FairyCore.Timer
{
    class Timetest : IScript
    {
        public Timetest()
        {
            CommandHandler.RegisterCommand("AdminJail", new Action<ShPlayer, ShPlayer, string, float>(jailing), null, null);
        }

        public void jailing(ShPlayer player, ShPlayer target, string raison, float timer)
        {
           startercoroutine(player, target, raison, timer);
        }

        public void startercoroutine(ShPlayer player, ShPlayer target, string raison, float timer)
        {
            player.svPlayer.StartCoroutine(coroutine1(player, target, raison, timer));
        }

        private IEnumerator coroutine1(ShPlayer player, ShPlayer target, string raison, float timer)
        {

            ChatHandler.SendToAll($"&4{target.username} &1a été mis en prison pour &4{timer}");
            player.svPlayer.StartJailTimer(timer);  
            Vector3 pos1 = new Vector3(-544.375f, 1, 1);
            Quaternion quaternion1 = new Quaternion(-544.375f, 1, 1, 1);
            target.svPlayer.SvRestore(pos1, quaternion1, placeIndex: 0);
            yield return new WaitForSecondsRealtime(timer);
            ChatHandler.SendToAll($"&7{target.username} est sortie de sa jail");
            // player teleport
            Vector3 pos = new Vector3(-544.375f, -43, 206);
            Quaternion quaternion = new Quaternion(-544.375f, -43, 206, 55);
            target.svPlayer.SvRestore(pos, quaternion, placeIndex: 0);
        }
     
       
    }
}