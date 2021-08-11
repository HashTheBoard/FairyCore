using System;
using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace FairyCore.Commands
{
    class CommandInfo : IScript
    {
        public CommandInfo()
        {
            CommandHandler.RegisterCommand("recrutement-rfpd", new Action<ShPlayer>(this.rfpdrecruit), null, null);
            CommandHandler.RegisterCommand("regles", new Action<ShPlayer>(this.regles), null, null);
        }
        public void rfpdrecruit(ShPlayer player)
        {
            player.svPlayer.SvOpenURL("https://forms.gle/1rqJdfmBvqDgQNS29");
        }

        public void regles(ShPlayer player)
        {
            player.svPlayer.SvOpenURL("https://docs.google.com/document/d/1iRwepbAXTfgOmuyN2pNySFqek7Fi1n_PvlZ_TKXs4KU/edit?usp=sharing");
        }
    }
}
