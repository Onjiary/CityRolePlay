using AltV.Net.Elements.Entities;
using CityRoleplay.Database;
using System;


namespace CityRoleplay.Entitys
{
    class MyPlayer : Player
    {
        public bool IsLoggedIn { get; set; }

        public int DB_ID { get; set; }

        public string DisplayName { get; set; }
        public uint Cash { get; set; }

        public int Team { get; set; }

        public MyPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            IsLoggedIn = false;
            Cash = 500;
            SetTeam(0);
        }

        public void Login()
        {
            IsLoggedIn = true;
        }

        public void SetTeam(int team)
        {
            Team = team;

            int color;
            switch(team)
            {
                case 0: //LSPD
                    color = 3;
                    break;
                case 1: //Grove
                    color = 2;
                    break;
                case 2:
                    color = 7;
                    break;
                default:
                    color = 4;
                    break;
            }
            SetStreamSyncedMetaData("cityroleplay:teamcolor", color);
        }


        public void SendNotification(string msg)
        {
            Emit("cityroleplay:notifi", msg);
        }

        public void CreatePlayer(string username, string password)
        {
            DisplayName = username;

            //DB_ID = PlayerDatabase.CreatePlayer(DisplayName, password);
            Login();
        }

        public void LoadPlayer(string username)
        {
            DisplayName = username;
            //PlayerDatabase.LoadPlayer(this);
            Login();
        }

        public void Save()
        {
            //PlayerDatabase.UpdatePlayer(this);
        }

    }
}
