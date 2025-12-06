using System.IO;
using System.Linq;
using LabApi.Features.Wrappers;
using MapGeneration;
using ProjectMER.Features;
using RPF_API.Internal_API_NOTUSE;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace RPF_API.API._035Event;

public static class MaskCageSpawn
{
    public static void SpawnCage035()
    {
        Logger.Info("[RPF - API Schematic]: Cage 035 si sta preparando allo spawn.");
        string path = Path.Combine(Main.Instance.Config.PathDir, Main.Instance.Config.SchematicCage035Name);
        var map = Room.Get(RoomName.Hcz079).FirstOrDefault();
        var roompos = new RoomPosition(map);
        
        Vector3 unitypos = new Vector3(
            map.Position.x,
            map.Position.y,
            map.Position.z
        );
        var schematic = ObjectSpawner.SpawnSchematic(
            path,
            unitypos,
            Quaternion.identity
        );
    }
    
}