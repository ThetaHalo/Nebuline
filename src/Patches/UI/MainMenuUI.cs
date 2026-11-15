using System;
using HarmonyLib;
using MiraAPI.Utilities;
using Reactor.Utilities;
using UnityEngine;

namespace Nebuline.Patches.UI;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
public class MainMenuUI
{
    // button active: bc9bea (highlight: e0c9ff)
    // button inactive: 8b72ae (highlight: 9e83c4)
    public static void Postfix(MainMenuManager __instance)
    {
        try
        {
            Logger<NebulinePlugin>.Info("Initializing custom main menu");
            var mainTransform = __instance.mainMenuUI.transform.Find("AspectScaler");
            KillFriendBar();

            mainTransform.Find("BackgroundTexture").GetComponent<SpriteRenderer>().color = new Color(1f, 0.677f, 1f);
            
            mainTransform.Find("RightPanel").GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 1f);
            mainTransform.Find("RightPanel/ScreenMask").gameObject.SetActive(false);
            
            mainTransform.Find("LeftPanel").GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 1f);
            mainTransform.Find("LeftPanel/Sizer/LOGO-AU").GetComponent<SpriteRenderer>().sprite = NebulineAssets.LogoSprite.LoadAsset();
            
            // setup custom active/inactive buttons
            var leftButtons = mainTransform.Find("LeftPanel/Main Buttons").GetAllChildren();
            foreach (GameObject btn in leftButtons)
            {
                Logger<NebulinePlugin>.Info($"Setting up button: {btn.name}");
                if (btn.name is "PlayButton" or "Inventory Button" or "ShopButton") // primary
                {   
                    btn.transform.Find("Highlight").GetComponent<SpriteRenderer>().sprite = NebulineAssets.HighlightButton.LoadAsset();
                    btn.transform.Find("Highlight/Shine").gameObject.SetActive(false);
                    var hlIcon = btn.transform.Find("Highlight/Icon").gameObject;
                    hlIcon.GetComponent<AspectPosition>().enabled = false;
                    var hlIconPos = hlIcon.transform.localPosition;
                    hlIcon.transform.localPosition = new Vector3(hlIconPos.x, 0, hlIconPos.z);
                    
                    btn.transform.Find("Inactive").GetComponent<SpriteRenderer>().sprite = NebulineAssets.InactiveButton.LoadAsset();
                    btn.transform.Find("Inactive/Shine").gameObject.SetActive(false);
                    var iaIcon = btn.transform.Find("Inactive/Icon").gameObject;
                    iaIcon.GetComponent<AspectPosition>().enabled = false;
                    var iaIconPos = iaIcon.transform.localPosition;
                    iaIcon.transform.localPosition = new Vector3(iaIconPos.x, 0, iaIconPos.z);
                } else if (btn.transform.name is not "BottomButtonBounds" and not "Divider")
                {
                    btn.transform.Find("Highlight").GetComponent<SpriteRenderer>().color = new Color(1f, 0.7f, 1f);
                    btn.transform.Find("Inactive").GetComponent<SpriteRenderer>().color = new Color(0.68f, 0.7f, 1f);
                }
            }

            var exit = mainTransform.transform.Find("LeftPanel/Main Buttons/BottomButtonBounds/ExitGameButton");
            exit.transform.Find("Highlight").GetComponent<SpriteRenderer>().color = new Color(1f, 0.65f, 0.7f);
            exit.transform.Find("Inactive").GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.6f);
        }
        catch (Exception e)
        {
            Logger<NebulinePlugin>.Error($"Failed to initialize custom main menu");
            Logger<NebulinePlugin>.Error(e);
        }
    }

    private static void KillFriendBar()
    {
        if (!AccountManager.InstanceExists) return;
        AccountManager.Instance.transform.Find("AccountTab/GameHeader/BarSprite").gameObject.SetActive(false);
    }
}