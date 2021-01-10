using AltV.Net;
using AltV.Net.Elements.Entities;
using CityRoleplay.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityRoleplay.Factories
{
    class PlayerFactorie : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr entityPointer, ushort id)
        {
            return new MyPlayer(entityPointer, id);
        }
    }
}
