using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokeProtocol.API;
using System.Collections;
using UnityEngine;
using BrokeProtocol.Entities;

namespace FairyCore.Commands
{
    class AdminCommand : IScript
    {
        public AdminCommand()
        {
            CommandHandler.RegisterCommand("freeze", new Action<ShPlayer, ShPlayer>(this.freeze), null, null);
            CommandHandler.RegisterCommand("unfreeze", new Action<ShPlayer, ShPlayer>(this.unfreeze), null, null);
        }

        public void freeze(ShPlayer player, ShPlayer other)
        {
           player.svPlayer.StartCoroutine(enumerator(player, other));
        }
        public void unfreeze(ShPlayer player, ShPlayer other)
        {
            other.svPlayer.StopCoroutine(enumerator(player, other));
        }

        private IEnumerator enumerator(ShPlayer player, ShPlayer other)
        {
            var p = other.GetPosition;
            var f = other.GetRotation;
            var q = other.GetPlaceIndex;
            while (true)
            {
                other.svPlayer.SvRestore(p,f,q);
                yield return new WaitForSeconds(0.70f);
            }
            yield break;
        }
    }
}
