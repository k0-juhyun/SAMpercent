using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLight : MonoBehaviour
{
    private Transform lightObj;

    private MeshRenderer meshRenderer;
    private void Awake()
    {
        lightObj = transform.GetChild(0);
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        lightObj.gameObject.SetActive(meshRenderer.material.color != Color.gray);
    }
}
