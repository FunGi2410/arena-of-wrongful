using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    [SerializeField] protected float health;
    protected bool dead;

    public event System.Action OnDeath;
    public event System.Action OnTakeDame;

    public void TakeDame(float dame)
    {
        this.health -= dame;
        print(name + " Cur Health: " + this.health);

        if (this.OnTakeDame != null)
        {
            this.OnTakeDame();
        }

        if (this.health <= 0 && !this.dead)
        {
            this.Die();
        }
    }

    [ContextMenu("Self Detruct")]
    protected virtual void Die()
    {
        dead = true;
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}