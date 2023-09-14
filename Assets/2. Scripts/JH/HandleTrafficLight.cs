using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    public GameObject[] evenTrafficLight; // 첫 번째 신호등 오브젝트
    public GameObject[] oddTrafficLight; // 두 번째 신호등 오브젝트

    public GameObject[] evenTrafficCollider; // 콜라이더
    public GameObject[] oddTrafficCollider; // 콜라이더

    private TrafficLightState state1 = TrafficLightState.Green;
    private TrafficLightState state2 = TrafficLightState.Red;

    private float greenLightDuration = 15f; // 초록불 지속 시간 (15초)
    private float yellowLightDuration = 2f; // 노랑불 지속 시간 (2초)

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
        #region 신호등 로직
        // 첫 번째 신호등 상태 업데이트
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

        // 두 번째 신호등 상태 업데이트
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

        #region 신호 위반
        // 같은 신호등 (짝수/홀수) 의 신호가 빨간 불일때 
        // 트리거 충돌 했다면 실격
        // 짝수 신호등이 빨간 불일때

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
                // 신호 위반을 했다면
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
                // 신호 위반을 했다면
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
                // 다른 자식 오브젝트는 회색으로 변경
                renderers[i].material.color = Color.gray;
            }
        }
    }
}
