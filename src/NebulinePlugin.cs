using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using MiraAPI.Translation;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace Nebuline;

[BepInAutoPlugin("lol.eps.nebuline", "Nebuline")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class NebulinePlugin : BasePlugin, IMiraPlugin
{
    public Harmony Harmony { get; } = new(Id);
    public const bool IsDebug = true;
    public string OptionsTitleText => "Nebuline";
    public ConfigFile GetConfigFile() => Config;
    
    public NebulinePlugin()
    {
        MiraLocaleManager.Register(Id); // todo: localize
    }
    public override void Load()
    {
        ExampleEventHandlers.Initialize();
        Harmony.PatchAll();
        ReactorCredits.Register(Name, Version, IsDebug, ReactorCredits.AlwaysShow);
        Logger<NebulinePlugin>.Info("Welcome to Nebuline!");
    }
}
