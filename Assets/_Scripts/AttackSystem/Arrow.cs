using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float timeToDes = 10f;
    float dame = 2;
    void Start()
    {
        Destroy(gameObject, this.timeToDes);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided " + other.name);
        Destroy(transform.GetComponent<Rigidbody>());

        if (!other.gameObject.CompareTag("Dragon")) return;
        IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDame(dame);
        }
    }
}
