using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtrl : MonoBehaviour
{
    private bool isAttack = true;
    [SerializeField] private float coolDown = 0.5f;
    [SerializeField] GameObject weaponHolder;

    private Animator animator;

    private void Start()
    {
        this.animator = this.weaponHolder.GetComponent<Animator>();
    }

    private void Update()
    {
        NormalAttack();
    }

    protected void NormalAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (this.isAttack)
            {
                this.isAttack = false;
                this.animator.SetTrigger("Attack");
                StartCoroutine(ResetAttackCoolDown());
            }
        }
    }

    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(this.coolDown);
        this.isAttack = true;
    }
}
