using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantate(deathEffect, transform.position, Quaternion.identify);
        Destroy(gameObject);
    }

}