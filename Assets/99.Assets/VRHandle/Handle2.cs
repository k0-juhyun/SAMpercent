using UnityEngine;

public class Handle2 : MonoBehaviour
{
    public Transform hand;
    public Transform insideHandModel;
    public Transform handle;

    private bool isGrabbed;

    // 회전한 누적 값
    public float totalRotateAngle;

    // 돌아갈 때 회전해야하는 방향
    private int directionOfRotation = 0;

    private Vector3 grabbedHand;

    private void Update()
    {
        HandleSelectEntering();
        HandleSelectExiting();
        updateProcess();
    }

    private void HandleSelectEntering()
    {
        //핸들을 잡았을 때
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isGrabbed = true;
            grabbedHand = insideHandModel.localPosition.normalized;
            //원상복구 하는 도중 남은 각도를 원래값으로 되돌리자
            totalRotateAngle *= -directionOfRotation;
        }
    }

    private void HandleSelectExiting()
    {
        //핸들을 잡지 않았을 때
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isGrabbed = false;
            //핸들을 되돌리는 방향을 건들자
            // 0보다 크다는 것은 되돌리는 방향 오른쪽 : -1, 왼쪽 회전: 1
            if (totalRotateAngle > 0) directionOfRotation = -1;
            else directionOfRotation = 1;

            //회전각을 절대 값으로 만든다.
            totalRotateAngle = Mathf.Abs(totalRotateAngle);
        }
    }

    private void updateProcess()
    {
        //잡았을 때
        if (isGrabbed)
        {
            RotateHandle();
        }
        //잡지 않았을 때
        else
        {
            //회전 누적 값이 0이 아니라면
            if (totalRotateAngle != 0)
            {
                //방향 만큼 핸들을 돌린다.
                handle.Rotate(0, 0, 100 * directionOfRotation * Time.deltaTime);
                //회전각도 감소 시킨다.
                totalRotateAngle -= 100 * Time.deltaTime;
                //총 회전각이 0보다 작아지게 되면
                if (totalRotateAngle <= 0)
                {
                    //회전각도를 0으로 만들고, 원래 상태를 유지한다.
                    totalRotateAngle = 0;
                    handle.localEulerAngles = new Vector3(25, 0, 0);
                }
            }
        }

        SetInsideHandPosition();

        // 실제 핸들의 모양의 각도만큼 기울이자
        insideHandModel.RotateAround(transform.position, transform.right, 25);
    }

    //고정 핸들을 나의 손 위치 방향으로 값을 따라온다.
    private void SetInsideHandPosition()
    {
        //수직으로 세우자
        insideHandModel.localEulerAngles = Vector3.zero;

        //고정된 손의 위치를 내가 움직이는 손의 위치로 변경한다.
        insideHandModel.position = hand.position;
        //움직이는 손의 지역 위치를 저장한다.
        Vector3 localPos = insideHandModel.localPosition;

        //지역 위치의 z값을 없애면 핸들과 같은 라인에 위치한다.
        //z 값을 없애서 핸들과 같은 라인에 위치시키고 핸들의 크기만큼 만들어주자
        localPos.z = 0;
        //핸들의 잡는 주위에 위치시킨다.
        localPos = localPos.normalized * 0.5f;
        //고정된 손의 지역 위치 변경 값을 저장한다.
        insideHandModel.localPosition = localPos;
    }

    private void RotateHandle()
    {
        //insideHand.localPosition.normalized - 이동한 손
        //toHand - 내가 잡았을 때 위치
        //왼쪽으로 돌리면 외적한 값이 Vector3.back
        //오른쪽으로 돌리면 외적한 값이 Vector3.forward
        Vector3 crossHandle = Vector3.Cross(grabbedHand, insideHandModel.localPosition.normalized);

        //toHand, insideHand.localPosition.normalized 각도 핸들을 만큼 회전 시키자
        //v.normalize.z 는 angle 을 -냐 +냐 할지 정하기 위해
        float angle = Vector3.Angle(grabbedHand, insideHandModel.localPosition.normalized) * crossHandle.normalized.z;
        //각을 더한다.
        totalRotateAngle += angle;
        //각을 더한만큼 돌린다.
        handle.Rotate(0, 0, angle);

        //내가 잡았던 손 위치를 돌린만큼 같이 돌린다.
        grabbedHand = insideHandModel.localPosition.normalized;
    }
}