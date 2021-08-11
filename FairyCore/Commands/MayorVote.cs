using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;
using UnityEngine;

namespace FairyCore.Commands
{
    class MayorVote : IScript
    {
        public MayorVote()
        {
            CommandHandler.RegisterCommand("JoinMayor", new Action<ShPlayer>(Mayor), null, null);  
        }
        [Target(GameSourceEvent.PlayerCrime,ExecutionMode.Event)]
        public void Mayor(ShPlayer player)
        {
           
        }
    }
}
