using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace FairyCore.Commands
{
    class NickName
    {
        public NickName()
        {
            CommandHandler.RegisterCommand("nick", new Action<ShPlayer, ShPlayer, string>(nick), null, null);
        }

        public void nick(ShPlayer player, ShPlayer other, string name)
        {
            if(name.Length >= 16) return;
            other.svPlayer.SvUpdateDisplayName(name);
        }
    }
}
