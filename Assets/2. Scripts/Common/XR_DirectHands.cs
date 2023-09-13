using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XR_DirectHands : XRDirectInteractor
{
    public Enumeration.HandType handType;

    [System.Obsolete]
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        if (handType == Enumeration.HandType.Left)
        {
            PlayerInfo.instance.playerHandsObj.leftHand_Obj = args.interactable.gameObject;
        }
        else if(handType == Enumeration.HandType.Right)
        {
            PlayerInfo.instance.playerHandsObj.rightHand_Obj = args.interactable.gameObject;
        }
    }
    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        if (handType == Enumeration.HandType.Left)
        {
            PlayerInfo.instance.playerHandsObj.leftHand_Obj = null;
        }
        else if (handType == Enumeration.HandType.Right)
        {
            PlayerInfo.instance.playerHandsObj.rightHand_Obj = null;
        }

    }
}
