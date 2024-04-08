using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Attack
{
    [SerializeField] private GameObject arrowObject;
    [SerializeField] private Transform arrowPoint;

    protected override void NormalAttack()
    {
        AimShoot();
    }

    /*private void Start()
    {
        Instantiate(this.arrowObject, pos, this.arrowObject.transform.rotation);
        Instantiate(this.arrowObject, pos2, Quaternion.identity);
    }*/

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

    public void Shoot()
    {
        GameObject arrow = Instantiate(this.arrowObject, this.arrowPoint.position, transform.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
    }
}
