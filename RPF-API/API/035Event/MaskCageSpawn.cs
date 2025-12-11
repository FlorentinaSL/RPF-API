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
        var map = Room.Get(Main.Instance.Config.Scp035SpawnRoom).FirstOrDefault();
        if (map == null)
        {
            Logger.Warn("[RPF - API Schematic]: Spawn room not found, aborting.");
            return;
        }

        Vector3 unitypos = Main.Instance.Config.Scp035SpawnPosition == Vector3.zero
            ? new Vector3(map.Position.x, map.Position.y, map.Position.z)
            : Main.Instance.Config.Scp035SpawnPosition;

        var schematic = ObjectSpawner.SpawnSchematic(
            PathToMask,
            unitypos,
            Quaternion.identity
        );
        Logger.Info("[RPF - API Schematic]: Cage 035 spawned successfully.");
    }
    
}