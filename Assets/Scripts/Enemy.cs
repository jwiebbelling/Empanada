using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float dirx = 1f;
    public float speed = 10f;

    void Start()
    {
        //int hp = 2;
    }

    void Update()
    {
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right *dirx, 0.5f);

        if (hit.collider != null)
        {
            dirx *= -1f;
        }
    }
    public void TakeDamage()
    {
        // hp--; if (hit.collider.CompareTag("Player"))
        //{
            //kill player
        //}


    }
    void Die()
    {
        //bool isALive = false;
       // Anim.SetBool("isAlive", isALive);
    }
}
