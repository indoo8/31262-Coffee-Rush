using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

<<<<<<< HEAD
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
=======
 //   public void TakeDamage (int damage)
 //   {
 //       health -= damage;
 //       if (health <= 0)
 ///       {
 //           Die();
 //       }
 //   }

   // void Die ()
   // {
  //      Instantate(deathEffect, transform.position, Quaternion.identify);
  //      Destroy(gameObject);
  //  }
>>>>>>> 050524edc9a5c2cb57798742bfd8c2db87871626

}