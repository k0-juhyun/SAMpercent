using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    // 현재 컨트롤러가 잡고 있는 오브젝트 저장
    public PlayerHandsData playerHandsObj;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
        AddEvent();
    }

    private void OnDestory()
    {
        RemoveEvent();
    }

    private void AddEvent()
    {
        // 구현 예정
        //SAMPRO_EventManager.instance
    }

    private void RemoveEvent()
    {
        // 구현 예정
        //SAMPRO_EventManager.instance
    }
}

[System.Serializable]
public class PlayerHandsData
{
    // 왼손이 잡고 있는 오브젝트
    public GameObject leftHand_Obj;

    // 오른손이 잡고 있는 오브젝트
    public GameObject rightHand_Obj;
}