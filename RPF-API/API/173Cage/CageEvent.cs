using System.IO;
using System.Linq;
using LabApi.Features.Wrappers;
using PlayerRoles;
using ProjectMER.Features;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace RPF_API.API._173Cage;

public static class CageEvent
{
    public static void SpawnCage()
    {
        Player scp173 = Player.List.FirstOrDefault(p => p.Role == RoleTypeId.Scp173);
        string schematicName = Main.Instance.Config.SchematicCageName;
        string fullPath = Path.Combine(Main.Instance.Config.PathDir, schematicName);
        
        if (scp173 == null)
        {
            Logger.Info("[RPF - API Schematic]: Scp-173 NON è spawnato, la schematica non si carica.");
            return;
        }   
        Logger.Info("[RPF - API Schematic]: Cage 173 si sta preparando allo spawn.");
        UnityEngine.Vector3 unityPos = new UnityEngine.Vector3(
            scp173.Position.x,
            scp173.Position.y,
            scp173.Position.z
        );
        
        var schematic = ObjectSpawner.SpawnSchematic(
            fullPath,
            unityPos,
            Quaternion.identity
        );
        
        if (schematic != null)
        {
            Logger.Info("[RPF-API Schematic]: Schematica Trovata!");
        }
        else
        {
            Logger.Error("[RPF-API Schematic]: Schematica NON trovata!");
        }
    }
    
}