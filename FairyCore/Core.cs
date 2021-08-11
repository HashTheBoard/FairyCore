using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.IO;
using Newtonsoft.Json;

namespace FairyCore
{
    public class Core : Plugin
    {
        public Core()
        {
            Info = new PluginInfo("FairyCore by {'ya80','helltagne','skyreth'}", "fairy");
        }

        public void LoadConfig()
        {
            if(!Directory.Exists("Plugins/settings/CoreRockFord"))
            {
                Directory.CreateDirectory("Plugins/settings/CoreRockFord");
            }
            if(!File.Exists("Plugins/settings/CoreRockFord/tempmute.json"))
            {
                /*JsonSerializer.Create("");*/
                File.Create("Plugins/settings/CoreRockFord/tempmute.json");
            }
        }
    }
}