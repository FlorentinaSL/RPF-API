using System.Linq;
using LabApi.Features.Wrappers;
using MapGeneration;
using UnityEngine;

namespace RPF_API.Internal_API_NOTUSE
{
    public class RoomPosition
    {
        public Room Room { get; }
        public Vector3 Position { get; }

        internal RoomPosition(Room room)
        {
            Room = room;
            
            if (Room.Doors.Any())
            {
                Position = Room.Doors.First().Position;
                return;
            }
            
            var centerProp = room.GetType().GetProperty("Center");
            if (centerProp != null)
            {
                Position = (Vector3)centerProp.GetValue(room);
                return;
            }
            
            Position = Vector3.zero;
        }

        public static RoomPosition? Get(RoomName name)
        {
            var room = LabApi.Features.Wrappers.Room.Get(name).FirstOrDefault();
            return room == null ? null : new RoomPosition(room);
        }
    }
}