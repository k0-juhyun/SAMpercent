using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    // ���� �ڱ� ���� ����
    private Dictionary<GameObject, Color> initialColors = new Dictionary<GameObject, Color>();

    public GameObject[] evenTrafficLight; // ù ��° ��ȣ�� ������Ʈ
    public GameObject[] oddTrafficLight; // �� ��° ��ȣ�� ������Ʈ

    public GameObject[] evenTrafficCollider; // �ݶ��̴�
    public GameObject[] oddTrafficCollider; // �ݶ��̴�

    private TrafficLightState state1 = TrafficLightState.Green;
    private TrafficLightState state2 = TrafficLightState.Red;

    private float greenLightDuration = 13f; // �ʷϺ� ���� �ð� (15��)
    private float yellowLightDuration = 2f; // ����� ���� �ð� (2��)
    private float redLightDuration = 15f; // ����� ���� �ð� (2��)

    public Material[] Colors;

    private float timer1 = 0f;
    private float timer2 = 0f;

    public bool[] even;
    public bool[] odd;

    private void Awake()
    {
        even = new bool[evenTrafficLight.Length];
        odd = new bool[oddTrafficLight.Length];

        foreach (GameObject trafficLight in evenTrafficLight)
        {
            SaveInitialColors(trafficLight);
        }
        foreach (GameObject trafficLight in oddTrafficLight)
        {
            SaveInitialColors(trafficLight);
        }
    }

    private enum TrafficLightState
    {
        Green,
        Yellow,
        Red
    }

    private void Update()
    {
        #region ��ȣ�� ����
        // ù ��° ��ȣ�� ���� ������Ʈ
        timer1 += Time.deltaTime;
        switch (state1)
        {
            case TrafficLightState.Green:
                if (timer1 >= greenLightDuration)
                {
                    print("�ʷϺ�");
                    state1 = TrafficLightState.Yellow;
                    timer1 = 0f;

                    SetTrafficLightMaterial(evenTrafficLight[0], Colors[2], 3);
                    SetTrafficLightMaterial(evenTrafficLight[1], Colors[2], 3);

                    SetTrafficLightMaterial(oddTrafficLight[0], Colors[2], 3);
                    SetTrafficLightMaterial(oddTrafficLight[1], Colors[2], 3);
                }
                break;
            case TrafficLightState.Yellow:
                if (timer1 >= yellowLightDuration)
                {
                    state1 = TrafficLightState.Red;
                    timer1 = 0f;

                    SetTrafficLightMaterial(evenTrafficLight[0], Colors[0], 2);
                    SetTrafficLightMaterial(evenTrafficLight[1], Colors[0], 2);

                    SetTrafficLightMaterial(oddTrafficLight[0], Colors[1], 5);
                    SetTrafficLightMaterial(oddTrafficLight[1], Colors[1], 5);
                }
                break;
            case TrafficLightState.Red:
                if (timer1 >= redLightDuration)
                {
                    state1 = TrafficLightState.Green;
                    timer1 = 0f;

                    SetTrafficLightMaterial(evenTrafficLight[0], Colors[1], 5);
                    SetTrafficLightMaterial(evenTrafficLight[1], Colors[1], 5);

                    SetTrafficLightMaterial(oddTrafficLight[0], Colors[0], 2);
                    SetTrafficLightMaterial(oddTrafficLight[1], Colors[0], 2);
                }
                break;
        }

        // �� ��° ��ȣ�� ���� ������Ʈ
        timer2 += Time.deltaTime;
        switch (state2)
        {
            case TrafficLightState.Green:
                if (timer2 >= greenLightDuration)
                {
                    state2 = TrafficLightState.Yellow;
                    timer2 = 0f;

                    SetTrafficLightMaterial(oddTrafficLight[0], Colors[2], 3);
                    SetTrafficLightMaterial(oddTrafficLight[1], Colors[2], 3);
                                                                            
                    SetTrafficLightMaterial(evenTrafficLight[0], Colors[2], 3);
                    SetTrafficLightMaterial(evenTrafficLight[1], Colors[2], 3);
                }
                break;
            case TrafficLightState.Yellow:
                if (timer2 >= yellowLightDuration)
                {
                    state2 = TrafficLightState.Red;
                    timer2 = 0f;

                    SetTrafficLightMaterial(oddTrafficLight[0], Colors[0], 2);
                    SetTrafficLightMaterial(oddTrafficLight[1], Colors[0], 2);

                    SetTrafficLightMaterial(evenTrafficLight[0], Colors[1], 5);
                    SetTrafficLightMaterial(evenTrafficLight[1], Colors[1], 5);
                }
                break;
            case TrafficLightState.Red:
                if (timer2 >= redLightDuration)
                {
                    state2 = TrafficLightState.Green;
                    timer2 = 0f;

                    SetTrafficLightMaterial(oddTrafficLight[0], Colors[1], 5);
                    SetTrafficLightMaterial(oddTrafficLight[1], Colors[1], 5);

                    SetTrafficLightMaterial(evenTrafficLight[0], Colors[0], 2);
                    SetTrafficLightMaterial(evenTrafficLight[1], Colors[0], 2);
                }
                break;
        }
        #endregion

        #region ��ȣ ����
        // ���� ��ȣ�� (¦��/Ȧ��) �� ��ȣ�� ���� ���϶� 
        // Ʈ���� �浹 �ߴٸ� �ǰ�
        // ¦�� ��ȣ���� ���� ���϶�

        for (int i = 0; i < evenTrafficLight.Length; i++)
        {
            even[i] = evenTrafficCollider[i].GetComponent<HandleTrafficCollider>().signalViolation;
        }

        for (int i = 0; i < oddTrafficCollider.Length; i++)
        {

            odd[i] = oddTrafficCollider[i].GetComponent<HandleTrafficCollider>().signalViolation;
        }

        if (state1 == TrafficLightState.Red)
        {
            for(int i = 0; i< even.Length ; i++) 
            {
                // ��ȣ ������ �ߴٸ�
                if(even[i])
                {
                    print(even[i]);
                    ScoreManager.instance.disqulification = true;
                }
            }
        }

        else if (state2 == TrafficLightState.Red)
        {
            for (int i = 0; i < odd.Length; i++)
            {
                // ��ȣ ������ �ߴٸ�
                if (odd[i])
                {
                    print(odd[i]);
                    ScoreManager.instance.disqulification = true;
                }
            }
        }
        #endregion
    }
    private void SaveInitialColors(GameObject trafficLight)
    {
        Renderer[] renderers = trafficLight.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            initialColors[renderer.gameObject] = renderer.material.color;
        }
    }

    private void SetTrafficLightMaterial(GameObject trafficLight, Material material, int childIndexToChange)
    {
        Renderer[] renderers = trafficLight.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            if (i == childIndexToChange)
            {
                renderers[i].material = material; // Material�� �� Material�� ��ü
            }
            else
            {
                renderers[i].material = Colors[3];
            }
        }
    }
}
