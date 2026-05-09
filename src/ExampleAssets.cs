using MiraAPI.Utilities.Assets;

namespace Nebuline;

public static class ExampleAssets
{
    public static LoadableResourceAsset ExampleButton { get; } = new("Nebuline.Resources.ExampleButton.png");
    public static LoadableResourceAsset CallMeetingButton { get; } = new("Nebuline.Resources.CallMeeting.png");

    // Credit to EpicHorrors for the teleport button asset.
    public static LoadableResourceAsset TeleportButton { get; } = new("Nebuline.Resources.TeleportButton.png");
    public static LoadableResourceAsset Banner { get; } = new("Nebuline.Resources.FortniteBanner.jpeg");
}
