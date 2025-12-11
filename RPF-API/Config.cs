using System;
using System.ComponentModel;
using System.IO;
using MapGeneration;
using UnityEngine;

namespace RPF_API;

public class Config
{
    [Description("==== [Schematics | Don't change PathDir & SoundDir] ====")]
    public string PathDir { get; set; }  = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "SCP Secret Laboratory",
        "LabAPI",
        "configs",
        "RPF-Schematics"
    );
    public string Schematic173CageName { get; set; } = "173Cage";
    public string SchematicMaskName { get; set; } = "035Mask";
    public string SchematicCage035Name { get; set; } = "035Cage";
    public string SchematicPet049Name { get; set; } = "049Pet";
    public string SchematicFemur { get; set; } = "FemurRoom";
    [Description("==== [Enable/Disable Schematics] ====")]
    public bool Schematic173Cage { get; set; } = true;
    public bool SchematicMask { get; set; } = true;
    public bool SchematicCage035 { get; set; } = true;
    public bool SchematicPet049 { get; set; } = true;
    public bool SchematicFemurBool { get; set; } = true;
    
    [Description("==== [035 Cage Spawn Settings] ====")]
    public RoomName Scp035SpawnRoom { get; set; } = RoomName.Hcz079;
    public Vector3 Scp035SpawnPosition { get; set; } = new Vector3(0f, 0f, 0f);

    [Description("==== [035 Mask Spawn Settings] ====")]
    public RoomName Scp035MaskSpawnRoom { get; set; } = RoomName.Hcz079;
    public Vector3 Scp035MaskSpawnPosition { get; set; } = new Vector3(-0.2f, 1.5f, 0.2f);
}