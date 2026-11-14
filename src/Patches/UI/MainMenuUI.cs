using HarmonyLib;
using Reactor.Utilities;
using Reactor.Utilities.Extensions;
using UnityEngine;

namespace Nebuline.Patches.UI;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
public class MainMenuUI
{

    public static void Postfix(MainMenuManager __instance)
    {
        Logger<NebulinePlugin>.Info("Initializing custom main menu");
        var mainTransform = __instance.mainMenuUI.transform.Find("AspectScaler");

        mainTransform.Find("BackgroundTexture").GetComponent<SpriteRenderer>().color = new Color(1f, 0.677f, 1f);
        mainTransform.Find("RightPanel").GetComponent<SpriteRenderer>().Destroy();
        mainTransform.Find("RightPanel/ScreenMask").gameObject.active = false;
        mainTransform.Find("RightPanel/MaskedBlackScreen").GetComponent<SpriteRenderer>().Destroy();
    }
}