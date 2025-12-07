using System.IO;
using LabApi.Features.Wrappers;
using ProjectMER.Features;
using UnityEngine;

namespace RPF_API.API.CustomPet;

public static class SpawnPet
{
    //Custom Pet =)
    public static void SpawnCustomPet049(Player player)
    {
        if (!Main.Instance.Config.SchematicPet049) return;
        string Name = Path.Combine(Main.Instance.Config.PathDir, Main.Instance.Config.SchematicPet049Name);
        Vector3 targetpos = new Vector3(player.Position.x, player.Position.y, player.Position.z);
        var schematic = ObjectSpawner.SpawnSchematic(
            Name,
            targetpos,
            Quaternion.identity
        );
        var petParent = new GameObject("PetSchematic");
        petParent.transform.position = targetpos;
        
        foreach (var block in schematic.AttachedBlocks)
        {
            block.gameObject.transform.parent = petParent.transform;
        }
        
        var follower = petParent.AddComponent<behavior>();
        follower.targetPlayer = player;
        follower.followSpeed = 5f;
    }
}