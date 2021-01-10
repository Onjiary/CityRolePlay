using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using CityRoleplay.Database;
using CityRoleplay.Entitys;
using System.Text.RegularExpressions;

namespace CityRoleplay
{
    class Spielerevents : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        
        public void Spielerverbinden(MyPlayer player, string reason)
        {
            player.Model = (uint)PedModel.Lost02GMY;
            player.Spawn(new AltV.Net.Data.Position(0, 0, 75),0);


            if(PlayerDatabase.DoesPlayerNameExists(player.Name))
            {
                player.LoadPlayer(player.Name);
            }
            else
            {
                player.CreatePlayer(player.Name, "1234");
            }
            //player.SendNotification($"Cash: ~b~{player.Cash}$");
            player.SendNotification($"Cash: ~b~{player.Cash}$");
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public void Spielertot(MyPlayer player, IEntity killer, uint weapon)
        {
            player.Spawn(new AltV.Net.Data.Position(0, 0, 75),0);
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void Spielerverlassen(MyPlayer player, string reason)
        {
            if (player.IsLoggedIn) player.Save();
        }



        [ScriptEvent(ScriptEventType.PlayerEnteringVehicle)]
        public void Fahrzeugbetreten(VehicleEntity vehicle, MyPlayer player, byte seat)
        {
            vehicle.SecondaryColorRgb = new Rgba(255, 0, 0, 255);
            player.SendNotification("Fahrzeug betreten!");
        }

        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public void Fahrzeugverlassen(VehicleEntity vehicle, MyPlayer player, byte seat)
        {
            vehicle.SecondaryColorRgb = new Rgba(255, 255, 255, 255);
            player.SendNotification("Fahrzeug verlassen!");
        }




    }
}
