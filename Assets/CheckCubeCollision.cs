using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCubeCollision : MonoBehaviour
{
    public Transform myLTB;
    public Transform myRBF;

    public Transform otherLTB;
    public Transform otherRBF;

    void Start()
    {
    }

    void Update()
    {
        if (((myLTB.position.x <= otherLTB.position.x && otherLTB.position.x <= myRBF.position.x) ||
            (myLTB.position.x <= otherRBF.position.x && otherRBF.position.x <= myRBF.position.x)) &&

            ((myRBF.position.y <= otherLTB.position.y && otherLTB.position.y <= myLTB.position.y) ||
            (myRBF.position.y <= otherRBF.position.y && otherRBF.position.y <= myLTB.position.y)) &&

            ((myLTB.position.z <= otherLTB.position.z && otherLTB.position.z <= myRBF.position.z) ||
            (myLTB.position.z <= otherRBF.position.z && otherRBF.position.z <= myRBF.position.z)))
        {
            print("otherLTB 와 충돌하고 있음 ");
        }

        //if ((myLTB.position.x <= otherRBF.position.x && otherRBF.position.x <= myRBF.position.x) &&
        //    (myRBF.position.y <= otherRBF.position.y && otherRBF.position.y <= myLTB.position.y) &&
        //    (myLTB.position.z <= otherRBF.position.z && otherRBF.position.z <= myRBF.position.z))
        //{
        //    print("otherLTB 와 충돌하고 있음 ");
        //}
    }
}
