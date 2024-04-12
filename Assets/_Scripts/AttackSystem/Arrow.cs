using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float timeToDes = 10f;
    float dame = 2;
    float speed = 15;
    Transform target;
    Transform player;
    private Rigidbody rb;

    Vector3 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        this.direction = player.forward.normalized;
        Destroy(gameObject, this.timeToDes);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (rb == null) return;
        if(target != null)
        {
            this.direction = target.position - transform.position;
            rb.velocity = this.direction.normalized * speed;
            transform.LookAt(target);
        }
        else
        {
            rb.velocity = this.direction * speed;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided " + other.name);
        Destroy(transform.GetComponent<Rigidbody>());

        if (!other.gameObject.CompareTag("Dragon")) return;
        IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDame(dame);
        }
    }
}
