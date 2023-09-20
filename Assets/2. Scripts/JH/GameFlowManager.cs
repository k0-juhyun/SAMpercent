using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ������� �õ��� �Ѱ�
// �Ʒ� 4���� ���� 2�� ����
// ������, �����, ����� �״� ����
// ���� ���õ� �״� ����
// ������ �״� ����
// ��� D -> N -> P ����
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

    // ���� ���·� �Ѿ�� �Լ�
    private void StartNextFlow()
    {
        // ���� ���·� �̵�
        licenseFlow++;
    }

    // �÷ο� ���� �ڷ�ƾ
    IEnumerator HandleFlow()
    {
        // ���� ������ ���� Ȯ��
        while (!car.isEnd)
        {
            yield return updateCoroutine;
            switch (licenseFlow)
            {
                case LicenseFlow.GuideMent:
                    print("���̵� �÷ο�");
                    yield return StartCoroutine(SoundManager.Instance.PlaySFX(0));
                    licenseFlow++;
                    break;
                case LicenseFlow.SeatBelt:
                    print("������Ʈ �÷ο�");
                    yield return StartCoroutine(CheckSeatBelt());
                    break;
                //case LicenseFlow.StartCar:
                //    print("�õ� �ɱ�");
                //    yield return StartCoroutine(CheckStartCar());
                //    break;
                //case LicenseFlow.HeadLight:
                //    print("������ ���� ����");
                //    yield return StartCoroutine(CheckHeadLight());
                //    break;
                //case LicenseFlow.HightBeam:
                //    print("����� ���� ����");
                //    yield return StartCoroutine(CheckHightBeam());
                //    break;
                //case LicenseFlow.LowBeam:
                //    print("����� ���� ����");
                //    yield return StartCoroutine(CheckLowBeam());
                //    break;
                //case LicenseFlow.WiperOn:
                //    print("������ ���� ����");
                //    yield return StartCoroutine(CheckWiperOn());
                //  break;
                //case LicenseFlow.WiperOff:
                //    print("������ ���� ����");
                //    yield return StartCoroutine(CheckWiperOff());
                //    break;
                case LicenseFlow.StartDrive:
                    print("���� �غ�");
                    yield return StartCoroutine(CheckStartUp());
                    break;
                case LicenseFlow.Drive:
                    print("���� ����");
                    yield return StartCoroutine(CheckDrive());
                    break;
            }
        }
    }

    // ���� ��Ʈ Ȯ�� �Լ�
    private IEnumerator CheckSeatBelt()
    {
        if (car.isSeatBelt)
        {
            print("������Ʈ �Ϸ�");
            yield return StartCoroutine(SoundManager.Instance.PlaySFX(1));
            yield return StartCoroutine(SoundManager.Instance.PlaySFX(2));
            StartNextFlow();
        }
    }

    #region ������ �÷ο��..
    //// �õ� �ɱ� �Լ�
    //private IEnumerator CheckStartCar()
    //{
    //    float startTime = Time.time;

    //    while (!car.isStartUp)
    //    {
    //        yield return null;

    //        if (Time.time - startTime > 5f)
    //        {
    //            print("����");
    //            ScoreManager.instance.Deduction(10);
    //            break;
    //        }
    //    }

    //    if (car.isStartUp)
    //    {
    //        print("�õ��ɱ� �Ϸ�");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(3));
    //        StartNextFlow();
    //    }
    //}

    //// ������ ���� �ɷ�
    //private IEnumerator CheckHeadLight()
    //{
    //    if (car.isHeadLight)
    //    {
    //        print("������ �ѱ� �Ϸ�");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(4));
    //        StartNextFlow();
    //    }
    //}

    //// ����� ���� �ɷ�
    //private IEnumerator CheckHightBeam()
    //{
    //    if (car.isHightBeam)
    //    {
    //        print("����� �ѱ� �Ϸ�");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(5));
    //        StartNextFlow();
    //    }
    //}

    //// ����� ���� �ɷ�
    //private IEnumerator CheckLowBeam()
    //{
    //    // ����� ���� ������ Ű��
    //    if (car.isLowBeam && car.isHeadLight == false)
    //    {
    //        print("����� ��, ������ ���� �Ϸ�");
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(1));
    //        yield return StartCoroutine
    //            (SoundManager.Instance.PlaySFX(6));
    //        StartNextFlow();
    //    }
    //}

    //// ������ ���� �ɷ�
    //private IEnumerator CheckWiperOn()
    //{
    //    if (car.isWiper)
    //    {
    //        print("������ �ѱ� �Ϸ�");
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
    //        print("������ ���� �Ϸ�");
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
            print("�õ��ɱ� �Ϸ�");
            yield return StartCoroutine
                (SoundManager.Instance.PlaySFX(1));
            yield return StartCoroutine
                (SoundManager.Instance.PlaySFX(8));
            StartNextFlow();
        }
    }

    private IEnumerator CheckDrive()
    {
        // �극��ũ ���
        // ���̵� �극��ũ ����
        // ��� D
        // ���� ������ Ű��
        if (car.isSideBreak == false && car.isBreak
            && car.isleftTurnSignalLight)
        {
            print("���� �غ� �Ϸ�");
            yield return StartCoroutine
                (SoundManager.Instance.PlaySFX(1));
            StartNextFlow();
        }
    }
}
