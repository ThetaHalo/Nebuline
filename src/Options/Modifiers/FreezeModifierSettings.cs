using Nebuline.Modifiers.Freezer;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;

namespace Nebuline.Options.Modifiers;

public class FreezeModifierSettings : AbstractOptionGroup<FreezeModifier>
{
    public override string GroupName => "Freeze";

    [ModdedToggleOption("Use Color")]
    public bool UseColor { get; set; } = true;
}
