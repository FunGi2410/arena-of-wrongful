using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform origin;

    float nextTimeToFire;
    [SerializeField] float fireRate = 5;
    [SerializeField] float speed = 10;

    private void Update()
    {
        if (CheckFireRate()) Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(this.bulletPref, this.origin.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    protected bool CheckFireRate()
    {
        if (Time.time >= this.nextTimeToFire)
        {
            this.nextTimeToFire = Time.time + (1f / this.fireRate);
            return true;
        }
        return false;
    }
}
