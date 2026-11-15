using Nebuline.GameOver;
using Nebuline.Roles;
using MiraAPI.GameEnd;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace Nebuline.Buttons;

public class NeutralKillerButton : CustomActionButton
{
    public override string Name => "Win Game";
    public override float Cooldown => 0f;
    public override LoadableAsset<Sprite> Sprite => NebulineAssets.ExampleButton;
    public override MiraKeybind Keybind => ExampleKeybinds.NeutralWinKeybind;

    protected override void OnClick()
    {
        CustomGameOver.Trigger<NeutralKillerGameOver>([PlayerControl.LocalPlayer.Data]);
    }

    public override bool Enabled(RoleBehaviour? role)
    {
        return role is NeutralKillerRole;
    }
}
