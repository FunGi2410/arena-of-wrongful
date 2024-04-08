using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float timeToDes = 10f;
    void Start()
    {
        Destroy(gameObject, this.timeToDes);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided " + other.name);
        Destroy(transform.GetComponent<Rigidbody>());
    }
}
