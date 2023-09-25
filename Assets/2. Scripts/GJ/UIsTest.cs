using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsTest : MonoBehaviour
{
    public Transform player, newCar, set01, set02, rightRay, course;
    public GameObject gameFlowManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerSetPosRot()
    {
        player.SetParent(newCar);
        player.transform.localPosition = set01.transform.localPosition;
        player.transform.localRotation = set01.transform.localRotation;
        player.transform.localScale = set01.transform.localScale;
        rightRay.gameObject.SetActive(false);
        course.gameObject.SetActive(false);
        gameFlowManager.SetActive(true);
    }
}
