using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Attack : MonoBehaviour
{
    protected bool isAttack = false;
    //[SerializeField] private float coolDown = 0.5f;

    protected StarterAssetsInputs _input;
    protected ThirdPersonController _controller;

    float nextTimeToFire = 0f;
    [SerializeField] float fireRate = 5f;

    protected virtual void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<ThirdPersonController>();
    }

    protected abstract void NormalAttack();

    protected bool CheckFireRate()
    {
        if (Time.time >= this.nextTimeToFire)
        {
            this.nextTimeToFire = Time.time + (1f / this.fireRate);
            return true;
        }
        return false;
    }

    /*IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(this.coolDown);
        this.isAttack = true;
    }*/
}
