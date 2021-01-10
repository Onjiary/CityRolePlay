using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using CityRoleplay.Entitys;
using System;

namespace CityRoleplay
{
    class ChatEvents : IScript
    {
        [ClientEvent("chat:message")]
        public void ChatNachrichten(MyPlayer player, string msg)
        {
            if (msg.Length == 0 || msg[0] == '/') return;

            foreach(MyPlayer target in Alt.GetAllPlayers())
            {
                if(target.Position.Distance(player.Position) <= 10)
                {
                    player.SendChatMessage($"{player.Name} sagt: {msg}");
                }
            }
        }

        [CommandEvent(CommandEventType.CommandNotFound)]

        public void CommandNichtGefunden(MyPlayer player, string cmd)
        {
            player.SendChatMessage("{ADD8E6}[Server] {FF0000}Befehl konnte nicht gefunden werden, schauen ob er richtig geschrieben wurde!");

        }


        [Command("veh")]
        public static void VehicleErstellen(MyPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);
            if(!Enum.IsDefined(typeof(VehicleModel), vehHash))
            {
                player.SendChatMessage("[Server] Ungültige Fahrzeugname!");
                return;
            }
            //IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPostionAround(player.Position, 5.0F), player.Rotation);
            VehicleEntity veh = new VehicleEntity(vehHash, GetRandomPostionAround(player.Position, 5.0f), player.Rotation);
            veh.PrimaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);
            veh.SecondaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);

            player.SendChatMessage("Fahrzeug gespawnt!");
        }

        [Command("engine")]
        public static void CMD_Engine(MyPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            VehicleEntity veh = (VehicleEntity)player.Vehicle;
            veh.ToggleEngine();
        }

        [Command("fix")]
        public static void CMD_FIXVEH(MyPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            VehicleEntity veh = (VehicleEntity)player.Vehicle;
            veh.Repair();


        }

        public static Position GetRandomPostionAround(Position pos, float range)
        {
            Random rnd = new Random();
            float x = pos.X + (float)rnd.NextDouble() * (range * 2) - range;
            float y = pos.Y + (float)rnd.NextDouble() * (range * 2) - range;
            return new Position(x, y, pos.Z);
        }
    }
}
