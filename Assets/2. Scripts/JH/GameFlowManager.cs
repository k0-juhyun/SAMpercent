using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 순서대로 시동을 켜고
// 아래 4개중 랜덤 2개 시행
// 전조등, 상향등, 하향등 켰다 끄기
// 방향 지시등 켰다 끄기
// 와이퍼 켰다 끄기
// 기어 D -> N -> P 순서
public class GameFlowManager : MonoBehaviour
{
    private JHCarTest car;
    private WheelController wheelController;

    private WaitForSeconds updateCoroutine;

    public enum LicenseFlow
    {
        GuideMent,
        SeatBelt,
        //StartCar,
        //HeadLight,
        //HightBeam,
        //LowBeam,
        //WiperOn,
        //WiperOff,
        StartDrive,
        Drive,
        End
    }

    public LicenseFlow licenseFlow = LicenseFlow.GuideMent;

    private void Awake()
    {
        car = FindObjectOfType<JHCarTest>();
        wheelController = FindObjectOfType<WheelController>();

        updateCoroutine = new WaitForSeconds(1);

        StartCoroutine(HandleFlow());
    }

    // 다음 상태로 넘어가는 함수
    private void StartNextFlow()
    {
        // 다음 상태로 이동
        licenseFlow++;
    }

    // 플로우 진행 코루틴
    IEnumerator HandleFlow()
    {
        // 시험 끝날때 까지 확인
        while (!car.isEnd)
        {
            yield return updateCoroutine;
            switch (licenseFlow)
            {
                case LicenseFlow.GuideMent:
                    print("가이드 플로우");
                    yield return StartCoroutine(SoundManager.Instance.PlaySFX(0));
                    licenseFlow++;
                    break;
                case LicenseFlow.SeatBelt:
                    print("안전벨트 플로우");
                    yield return StartCoroutine(CheckSeatBelt());
                    break;
                //case LicenseFlow.StartCar:
                //    print("시동 걸기");
                //    yield return StartCoroutine(CheckStartCar());
                //    break;
                //case LicenseFlow.HeadLight:
                //    print("전조등 조작 시험");
                //    yield return StartCoroutine(CheckHeadLight());
                //    break;
                //case LicenseFlow.HightBeam:
                //    print("상향등 조작 시험");
                //    yield return StartCoroutine(CheckHightBeam());
                //    break;
                //case LicenseFlow.LowBeam:
                //    print("하향등 조작 시험");
                //    yield return StartCoroutine(CheckLowBeam());
                //    break;
                //case LicenseFlow.WiperOn:
                //    print("와이퍼 조작 시험");
                //    yield return StartCoroutine(CheckWiperOn());
                //  break;
                //case LicenseFlow.WiperOff:
                //    print("와이퍼 조작 시험");
                //    yield return StartCoroutine(CheckWiperOff());
                //    break;
                case LicenseFlow.StartDrive:
                    print("주행 준비");
                    yield return StartCoroutine(CheckStartUp());
                    break;
                case LicenseFlow.Drive:
                    print("주행 시작");
                    yield return StartCoroutine(CheckDrive());
                    break;
            }
        }
    }

    // 안전 벨트 확인 함수
    private IEnumerator CheckSeatBelt()
    {
        if (car.isSeatBelt)
        {
            print("안전벨트 완료");
            yield return StartCoroutine(SoundManager.Instance.PlaySFX(1));
            yield return StartCoroutine(SoundManager.Instance.PlaySFX(2));
            StartNextFlow();
        }
    }

    #region 지워진 플로우들..
    //// 시동 걸기 함수
    //private IEnumerator CheckStartCar()
    //{
    //    float startTime = Time.time;

    //    while (!car.isStartUp)
    //    {
    //        yield return null;

    //        if (Time.time - startTime > 5f)
    //        {
    //            print("감점");
    //            ScoreManager.instance.Deduction(10);
    //            break;
    //        }
    //    }

    //    if (car.isStartUp)
    //    {
    //        print("시동걸기 완료");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(3));
    //        StartNextFlow();
    //    }
    //}

    //// 전조등 조작 능력
    //private IEnumerator CheckHeadLight()
    //{
    //    if (car.isHeadLight)
    //    {
    //        print("전조등 켜기 완료");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(4));
    //        StartNextFlow();
    //    }
    //}

    //// 상향등 조작 능력
    //private IEnumerator CheckHightBeam()
    //{
    //    if (car.isHightBeam)
    //    {
    //        print("상향등 켜기 완료");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(5));
    //        StartNextFlow();
    //    }
    //}

    //// 하향등 조작 능력
    //private IEnumerator CheckLowBeam()
    //{
    //    // 하향등 끄고 전조등 키고
    //    if (car.isLowBeam && car.isHeadLight == false)
    //    {
    //        print("하향등 켜, 전조등 끄기 완료");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(6));
    //        StartNextFlow();
    //    }
    //}

    //// 와이퍼 조작 능력
    //private IEnumerator CheckWiperOn()
    //{
    //    if (car.isWiper)
    //    {
    //        print("와이퍼 켜기 완료");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(7));
    //        StartNextFlow();
    //    }
    //}

    //private IEnumerator CheckWiperOff()
    //{
    //    if (car.isWiper == false)
    //    {
    //        print("와이퍼 끄기 완료");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(8));
    //        StartNextFlow();
    //    }
    //}
#endregion

    private IEnumerator CheckStartUp()
    {
        if (car.isStartUp)
        {
            print("시동걸기 완료");
            yield return StartCoroutine
                (SoundManager.Instance.PlaySFX(1));
            yield return StartCoroutine
                (SoundManager.Instance.PlaySFX(8));
            StartNextFlow();
        }
    }

    private IEnumerator CheckDrive()
    {
        // 브레이크 밟고
        // 사이드 브레이크 해제
        // 기어 D
        // 좌측 깜빡이 키고
        if (car.isSideBreak == false && car.isBreak
            && car.isleftTurnSignalLight)
        {
            print("주행 준비 완료");
            yield return StartCoroutine
                (SoundManager.Instance.PlaySFX(1));
            StartNextFlow();
        }
    }
}
