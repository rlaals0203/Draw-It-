using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 25) * Time.deltaTime);
    }
}
