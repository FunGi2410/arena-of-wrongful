using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    bool isDamage = false;
    List<GameObject> hitObjects;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        this.hitObjects = new List<GameObject>();
    }

    private void Update()
    {
        if (!isDamage) return;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, - transform.up, out hit, this.weaponLength, layerMask))
        {
            if (!this.hitObjects.Contains(hit.transform.gameObject))
            {
                print("damage " + hit.transform.gameObject.name);
                hitObjects.Add(hit.transform.gameObject);

                // Take dame
                IDamageable damageableObject = hit.transform.gameObject.GetComponent<IDamageable>();
                if (damageableObject != null)
                {
                    damageableObject.TakeDame(this.weaponDamage);
                }
            }
        }
    }

    public void StartDamage()
    {
        this.isDamage = true;
        this.hitObjects.Clear();
    }

    public void EndDamage()
    {
        this.isDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * this.weaponLength);
    }
}
