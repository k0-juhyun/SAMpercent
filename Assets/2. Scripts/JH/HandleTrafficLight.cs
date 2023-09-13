using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandleTrafficLight : MonoBehaviour
{
    public class TrafficLight
    {
        private bool greenLight;
        private bool leftTurnLight;
        private bool yellowLight;
        private bool redLight;
        private float timer = 0f;
        private float greenLightInterval = 15f; // 초록불 시간 (15초)
        private float yellowLightInterval = 2f; // 노랑불 시간 (2초)
        private float redLightInterval = 15f; // 빨간불 시간 (15초)
        private string objectName;

        public TrafficLight(string name)
        {
            objectName = name;
            // 초기에 초록불로 시작
            greenLight = true;
            leftTurnLight = true;
            yellowLight = false;
            redLight = false;
        }

        public void UpdateSignal()
        {
            timer += Time.deltaTime;

            if (greenLight && timer >= greenLightInterval)
            {
                // 초록불 시간이 끝나면 노랑불로 변경
                greenLight = false;
                yellowLight = true;
                leftTurnLight = false;
                redLight = false;
                timer = 0f;
            }
            else if (yellowLight && timer >= yellowLightInterval)
            {
                // 노랑불 시간이 끝나면 빨간불로 변경
                greenLight = false;
                yellowLight = false;
                leftTurnLight = false;
                redLight = true;
                timer = 0f;
            }
            else if (redLight && timer >= redLightInterval)
            {
                // 빨간불 시간이 끝나면 초록불로 변경
                greenLight = true;
                yellowLight = false;
                leftTurnLight = true;
                redLight = false;
                timer = 0f;
            }
        }

        public bool IsGreenLight()
        {
            return greenLight;
        }

        public bool IsLeftTurnLight()
        {
            return leftTurnLight;
        }

        public bool IsYellowLight()
        {
            return yellowLight;
        }

        public bool IsRedLight()
        {
            return redLight;
        }
    }

    private TrafficLight[] trafficLights; // 4개의 신호등을 저장하는 배열

    private void Start()
    {
        // 4개의 신호등을 생성하고 배열에 저장
        trafficLights = new TrafficLight[4];
        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i] = new TrafficLight(gameObject.name + " " + i);
        }
    }

    private void Update()
    {
        // 각 신호등을 업데이트
        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i].UpdateSignal();

            // 현재 신호 확인
            if (trafficLights[i].IsGreenLight())
            {
                Debug.Log(gameObject.name + "신호등 " + i + ": 초록불");
            }
            else if (trafficLights[i].IsYellowLight())
            {
                Debug.Log(gameObject.name + "신호등 " + i + ": 노랑불");
            }
            else if (trafficLights[i].IsRedLight())
            {
                Debug.Log(gameObject.name + "신호등 " + i + ": 빨간불");
            }

            if (trafficLights[i].IsLeftTurnLight())
            {
                Debug.Log(gameObject.name + "신호등 " + i + ": 좌회전 신호 활성화");
            }
        }
    }
}
