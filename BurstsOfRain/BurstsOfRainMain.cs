using BepInEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BepInEx.Logging;

namespace BurstsOfRain
{
    /// <summary>
    /// Main class for Bursts of Rain which contains the assembly loader.
    /// </summary>
    [BepInPlugin(GUID, NAME, VERSION)]
    public class BurstsOfRainMain : BaseUnityPlugin
    {
        /// <summary>
        /// GUId of the Mod
        /// </summary>
        public const string GUID = "com.RiskofThunder.BurstsOfRain";
        /// <summary>
        /// Human readable name of the mod
        /// </summary>
        public const string NAME = "Bursts of Rain";
        /// <summary>
        /// Version of the mod
        /// </summary>
        public const string VERSION = "0.0.1";

        private static ManualLogSource logger;

        private void Awake()
        {
            logger = Logger;
        }

        /// <summary>
        /// Adds a new Burst compiled assembly to the Burst Runtime. The final path is <see cref="Path.Combine(string, string)"/> with the <paramref name="info"/>'s <see cref="PluginInfo.Location"/> and <paramref name="assemblyName"/> as the arguments.
        /// </summary>
        /// <param name="info">The plugin that's adding the new assembly, this is also the starting directory for the assembly.</param>
        /// <param name="assemblyName">The name of the assembly to load.</param>
        /// <returns>True if the assembly was loaded succesfully, otherwise it returns false.</returns>
        public static bool AddBurstAssembly(PluginInfo info, string assemblyName)
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
                return false;
            }

            if(!Unity.Burst.BurstRuntime.LoadAdditionalLibrary(assemblyPath))
            {
                logger.LogError($"Failed to load {info.Metadata.Name}'s bursted assembly with name {assemblyName}. Check the log fore more information.");
                return false;
            }
            logger.LogInfo($"Succesfully loaded {info.Metadata.Name}'s bursted assembly of name {assemblyName}");
            return true;
        }
    }
}


