using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleButton : MonoBehaviour
{
    public GameObject CarSeat;
    public RawImage FrontCarSeatImage;
    public RawImage SideCarSeatImage;

    public XRGrabInteractable upButton;
    public XRGrabInteractable downButton;
    public XRGrabInteractable leftButton;
    public XRGrabInteractable rightButton;
    public XRGrabInteractable centerButton;

    private Vector3 initialPosition;

    private void Start()
    {
        // CarSeat의 초기 위치를 저장합니다.
        initialPosition = CarSeat.transform.position;

        // 각 버튼에 이벤트 핸들러를 추가합니다.
        upButton.onSelectEntered.AddListener(MoveCarSeatUp);
        downButton.onSelectEntered.AddListener(MoveCarSeatDown);
        leftButton.onSelectEntered.AddListener(MoveCarSeatLeft);
        rightButton.onSelectEntered.AddListener(MoveCarSeatRight);
        centerButton.onSelectEntered.AddListener(ChangeCarSeat);
    }

    private void MoveCarSeatUp(XRBaseInteractor interactor)
    {
        // 위로 이동
        CarSeat.transform.Translate(Vector3.up * 0.1f);
    }

    private void MoveCarSeatDown(XRBaseInteractor interactor)
    {
        // 아래로 이동
        CarSeat.transform.Translate(Vector3.down * 0.1f);
    }

    private void MoveCarSeatLeft(XRBaseInteractor interactor)
    {
        // 왼쪽으로 이동
        CarSeat.transform.Translate(Vector3.left * 0.1f);
    }

    private void MoveCarSeatRight(XRBaseInteractor interactor)
    {
        // 오른쪽으로 이동
        CarSeat.transform.Translate(Vector3.right * 0.1f);
    }

    private void ChangeCarSeat(XRBaseInteractor interactor)
    {
        if (FrontCarSeatImage.gameObject.activeSelf)
        {
            FrontCarSeatImage.gameObject.SetActive(false);
            SideCarSeatImage.gameObject.SetActive(true);
        }
        else
        {
            SideCarSeatImage.gameObject.SetActive(false);
            FrontCarSeatImage.gameObject.SetActive(true);
        }
    }
}