using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChampion : Champion
{
    [SerializeField]
    private RangeChampion_SO rangeChampion_SO;

    protected override void Start()
    {
        this.startingHealth = this.rangeChampion_SO.health;
        this.Health = this.startingHealth;
    }
}
