using System;
using System.Collections.Generic;
using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace FairyCore.Commands
{
    class Tempmute : IScript
    {
        public Tempmute()
        {
            CommandHandler.RegisterCommand("tempmute", new Action<ShPlayer>(tempmuteprocess), null, null);
        }

        public void tempmuteprocess(ShPlayer player)
        {
            
        }
    }
}
