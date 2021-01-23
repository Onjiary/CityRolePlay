using AltV.Net;
using AltV.Net.Elements.Entities;
using CityRoleplay.Factories;
using CityRoleplay.Database;


namespace CityRoleplay
{
    class Server : Resource
    {
        public override void OnStart()
        {
            Alt.Log("<<<< Server wurde gestartet! >>>>");
            new MyDatabase();
            Alt.Log("Blip Manager startet");
        }

        public override void OnStop()
        {

        }

        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactorie();
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new PlayerFactorie();
        }
    }
}
