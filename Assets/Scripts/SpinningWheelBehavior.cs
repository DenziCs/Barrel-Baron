using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheelBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 rotationVector = Vector3.zero;
        rotationVector.z -= 100 * Time.deltaTime;
        this.gameObject.transform.Rotate(rotationVector);
    }
}