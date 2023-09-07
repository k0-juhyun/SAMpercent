using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 순서대로 시동을 켜고
// 아래 4개중 랜덤 2개 시행
// 전조등, 상향등, 하향등 켰다 끄기
// 방향 지시등 켰다 끄기
// 와이퍼 켰다 끄기
// 기어 D -> N -> P 순서
public class StartLicense : MonoBehaviour
{
    private bool isStartUp;
    private bool isLeftTurnLight;
    private bool isRightTurnLight;

    private enum RandomTest
    {

    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
