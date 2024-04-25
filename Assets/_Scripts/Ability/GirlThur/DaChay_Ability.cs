using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DaChay_Ability : Ability
{
    GameObject weaponScaler;
    Vector3 scaleChange = new Vector3(2f, 2f, 2f);
    public override void Activate(GameObject parent)
    {
        weaponScaler = parent.GetComponent<MeleeAttack>().CurWeaponHolder.gameObject;
        weaponScaler.transform.localScale += scaleChange;
        Animator animator = parent.GetComponent<Animator>();
        animator.SetTrigger("skill_1");
    }
    public override void EndActivate(GameObject parent)
    {
        SetOriginScaleWeapon();
    }

    void SetOriginScaleWeapon()
    {
        weaponScaler.transform.localScale -= scaleChange;
    }
}
