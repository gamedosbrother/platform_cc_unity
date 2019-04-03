using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public void TakeDamage(float damage)
    {
        if(damage < 0) return;
        health -= damage;
    }
}
