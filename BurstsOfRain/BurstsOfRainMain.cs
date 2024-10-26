using BepInEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BepInEx.Logging;

namespace BurstsOfRain
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class BurstsOfRainMain : BaseUnityPlugin
    {
        public const string GUID = "com.RiskofThunder.BurstsOfRain";
        public const string NAME = "Bursts of Rain";
        public const string VERSION = "0.0.1";

        private static ManualLogSource logger;

        private void Awake()
        {
            logger = Logger;
        }

        public static void AddBurstAssembly(PluginInfo info, string assemblyName)
        {
            var modLocation = info.Location;
            var directoryName = Path.GetDirectoryName(modLocation);
            if(!assemblyName.EndsWith(".dll"))
            {
                assemblyName += ".dll";
            }
            var assemblyPath = Path.Combine(directoryName, assemblyName);

            if(!File.Exists(assemblyPath))
            {
                logger.LogWarning($"Cannot to load {info.Metadata.Name}'s bursted assembly with name {assemblyName}. The requested file does not exist.");
                return;
            }

            if(!Unity.Burst.BurstRuntime.LoadAdditionalLibrary(assemblyPath))
            {
                logger.LogError($"Failed to load {info.Metadata.Name}'s bursted assembly with name {assemblyName}. Check the log fore more information.");
                return;
            }
            logger.LogInfo($"Succesfully loaded {info.Metadata.Name}'s bursted assembly of name {assemblyName}");
        }
    }
}


