using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    // ���� ��Ʈ�ѷ��� ��� �ִ� ������Ʈ ����
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
        // ���� ����
        //SAMPRO_EventManager.instance
    }

    private void RemoveEvent()
    {
        // ���� ����
        //SAMPRO_EventManager.instance
    }
}

[System.Serializable]
public class PlayerHandsData
{
    // �޼��� ��� �ִ� ������Ʈ
    public GameObject leftHand_Obj;

    // �������� ��� �ִ� ������Ʈ
    public GameObject rightHand_Obj;
}