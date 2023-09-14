using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    public GameObject[] evenTrafficLight; // ù ��° ��ȣ�� ������Ʈ
    public GameObject[] oddTrafficLight; // �� ��° ��ȣ�� ������Ʈ

    public GameObject[] evenTrafficCollider; // �ݶ��̴�
    public GameObject[] oddTrafficCollider; // �ݶ��̴�

    private TrafficLightState state1 = TrafficLightState.Green;
    private TrafficLightState state2 = TrafficLightState.Red;

    private float greenLightDuration = 15f; // �ʷϺ� ���� �ð� (15��)
    private float yellowLightDuration = 2f; // ����� ���� �ð� (2��)

    private float timer1 = 0f;
    private float timer2 = 0f;

    public bool[] even;
    public bool[] odd;

    private void Awake()
    {
        even = new bool[evenTrafficLight.Length];
        odd = new bool[oddTrafficLight.Length];
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
                    state1 = TrafficLightState.Yellow;
                    timer1 = 0f;

                    SetTrafficLightColor(evenTrafficLight[0], Color.yellow, 5);
                    SetTrafficLightColor(evenTrafficLight[1], Color.yellow, 5);

                    SetTrafficLightColor(oddTrafficLight[0], Color.yellow, 5);
                    SetTrafficLightColor(oddTrafficLight[1], Color.yellow, 5);
                }
                break;
            case TrafficLightState.Yellow:
                if (timer1 >= yellowLightDuration)
                {
                    state1 = TrafficLightState.Red;
                    timer1 = 0f;

                    SetTrafficLightColor(evenTrafficLight[0], Color.red, 6);
                    SetTrafficLightColor(evenTrafficLight[1], Color.red, 6);

                    SetTrafficLightColor(oddTrafficLight[0], Color.green, 3);
                    SetTrafficLightColor(oddTrafficLight[1], Color.green, 3);
                }
                break;
            case TrafficLightState.Red:
                if (timer1 >= greenLightDuration)
                {
                    state1 = TrafficLightState.Green;
                    timer1 = 0f;

                    SetTrafficLightColor(evenTrafficLight[0], Color.green, 3);
                    SetTrafficLightColor(evenTrafficLight[1], Color.green, 3);

                    SetTrafficLightColor(oddTrafficLight[0], Color.red, 6);
                    SetTrafficLightColor(oddTrafficLight[1], Color.red, 6);
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

                    SetTrafficLightColor(oddTrafficLight[0], Color.yellow, 5);
                    SetTrafficLightColor(oddTrafficLight[1], Color.yellow, 5);
                                                                            
                    SetTrafficLightColor(evenTrafficLight[0], Color.yellow, 5);
                    SetTrafficLightColor(evenTrafficLight[1], Color.yellow, 5);
                }
                break;
            case TrafficLightState.Yellow:
                if (timer2 >= yellowLightDuration)
                {
                    state2 = TrafficLightState.Red;
                    timer2 = 0f;

                    SetTrafficLightColor(oddTrafficLight[0], Color.red, 6);
                    SetTrafficLightColor(oddTrafficLight[1], Color.red, 6);

                    SetTrafficLightColor(evenTrafficLight[0], Color.green, 3);
                    SetTrafficLightColor(evenTrafficLight[1], Color.green, 3);
                }
                break;
            case TrafficLightState.Red:
                if (timer2 >= greenLightDuration)
                {
                    state2 = TrafficLightState.Green;
                    timer2 = 0f;

                    SetTrafficLightColor(oddTrafficLight[0], Color.green, 3);
                    SetTrafficLightColor(oddTrafficLight[1], Color.green, 3);

                    SetTrafficLightColor(evenTrafficLight[0], Color.red, 6);
                    SetTrafficLightColor(evenTrafficLight[1], Color.red, 6);
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

    private void SetTrafficLightColor(GameObject trafficLight, Color color, int childIndexToChange)
    {
        Renderer[] renderers = trafficLight.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            if (i == childIndexToChange)
            {
                renderers[i].material.color = color;
            }
            else
            {
                // �ٸ� �ڽ� ������Ʈ�� ȸ������ ����
                renderers[i].material.color = Color.gray;
            }
        }
    }
}
