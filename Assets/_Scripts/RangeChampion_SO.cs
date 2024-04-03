using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Range Champion SO", order = 1)]
public class RangeChampion_SO : ScriptableObject
{
    public string championName;

    public float fireRate;
    public float damage;
    public float health;
    public float forceBullet;

    [SerializeField]
    public GameObject bulletPrefab;
}
