using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour { 

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()  {
        rb.velocity = transform.right * speed;
    }
    
//<<<<<<< HEAD
 //   void OnTriggerEnter2D (Object1 hitInfo)
 //   {
 //       Enemy enemy = hitInfo.GetComponent<Enemy>();
 //       if (enemy != null)
  //      {
  //          enemy.TakeDamage(damage);
  //      }

 //       Instantiate(impactEffect, transform.position, transform.rotation);

  //      Destroy(gameObject);
  //  }
//=======
   // void OnTriggerEnter2D (Object1 hitInfo)
  //  {
 //       Enemy enemy = hitInfo.GetComponent<Enemy>();
  //      if (enemy != null)
  //      {
  //          enemy.TakeDamage(damage);
  //      }

   //     Instantiate(impactEffect, transform.position, transform.rotation);

  //      Destroy(gameObject);
  //  }
//>>>>>>> 050524edc9a5c2cb57798742bfd8c2db87871626


}
