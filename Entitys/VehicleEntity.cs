using AltV.Net.Data;
using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using static CityRoleplay.Enums;

namespace CityRoleplay.Entitys
{
    class VehicleEntity : Vehicle
    {
        public static float MAX_FUEL = 60.0f;
        public FuleTypes FuleType { get; set; }
        public float Fuel { get; set; }
        public VehicleEntity(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {

        }

        public VehicleEntity(uint model, Position position, Rotation rotation, FuleTypes fueltype = FuleTypes.None) : base(model, position, rotation)
        {
            FuleType = fueltype;
            Fuel = 0;
            ManualEngineControl = true;
        }

        public void ToggleEngine()
        {
            if(!EngineOn && FuleType != FuleTypes.None && Fuel == 0)
            {
                MyPlayer player = (MyPlayer)NetworkOwner;
                player.SendNotification("Tank leer!");
                return;
            }
            EngineOn = !EngineOn;
        }
    }
}