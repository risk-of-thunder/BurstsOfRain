# Bursts of Rain

Bursts of Rain is a lightweight assembly loader that's used to load Burst compiled unity assemblies, allowwing for the usage of Burst-Compiled Jobs within mods for Risk of Rain 2.

To allow for the full utilization of the Data Oriented Technology Stack (DOTS)'s systems, this Thunderstore Package redistributes the following unity assemblies, which are not found within the base game:

| Assembly | Unity Package Version |
|--|--|
| System.Runtime| Not Applicable |
| Unity.Burst | 1.8.18 |
| Unity.Collections | 1.5.1 |
| Unity.Mathematics | 1.2.6 |

These assemblies should not cause issues on existing profiles.

## For Developers

Bursts of Rain is used mainly as a front-end and ease of loading for Bust Assemblies utilizing ``BurstRuntime.LoadAdditionalLibrary``'s method, ``BurstsOfRainMain`` contains a method that can be used to simplify this process, by giving it your ``PluginInfo``, which serves as the start location, and a ``string``, which should be the name of the bursted assembly.

    //Example
    public class MyModWithBurstedAssemblies : BaseUnityPlugin
    {
        private void Awake()
        {
            //Load the assembly named "MyMod_Burst.dll" onto the Burst Runtime
            BurstsOfRainMain.AddBurstAssembly(Info, "MyMod_Burst.dll");
        }
    }

Below are the main entries for each of the unity packages this thunderstore package redistributes, alongside a brief description:

| Package | Description |
|--|--|
| [Burst](https://docs.unity3d.com/2021.3/Documentation/Manual/com.unity.burst.html) | Burst is a compiler that translates from IL/.NET bytecode to highly optimized native code using LLVM. |
| [Collections](https://docs.unity3d.com/2021.3/Documentation/Manual/com.unity.collections.html) | A C# collections library providing data structures that can be used in jobs, and optimized by Burst compiler. |
| [Mathematics](https://docs.unity3d.com/2021.3/Documentation/Manual/com.unity.mathematics.html) | Unity’s C# SIMD math library providing vector types and math functions with a shader like syntax. Methods within are ***Job Safe*** |

While not redistributed by the mod since its part of the Core module, an understanding of the [Jobs System](https://docs.unity3d.com/2021.3/Documentation/Manual/JobSystem.html) is also required.

Full Readme --> [Here](https://github.com/risk-of-thunder/BurstsOfRain/blob/main/BurstsOfRain/TS/README.md)