using System.IO;
using System.Linq;
using LabApi.Features.Wrappers;
using MapGeneration;
using ProjectMER.Features;
using ProjectMER.Features.Objects;
using RPF_API.Internal_API_NOTUSE;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace RPF_API.API._035Event;

public static class EventMask
{
    public static SchematicObject CurrentMask;
    public static string PathToMask;

    public static void Init()
    {
        if(!Main.Instance.Config.SchematicMask) return;
        PathToMask = Path.Combine(
            Main.Instance.Config.PathDir,
            Main.Instance.Config.SchematicMaskName
        );
        
        Logger.Info($"[RPF - API Schematic] 035 Path loaded: {PathToMask}");
    }
    public static void SpawnMask()
    {
        if (string.IsNullOrEmpty(PathToMask))
        {
            Logger.Error("[RPF - API] ERROR: PathToMask is NULL. Did you call Init()?");
            return;
        }
        Logger.Info("[RPF - API Schematic]: SCP 035 Is preparing for spawn...");
        
        if (string.IsNullOrEmpty(PathToMask))
        {
            Logger.Error("[RPF - API] ERROR: PathToMask is NULL. Did you call Init()?");
            return;
        }
        Logger.Info("[RPF - API Schematic]: SCP-035 Mask Is preparing for spawn...");

        var map = Room.Get(Main.Instance.Config.Scp035MaskSpawnRoom).FirstOrDefault();
        if (map == null)
        {
            Logger.Warn("[RPF - API Schematic]: Spawn room not found, aborting.");
            return;
        }

        Vector3 unitypos = Main.Instance.Config.Scp035MaskSpawnPosition == Vector3.zero
            ? new Vector3(map.Position.x, map.Position.y, map.Position.z)
            : Main.Instance.Config.Scp035MaskSpawnPosition;
        
        CurrentMask = ObjectSpawner.SpawnSchematic(
            PathToMask,
            unitypos,
            Quaternion.identity
        );
        
        foreach (var block in CurrentMask.AttachedBlocks)
        {
            var go = block.gameObject;

            var col = go.GetComponent<Collider>();
            if (col == null) col = go.AddComponent<BoxCollider>();
            col.isTrigger = true;

            if (go.GetComponent<behavior>() == null)
            {
                var bh = go.AddComponent<behavior>();
                bh.maskRoot = CurrentMask;
            }
        }
        Logger.Info("[RPF - API Schematic]: SCP-035 Mask spawned successfully.");
    }
    
}