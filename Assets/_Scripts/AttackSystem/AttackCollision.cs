using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
/*    private void OnCollisionEnter(Collision collision)
    {
        print("On collision at weapon");
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDame(2);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDame(2);
        }
    }
}
