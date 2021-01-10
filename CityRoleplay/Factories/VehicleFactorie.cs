using AltV.Net;
using AltV.Net.Elements.Entities;
using CityRoleplay.Entitys;
using System;

namespace CityRoleplay.Factories
{
    class VehicleFactorie : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr entityPointer, ushort id)
        {
            return new VehicleEntity(entityPointer, id);
        }
    }
}
