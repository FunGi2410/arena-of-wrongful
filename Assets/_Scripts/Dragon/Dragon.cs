using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : LivingEntity
{
    private Animator animator;
    [SerializeField] private Slider healthBar;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.healthBar.value = health;
    }
    public override void TakeDame(float dame)
    {
        base.TakeDame(dame);
        this.animator.SetTrigger("damage");
        this.healthBar.value = health;
    }

    protected override void Die()
    {
        base.Die();
        this.animator.SetTrigger("die");
    }
}
