using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGiveDame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDame(2);
        }
    }
}
