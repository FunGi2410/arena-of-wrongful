using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    [SerializeField] private float health;
    protected bool dead;

    public float Health { get => health; set => health = value; }

    public event System.Action OnDeath;
    public event System.Action OnTakeDame;

    public virtual void TakeDame(float dame)
    {
        this.Health -= dame;
        print(name + " Cur Health: " + this.Health);

        if (this.OnTakeDame != null)
        {
            this.OnTakeDame();
        }

        if (this.Health <= 0 && !this.dead)
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
        GameObject.Destroy(gameObject, 5);
    }
}
