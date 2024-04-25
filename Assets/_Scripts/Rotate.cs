using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Update()
    {
        //transform.eulerAngles += new Vector3(0, 180 * Time.deltaTime, 0);
        transform.Rotate(0f, 10f * Time.deltaTime * 10f, 0f);
    }
}
