using System.ComponentModel;

namespace RPF_API;

public class Config
{
    [Description("==== [Schematics | NON TOCCARE] ====")]
    public string PathDir { get; set; } = @"Example Path";
    public string SchematicCageName { get; set; } = "173Cage";
    public string SchematicMaskName { get; set; } = "035Mask";
    public string SchematicCage035Name { get; set; } = "035Cage";
    public string SchematicPet049Name { get; set; } = "049Pet";
}