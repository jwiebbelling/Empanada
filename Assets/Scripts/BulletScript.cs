using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;
    public float dirx = 1f;
    void Update()
    {
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
        Destroy(gameObject, lifeTime);
    }
}