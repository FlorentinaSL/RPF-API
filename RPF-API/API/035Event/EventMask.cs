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
    public static Vector3 unitypos = new Vector3(0,0,0);
    public static string path = Path.Combine(Main.Instance.Config.PathDir, Main.Instance.Config.SchematicMaskName);
    public static void SpawnMask()
    {
        Logger.Info("[RPF - API Schematic]: SCP 035 si sta preparando allo spawn.");
        var map = Room.Get(RoomName.Hcz079).FirstOrDefault();
        var roomPos = new RoomPosition(map);
        unitypos = roomPos.Position + new Vector3(-0.2f,1.5f,0.2f);

        CurrentMask = ObjectSpawner.SpawnSchematic(
            path,
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