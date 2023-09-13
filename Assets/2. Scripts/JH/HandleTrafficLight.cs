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
        private float greenLightInterval = 15f; // �ʷϺ� �ð� (15��)
        private float yellowLightInterval = 2f; // ����� �ð� (2��)
        private float redLightInterval = 15f; // ������ �ð� (15��)
        private string objectName;

        public TrafficLight(string name)
        {
            objectName = name;
            // �ʱ⿡ �ʷϺҷ� ����
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
                // �ʷϺ� �ð��� ������ ����ҷ� ����
                greenLight = false;
                yellowLight = true;
                leftTurnLight = false;
                redLight = false;
                timer = 0f;
            }
            else if (yellowLight && timer >= yellowLightInterval)
            {
                // ����� �ð��� ������ �����ҷ� ����
                greenLight = false;
                yellowLight = false;
                leftTurnLight = false;
                redLight = true;
                timer = 0f;
            }
            else if (redLight && timer >= redLightInterval)
            {
                // ������ �ð��� ������ �ʷϺҷ� ����
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

    private TrafficLight[] trafficLights; // 4���� ��ȣ���� �����ϴ� �迭

    private void Start()
    {
        // 4���� ��ȣ���� �����ϰ� �迭�� ����
        trafficLights = new TrafficLight[4];
        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i] = new TrafficLight(gameObject.name + " " + i);
        }
    }

    private void Update()
    {
        // �� ��ȣ���� ������Ʈ
        for (int i = 0; i < trafficLights.Length; i++)
        {
            trafficLights[i].UpdateSignal();

            // ���� ��ȣ Ȯ��
            if (trafficLights[i].IsGreenLight())
            {
                Debug.Log(gameObject.name + "��ȣ�� " + i + ": �ʷϺ�");
            }
            else if (trafficLights[i].IsYellowLight())
            {
                Debug.Log(gameObject.name + "��ȣ�� " + i + ": �����");
            }
            else if (trafficLights[i].IsRedLight())
            {
                Debug.Log(gameObject.name + "��ȣ�� " + i + ": ������");
            }

            if (trafficLights[i].IsLeftTurnLight())
            {
                Debug.Log(gameObject.name + "��ȣ�� " + i + ": ��ȸ�� ��ȣ Ȱ��ȭ");
            }
        }
    }
}
