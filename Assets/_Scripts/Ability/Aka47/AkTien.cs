using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AkTien : Ability
{
    [SerializeField] GameObject akGun;
    [SerializeField] Transform akGunPos;
    [SerializeField] GameObject bullet;
    [SerializeField] float speedBullet;
    GameObject gun;

    public override void Activate(GameObject parent)
    {
        RangeAttack rangeAttack = parent.GetComponent<RangeAttack>();
        
        akGunPos = parent.transform.GetChild(0);
        gun = Instantiate(akGun, akGunPos.position, parent.transform.rotation);
        gun.transform.parent = akGunPos;

        rangeAttack.SetProjectile(bullet);
        rangeAttack.SetPointOriginToFire(akGunPos);
        rangeAttack.SetSpeedProjectile(speedBullet);
    }

    public override void EndActivate(GameObject parent)
    {
        RangeAttack rangeAttack = parent.GetComponent<RangeAttack>();
        rangeAttack.SetReturnOriginal();
        Destroy(gun);
    }
}
