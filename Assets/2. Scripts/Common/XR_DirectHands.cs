using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XR_DirectHands : XRDirectInteractor
{
    public Enumeration.HandType handType;

    private GameObject hand;
    private Instance_ID instance_ID;

    private void Start()
    {
        hand = transform.GetChild(0).gameObject;
    }

    [System.Obsolete]
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        instance_ID = args.interactable.GetComponent<Instance_ID>();

        if (handType == Enumeration.HandType.Left)
        {
            PlayerInfo.instance.playerHandsObj.leftHand_Obj = args.interactable.gameObject;
            instance_ID.leftHand.SetActive(true);
        }

        if (handType == Enumeration.HandType.Right)
        {
            PlayerInfo.instance.playerHandsObj.rightHand_Obj = args.interactable.gameObject;
            instance_ID.rightHand.SetActive(true);
        }

        hand.SetActive(false);
    }

    [System.Obsolete]
    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        if (handType == Enumeration.HandType.Left)
        {
            PlayerInfo.instance.playerHandsObj.leftHand_Obj = null;
            instance_ID.leftHand.SetActive(false);
        }

        if (handType == Enumeration.HandType.Right)
        {
            PlayerInfo.instance.playerHandsObj.rightHand_Obj = null;
            instance_ID.rightHand.SetActive(false);
        }
        hand.SetActive(true);
        instance_ID = null;
    }
}