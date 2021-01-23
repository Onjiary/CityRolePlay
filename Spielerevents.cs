using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using CityRoleplay.Database;
using CityRoleplay.Entitys;
using System.Text.RegularExpressions;
using AltV.Net.Native;

namespace CityRoleplay
{
    class Spielerevents : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]

        public void Spielerverbinden(MyPlayer player, string reason)
        {
            player.Model = (uint)PedModel.Lost02GMY;
            player.Spawn(new AltV.Net.Data.Position(257.18243f, -885.61316f, 29.17871f), 0);
            player.Emit("CityRoleplay:configflags");

            /*if (PlayerDatabase.DoesPlayerNameExists(player.Name))
            {
                player.LoadPlayer(player.Name);
            }
            else
            {
                player.CreatePlayer(player.Name, "1234");
            }
            //player.SendNotification($"Cash: ~b~{player.Cash}$");
            player.SendNotification($"Cash: ~b~{player.Cash}$"); */
        }

         [ScriptEvent(ScriptEventType.PlayerDead)]
        public void Spielertot(MyPlayer player, IEntity killer, uint weapon)
        {
            player.Spawn(new AltV.Net.Data.Position(257.18243f, -885.61316f, 29.17871f), 0);
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


        [ClientEvent("CityRolePlay:loginAttempt")]
        public void LogginAttempt(MyPlayer player, string username, string password)
        {
            if (player.IsLoggedIn || username.Length < 4 || password.Length < 4) return;

            Regex regex = new Regex(@"([a-zA-Z]+)_([a-zA-Z]+)");

            if(!regex.IsMatch(username))
            {                player.Emit("CityRolePlay:loginError", 1, "Der Name muss dem Format: Vorname_Nachname entsprechen.");
                return;
            }

            if(!PlayerDatabase.DoesPlayerNameExists(username))
            {
                player.Emit("CityRolePlay:loginError", 1, "Der Name ist nicht vergeben!");
                return;
            }


            if(!PlayerDatabase.CheckLoginDetails(username, password))
            {
                player.LoadPlayer(username);
                player.Spawn(new Position(257.18243f, -885.61316f, 29.17871f), 0);
                player.Emit("CityRolePlay:loginSuccess");
                player.SendNotification("Erfolgreich eingeloggt");
                if (player.HasData("CityRolePlay:registerAttempt")) player.DeleteData("CityRolePlay:loginAttempt");
            }else
            {
                player.Emit("CityRolePlay:loginError", 1, "Login Daten stimmen nicht überein");

                int attempts = 1;
                if(player.HasData("CityRolePlay:loginAttempt"))
                {
                    player.GetData("CityRolePlay:loginAttempt", out attempts);

                    if (attempts == 2) player.Kick("Zu viele Loginversuche");
                    else attempts++;
                }
                player.SetData("CityRolePlay:loginAttempt", attempts);
            }
        }




        [ClientEvent("CityRolePlay:registerAttempt")]
        public void RegisterAttempt(MyPlayer player, string username, string password)
        {
            if (player.IsLoggedIn || username.Length < 4 || password.Length < 4) return;

            Regex regex = new Regex(@"([a-zA-Z]+)_([a-zA-Z]+)");

            if(!regex.IsMatch(username))
            {
                player.Emit("CityRolePlay:loginError", 1, "Der Name muss dem Format: Vorname_Nachnahme entsprechen");
                return;
            }

            if(PlayerDatabase.DoesPlayerNameExists(username))
            {
                player.Emit("CityRolePlay:loginError", 2, "Name ist bereits vergeben");

            }else
            {
                player.CreatePlayer(username, password);
                player.Spawn(new Position(-1042.6945f, -2745.956f, 21.343628f), 0);
                player.Emit("CityRolePlay:loginSuccess");
            }
        }

    }
}
