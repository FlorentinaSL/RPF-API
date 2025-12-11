using System;
using System.IO;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;

namespace RPF_API;

public class Main : Plugin<Config>
{
    public static Main Instance { get; private set; } 
    
    public override string Name { get; } = "RPF-API";
    public override string Description { get; } = "API that need for RPFunctions Plugin";
    public override string Author { get; } = "Florentina <3";
    public override Version Version { get; } = new Version(1,3,0);
    public override Version RequiredApiVersion { get; } = new Version(1,1,4);
    
    public override void Enable()
    {
        Instance = this;
        CreateDirectorySchematic();
        
        Logger.Info("==== RPF | Build | API ====");
        Logger.Info("Status: [VALID]");
        Logger.Info($"Version: {Version}");
        Logger.Info("Badge: None");
        Logger.Info("===========================");    
        
        Logger.Info("[RPF-API Status]: API Is avaible.");
    }

    public override void Disable()
    {
        Logger.Info("[RPF-API]: API Is disabling...");
    }
    
    public void CreateDirectorySchematic()
    {
        if (Main.Instance.Config != null)
        {
            string schematicsDir = string.IsNullOrEmpty(Main.Instance.Config.PathDir)
                ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "SCP Secret Laboratory", "LabAPI", "configs", "RPF-Schematics")
                : Main.Instance.Config.PathDir;
            try
            {
                if (Directory.Exists(schematicsDir))
                {
                    return;
                }
                else
                {
                    Logger.Info($"[RPFapi - Directory]: Building The directory in: {schematicsDir}");
                    Directory.CreateDirectory(schematicsDir);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("[RPFapi - Directory]: Error building Directory (hint: Modify the pathDir config if it is set to default): " + ex);
            }
        }
    }
}