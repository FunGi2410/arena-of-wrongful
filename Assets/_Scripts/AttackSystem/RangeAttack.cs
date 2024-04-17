using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Attack
{
    [SerializeField] private GameObject originalProjectile;
    [SerializeField] private Transform originalPoint;
    [SerializeField] private float originalSpeedProjectile;

    GameObject arrowObject;
    Transform arrowPoint;
    float speedProjectile = 15f;

    public LayerMask enemyLayer;
    public float range = 5;

    Transform weakestEnemy;

    protected override void Start()
    {
        base.Start();
        SetReturnOriginal();
    }

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
            _controller.Animator.SetBool("Shooting", true);
        }
        else
        {
            // stop animation
            _controller.Animator.SetBool("Shooting", false);
        }
    }

    // Called in event animation shooting
    public void Shoot()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, range, enemyLayer);
        if (hitEnemies.Length > 0)
        {
            weakestEnemy = hitEnemies[0].transform;
            for (int i = 1; i < hitEnemies.Length; i++)
            {
                if (hitEnemies[i].GetComponent<LivingEntity>().Health < weakestEnemy.GetComponent<LivingEntity>().Health)
                {
                    weakestEnemy = hitEnemies[i].transform;
                }
            }
        }
        else weakestEnemy = null; // Dont have any enemy detect, so player shoot foward

        transform.LookAt(weakestEnemy);
        Arrow arrow = Instantiate(this.arrowObject, this.arrowPoint.position, transform.rotation).GetComponent<Arrow>();
        arrow.SetTarget(weakestEnemy);
        arrow.SetSpeed(speedProjectile);
        
    }

    public void SetSpeedProjectile(float newSpeed)
    {
        this.speedProjectile = newSpeed;
    }

    public void SetProjectile (GameObject newObject)
    {
        this.arrowObject = newObject;
    }

    public void SetPointOriginToFire(Transform newPoint)
    {
        this.arrowPoint = newPoint;
    }

    public void SetReturnOriginal()
    {
        this.arrowObject = originalProjectile;
        this.arrowPoint = originalPoint;
        this.speedProjectile = originalSpeedProjectile;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
