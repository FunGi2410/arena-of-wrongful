using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : LivingEntity
{
    private Animator animator;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
    }
    public override void TakeDame(float dame)
    {
        base.TakeDame(dame);
        this.animator.SetTrigger("damage");
    }

    protected override void Die()
    {
        base.Die();
        this.animator.SetTrigger("die");
    }
}
