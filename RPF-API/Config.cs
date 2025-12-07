using System;
using System.ComponentModel;
using System.IO;

namespace RPF_API;

public class Config
{
    [Description("==== [Schematics | Don't change PathDir] ====")]
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
    [Description("==== [Enable/Disable Schematics] ====")]
    public bool Schematic173Cage { get; set; } = true;
    public bool SchematicMask { get; set; } = true;
    public bool SchematicCage035 { get; set; } = true;
    public bool SchematicPet049 { get; set; } = true;
}