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
    public static string PathToMask;
    public static void Init()
    {
        if (!Main.Instance.Config.SchematicCage035) return;
        PathToMask = Path.Combine(
            Main.Instance.Config.PathDir,
            Main.Instance.Config.SchematicCage035Name
        );
        
        Logger.Info($"[RPF - API Schematic] 035 Cage Path loaded: {PathToMask}");
    }
    public static void SpawnCage035()
    {
        Logger.Info("[RPF - API Schematic]: Cage 035 Is preparing for spawn...");
        var map = Room.Get(RoomName.Hcz079).FirstOrDefault();
        var roompos = new RoomPosition(map);
        
        Vector3 unitypos = new Vector3(
            map.Position.x,
            map.Position.y,
            map.Position.z
        );
        var schematic = ObjectSpawner.SpawnSchematic(
            PathToMask,
            unitypos,
            Quaternion.identity
        );
    }
    
}