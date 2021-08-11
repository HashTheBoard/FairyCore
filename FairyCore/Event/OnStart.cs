using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System.Collections.Generic;
using BrokeProtocol.Managers;
using UnityEngine;

namespace FairyCore.Event
{
    internal class OnStart : IScript
    {
        [Target(GameSourceEvent.PlayerReady, ExecutionMode.Event)]
        public void readyplayer(ShPlayer player)
        {
            player.svPlayer.SvUpdateDisplayName(player.ID.ToString());
        }

        [Target(GameSourceEvent.PlayerDamage, ExecutionMode.Event)]
        public void OnDamage(ShPlayer player, DamageIndex damageIndex, float amount, ShPlayer attacker, Collider collider, float hitY)
        {
            if (damageIndex == DamageIndex.Collision && player.IsDriving && player.IsDead)
            {
                ChatHandler.SendToAll($"&0[ RF-Mort ] &6Le joueur {player} à fait un accident de la route !");
            }
            else if (damageIndex == DamageIndex.Gun && player.IsDead)
            {
                ChatHandler.SendToAll($"&0[ RF-Mort ] &6Le joueur {player} c'est pris la balle de sa vie par {attacker.username}");
            }
            else if (damageIndex == DamageIndex.Melee && player.IsDead)
            {
                ChatHandler.SendToAll($"&0[ RF-Mort ] &6Le joueur {player} c'est fait prendre en octogon par {attacker.username}");
            }
            else if (damageIndex == DamageIndex.Stun)
            {
                ShPlayer player1 = new ShPlayer();
                List<ShPlayer> list = new List<ShPlayer>();
                if (player1.svPlayer.HasPermission("logs.test"))
                {
                    list.Add(player1);
                }
                ChatHandler.SendToList($"&0[ RF-Mort ] &6Le joueur {player} c'est fait tazer par {attacker.username}", list);
            }
        }

        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void onstart(SvManager manager)
        {
            manager.SvSetWeatherFraction(0);
            Debug.Log("&0[ RF-Météo ] &bDésactivation de la pluie...");
        }
    } 
}