using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    // 원래 자기 색깔 저장
    private Dictionary<GameObject, Color> initialColors = new Dictionary<GameObject, Color>();

    public GameObject[] evenTrafficLight; // 첫 번째 신호등 오브젝트
    public GameObject[] oddTrafficLight; // 두 번째 신호등 오브젝트

    public GameObject[] evenTrafficCollider; // 콜라이더
    public GameObject[] oddTrafficCollider; // 콜라이더

    private TrafficLightState state1 = TrafficLightState.Green;
    private TrafficLightState state2 = TrafficLightState.Red;

    private float greenLightDuration = 13f; // 초록불 지속 시간 (15초)
    private float yellowLightDuration = 2f; // 노랑불 지속 시간 (2초)
    private float redLightDuration = 15f; // 노랑불 지속 시간 (2초)

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
        #region 신호등 로직
        // 첫 번째 신호등 상태 업데이트
        timer1 += Time.deltaTime;
        switch (state1)
        {
            case TrafficLightState.Green:
                if (timer1 >= greenLightDuration)
                {
                    print("초록불");
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

        // 두 번째 신호등 상태 업데이트
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
                renderers[i].material = material; // Material을 새 Material로 교체
            }
            else
            {
                renderers[i].material = Colors[3];
            }
        }
    }
}
