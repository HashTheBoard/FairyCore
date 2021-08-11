using System;
using System.Collections.Generic;
using System.Linq;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Managers;
using BrokeProtocol.Utility;
using BrokeProtocol.Required;

namespace FairyCore.Commands
{
    class darknet
    {
        private List<LabelID> weaponchoose = new List<LabelID>();
        private Dictionary<String, ShPlayer> wc = new Dictionary<String, ShPlayer>();


        public darknet()
        {
            CommandHandler.RegisterCommand("darknet", new Action<ShPlayer>(darknethub), null, null);
        }

        public void darknethub(ShPlayer player)
        {
            player.svPlayer.SendInputMenu("Lien", player.ID , "darknetlink",UnityEngine.UI.InputField.ContentType.Custom, 30);
        }

        [Target(GameSourceEvent.PlayerSubmitInput, ExecutionMode.Event)]
        public void darknetlinkhandler(ShPlayer player,int targetID,string menuID,string input)
        {
            if (menuID == "darknetlink")
            {
                //Differents sites
                switch (input)
                {
                    case "www.badweapon.com":
                        List<LabelID> list = new List<LabelID>();
                        list.Add(new LabelID("Acheter", "Achat"));
                        list.Add(new LabelID("Vendre", "Vente"));
                        player.svPlayer.SendOptionMenu("&4[Arme/s illegal/s]", player.ID, "weaponbad-lol", list.ToArray(), new LabelID[1] { new LabelID("Choisir", "Choisir") });
                        break;
                }
                if(input == null || input != "www.badweapon.com")
                {
                    player.svPlayer.SendGameMessage("&0[RF-Darnet] &6Lien invalide, tu es recherché par la police !");
                    ChatHandler.SendToAll($"&0[RF-Darnet-&bRFPD] &cUn Crime a était comis par {player.username}");
                }
            }
            if (menuID == "darknetventweapon")
            {
                wc.Add(input, player);
                weaponchoose.Add(new LabelID(input,player.ID.ToString()));
            }
        }

        [Target(GameSourceEvent.PlayerOptionAction, ExecutionMode.Event)]
        public void badweapon(ShPlayer player, int targetID, string menuID, string optionID, string actionID)
        {
            if(menuID == "weaponbad-lol")
            {
                if(optionID == "Vente")
                {
                    player.svPlayer.SendInputMenu("Mettez ce que vous vendez", player.ID, "darknetventweapon", UnityEngine.UI.InputField.ContentType.Custom, 30);
                }
                else if(optionID == "Achat")
                {
                    player.svPlayer.SendOptionMenu("&4[Achat d'arme Illégal]", player.ID, "darknetachatweapon", weaponchoose.ToArray(), new LabelID[1] { new LabelID("Choisir", "Choisir") });
                }
                else if(menuID == "darknetachatweapon")
                {
                    ShPlayer seller;

                    if (wc.TryGetValue(optionID, out seller))
                    {
                        player.svPlayer.StartGoalMarker(seller);
                        seller.svPlayer.SendGameMessage("[DarkNet Message]: Quelqu'un souhaite vous achetez un article");
                    }   
                }
            }
        }

        public void HackProcess(ShPlayer p)
        {
           
        }
    }
}