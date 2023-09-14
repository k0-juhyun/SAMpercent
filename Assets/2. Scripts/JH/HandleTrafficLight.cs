using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    public GameObject[] trafficLight1; // ù ��° ��ȣ�� ������Ʈ
    public GameObject[] trafficLight2; // �� ��° ��ȣ�� ������Ʈ

    private TrafficLightState state1 = TrafficLightState.Green;
    private TrafficLightState state2 = TrafficLightState.Red;

    private float greenLightDuration = 15f; // �ʷϺ� ���� �ð� (15��)
    private float yellowLightDuration = 2f; // ����� ���� �ð� (2��)

    private float timer1 = 0f;
    private float timer2 = 0f;

    private enum TrafficLightState
    {
        Green,
        Yellow,
        Red
    }

    private void Update()
    {
        // ù ��° ��ȣ�� ���� ������Ʈ
        timer1 += Time.deltaTime;
        switch (state1)
        {
            case TrafficLightState.Green:
                if (timer1 >= greenLightDuration)
                {
                    state1 = TrafficLightState.Yellow;
                    timer1 = 0f;
                    SetTrafficLightColor(trafficLight1[0], Color.yellow);
                    SetTrafficLightColor(trafficLight1[1], Color.yellow);
                }
                break;
            case TrafficLightState.Yellow:
                if (timer1 >= yellowLightDuration)
                {
                    state1 = TrafficLightState.Red;
                    timer1 = 0f;
                    SetTrafficLightColor(trafficLight1[0], Color.red);
                    SetTrafficLightColor(trafficLight1[1], Color.red);
                }
                break;
            case TrafficLightState.Red:
                if (timer1 >= greenLightDuration)
                {
                    state1 = TrafficLightState.Green;
                    timer1 = 0f;
                    SetTrafficLightColor(trafficLight1[0], Color.green);
                    SetTrafficLightColor(trafficLight1[1], Color.green);
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
                    SetTrafficLightColor(trafficLight2[0], Color.yellow);
                    SetTrafficLightColor(trafficLight2[1], Color.yellow);
                }
                break;
            case TrafficLightState.Yellow:
                if (timer2 >= yellowLightDuration)
                {
                    state2 = TrafficLightState.Red;
                    timer2 = 0f;
                    SetTrafficLightColor(trafficLight2[0], Color.red);
                    SetTrafficLightColor(trafficLight2[1], Color.red);
                }
                break;
            case TrafficLightState.Red:
                if (timer2 >= greenLightDuration)
                {
                    state2 = TrafficLightState.Green;
                    timer2 = 0f;
                    SetTrafficLightColor(trafficLight2[0], Color.green);
                    SetTrafficLightColor(trafficLight2[1], Color.green);
                }
                break;
        }
    }

    private void SetTrafficLightColor(GameObject trafficLight, Color color)
    {
        Renderer renderer = trafficLight.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
