using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace Nebuline;

public static class NebulineAssets
{
    public static LoadableResourceAsset ExampleButton { get; } = new("Nebuline.Resources.ExampleButton.png");
    public static LoadableResourceAsset CallMeetingButton { get; } = new("Nebuline.Resources.CallMeeting.png");

    // Credit to EpicHorrors for the teleport button asset.
    public static LoadableResourceAsset TeleportButton { get; } = new("Nebuline.Resources.TeleportButton.png");
    public static LoadableResourceAsset Banner { get; } = new("Nebuline.Resources.FortniteBanner.jpeg");
    
    // asset replacements for custom main menu 
    public static LoadableAsset<Sprite> LogoSprite = new LoadableResourceAsset("Nebuline.Resources.logo.png");
    public static LoadableAsset<Sprite> HighlightButton = new LoadableResourceAsset("Nebuline.Resources.HighlightButton.png");
    public static LoadableAsset<Sprite> InactiveButton = new LoadableResourceAsset("Nebuline.Resources.InactiveButton.png");
}
