using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAddForce : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
    }
}
