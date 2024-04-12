using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AkTien : Ability
{
    [SerializeField] GameObject akGun;
    [SerializeField] Transform akGunPos;
    [SerializeField] GameObject bullet;

    public override void Activate(GameObject parent)
    {
        RangeAttack rangeAttack = parent.GetComponent<RangeAttack>();
        
        akGunPos = parent.transform.GetChild(0);
        GameObject gun = Instantiate(akGun, akGunPos.position, Quaternion.identity);
        gun.transform.parent = akGunPos;

        rangeAttack.SetProjectile(bullet);
        rangeAttack.SetPointOriginToFire(akGunPos);
    }
}
