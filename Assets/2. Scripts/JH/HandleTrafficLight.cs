using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    public GameObject[] trafficLight1; // 첫 번째 신호등 오브젝트
    public GameObject[] trafficLight2; // 두 번째 신호등 오브젝트

    private TrafficLightState state1 = TrafficLightState.Green;
    private TrafficLightState state2 = TrafficLightState.Red;

    private float greenLightDuration = 15f; // 초록불 지속 시간 (15초)
    private float yellowLightDuration = 2f; // 노랑불 지속 시간 (2초)

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
        // 첫 번째 신호등 상태 업데이트
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

        // 두 번째 신호등 상태 업데이트
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
