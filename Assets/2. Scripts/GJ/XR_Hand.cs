using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XR_Hand : MonoBehaviour
{
    #region Public Variables

    public InputDeviceCharacteristics controllerType;
    public GameObject handModelPrefab;
    public bool showCont = false;

    #endregion Public Variables

    #region Private Variables

    private InputDevice cont;
    private Animator handAni;
    private bool _isControllerFound;
    private GameObject spawnedHandModel;

    #endregion Private Variables

    private void Init()
    {
        List<InputDevice> xrDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerType, xrDevices);

        if (xrDevices.Count.Equals(0))
        {
            //Debug.Log("디바이스 감지가 안되었습니다.");
        }
        else
        {
            if (xrDevices.Count > 0)
            {
                cont = xrDevices[0];
                spawnedHandModel = Instantiate(handModelPrefab, transform);
                handAni = spawnedHandModel.GetComponent<Animator>();
                _isControllerFound = true;
            }
        }
    }

    private void Update()
    {
        if (!_isControllerFound)
        {
            Init();
        }
        else
        {
            UpdateHandAni();
        }
    }

    private void UpdateHandAni()
    {
        if (cont.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAni.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAni.SetFloat("Trigger", 1);
        }

        if (cont.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAni.SetFloat("Grip", gripValue);
        }
        else
        {
            handAni.SetFloat("Grip", 1);
        }
    }
}