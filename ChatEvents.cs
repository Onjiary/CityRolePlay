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


        [Command("pos")]
        public void cmd_Spielerposition(MyPlayer player)
        {
            player.SendChatMessage($"Aktuelle Position: X: {player.Position.X} Y:{player.Position.Y} Z: {player.Position.Z}");
        }



        [Command("veh")]
        public static void VehicleErstellen(MyPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);
            /*if(!Enum.IsDefined(typeof(VehicleModel), vehHash))
            {
                player.SendChatMessage("[Server] Ungültiger Fahrzeugname!");
                return;
            } */

            VehicleEntity veh;

            if(player.HasData("CityRoleplay:vehicle"))
            {
                player.GetData("CityRoleplay:vehicle", out veh);
                veh.Remove();
            }
            //IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPostionAround(player.Position, 5.0F), player.Rotation);
            veh = new VehicleEntity(vehHash, GetRandomPostionAround(player.Position, 5.0f), player.Rotation);
            veh.PrimaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);
            veh.SecondaryColorRgb = new Rgba(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b), 255);

            player.SetData("CityRoleplay:vehicle", veh);

            player.SendChatMessage("Fahrzeug gespawnt!");
        }

        [Command("vehicle")]
        public static void Vehiclebauen(MyPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);
            IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPostionAround(player.Position, 5.0f), player.Rotation);
            veh = new VehicleEntity(vehHash, GetRandomPostionAround(player.Position, 5.0f), player.Rotation);
            player.SetData("Cityroleplay:vehicle", veh);
            player.SendNotification("Fahrzeuge erstellt!");
        }

        [Command("waffengeben")]
        public static void Waffengeben(MyPlayer player, string weaponName, int ammo)
        {
            uint weaponHash = Alt.Hash(weaponName);
            if (!Enum.IsDefined(typeof(WeaponModel), weaponHash))
            {
                player.SendNotification("~r~[Server] Ungültiger Waffenname");
                return;
            }
            player.GiveWeapon(weaponHash, ammo, true);
        }
    
        [Command("engine")]
        public static void CMD_Engine(MyPlayer player)
        {
            if (!player.IsInVehicle || player.Seat != 1) return;
            VehicleEntity veh = (VehicleEntity)player.Vehicle;
            veh.ToggleEngine();
        }


        [Command("hilfe")]
        public static void CMD_HILFE(MyPlayer player)
        {
            player.SendNotification("Folgende befehle gibt es auf dem Server:  /hilfe(um zu sehen welche befehle es gibt),   /fix(auto reparieren), /pos(um die korrdianten zu bekommen)," +
                " /team(um spieler Teams zu geben), /vehicle(fahrzeugnamen),  /veh(auto spawnt nur 1 was immer nach neu spawnen verschwindet), ");
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

        [Command("team")]
        public static void CMD_Team(MyPlayer player, int team)
        {
            player.SetTeam(team);
        }
    }
}
