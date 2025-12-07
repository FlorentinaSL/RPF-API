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
        var map = Room.Get(RoomName.Hcz079).FirstOrDefault();
        var roomPos = new RoomPosition(map);
        var unitypos = roomPos.Position + new Vector3(-0.2f,1.5f,0.2f);
    
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
    }
    
}