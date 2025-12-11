using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using LabApi.Features.Wrappers;
using MapGeneration;
using MEC;
using PlayerRoles;
using ProjectMER.Features;
using UnityEngine;

namespace RPF_API.API.FemurBreaker;

public static class Femur
{
    public static event Action OnFemurAnimationFinished;
    public static void FemurSpawn()
    {
        if (!Main.Instance.Config.SchematicFemurBool) return;
        string path = Path.Combine(Main.Instance.Config.PathDir, Main.Instance.Config.SchematicFemur);
        Room room = Room.Get(RoomName.Hcz106).FirstOrDefault();
        Vector3 pos = room.Position;
        Player p = Player.List.FirstOrDefault(p => p.Role == RoleTypeId.Scp106);
        
        var schematic = ObjectSpawner.SpawnSchematic(
            path,
            pos,
            Quaternion.identity
        );
        
        Timing.CallDelayed(0.5f, () =>
        {
            schematic.AnimationController.Play("Cube (16)");
            float duration = 1.40f;
            Timing.CallDelayed(duration, () =>
            {
                OnFemurAnimationFinished?.Invoke();
                p.Position += schematic.Position + new Vector3(0, 4, 0);
                Timing.WaitForSeconds(0.2f);
                p.Kill();
            });
        });
    }
    
}