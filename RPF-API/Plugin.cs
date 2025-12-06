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
    public override string Author { get; } = "Mr.Cat <3";
    public override Version Version { get; } = new Version(1,0,0);
    public override Version RequiredApiVersion { get; } = new Version(1,1,4);
    
    public override void Enable()
    {
        Instance = this;
        CreateDirectorySchematic();
        
        Logger.Info("==== RPF | Build | API ====");
        Logger.Info("Status: [VALID]");
        Logger.Info("Version: 1.0.0");
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
            string fullPath = Path.Combine(Main.Instance.Config.PathDir);
            try
            {
                if (Directory.Exists(fullPath))
                {
                    return;
                }
                else
                {
                    Logger.Info("[RPFapi - Directory]: Building The directory...");
                    Directory.CreateDirectory(fullPath);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("[RPFapi - Directory]: Error building Directory (hint: Modify the pathDir config if it is set to default): " + ex);
            }
        }
    }
}