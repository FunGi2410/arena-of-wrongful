using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Attack : MonoBehaviour
{
    private bool isAttack = true;
    [SerializeField] private float coolDown = 0.5f;

    protected StarterAssetsInputs _input;
    protected ThirdPersonController _controller;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<ThirdPersonController>();
    }

    protected abstract void NormalAttack();

    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(this.coolDown);
        this.isAttack = true;
    }
}
