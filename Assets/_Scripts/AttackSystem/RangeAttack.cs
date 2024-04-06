using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Attack
{
    protected override void NormalAttack()
    {
        AimShoot();
    }

    private void Update()
    {
        NormalAttack();
    }

    private void AimShoot()
    {
        if(_input.isAiming && !_input.sprint && _controller.Grounded)
        {
            // play animation
            _controller.Animator.SetBool("Aiming", _input.isAiming);
            _controller.Animator.SetBool("Shooting", _input.isAiming);
        }
        else
        {
            // stop animation
            _controller.Animator.SetBool("Aiming", false);
            _controller.Animator.SetBool("Shooting", false);
        }
    }
}
