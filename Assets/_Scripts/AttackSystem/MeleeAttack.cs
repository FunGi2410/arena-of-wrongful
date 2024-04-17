using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    [SerializeField] Transform curWeaponHolder;
    private void Update()
    {
        if (_input.move.sqrMagnitude != 0)
        {
            this.isAttack = false;
            return;
        }
        if (_input.isAiming) this.isAttack = true;
        NormalAttack();
    }

    protected override void NormalAttack()
    {
        /*float normalizedSpeed = Mathf.InverseLerp(5, 10, fireRate);
        _controller.Animator.SetFloat("AttackSpeed", normalizedSpeed);*/
        if (CheckFireRate() && this.isAttack && !_input.sprint && _controller.Grounded)
        {
            // play animation
            _controller.Animator.SetBool("isSlashing", true);
        }
        else 
        {
            // play animation
            _controller.Animator.SetBool("isSlashing", false);
        }
    }

    public void StartDamage()
    {
        this.curWeaponHolder.GetComponentInChildren<MeleeWeapon>().StartDamage();
    }

    public void EndDamage()
    {
        this.curWeaponHolder.GetComponentInChildren<MeleeWeapon>().EndDamage();
    }
}
