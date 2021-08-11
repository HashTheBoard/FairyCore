/*using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.Collections.Generic;
using BrokeProtocol.Collections;
using BrokeProtocol.Managers;
using UnityEngine.UI;
using System;

namespace BrokeProtocol.GameSource
{
    class tempban : IScript
    {
        public tempban()
        {
            CommandHandler.RegisterCommand("staff", new Action<ShPlayer>(tempbanprocess), null, null);
        }

        public void tempbanprocess(ShPlayer player)
        {
            SvManager manager = player.manager.svManager;
          //player.svPlayer.SendOptionMenu("staff", player.ID, "staffmenu", UnityEngine.UI.InputField.ContentType.Custom, 30);
        }

        [Target(GameSourceEvent., ExecutionMode.Event)]
        public void tempbanhandler(ShPlayer player, int targetID, string menuID, string input)
        {
            switch (menuID)
            {
                case "staffmenu":

                    break;
            }
        }
    }
}
*/