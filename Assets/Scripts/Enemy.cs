using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float dirx = 1f;
    public float speed = 10f;
    int hp = 2;
    int enemyDead;
    [SerializeField] private Text pointsText;
    public GameObject enemyPrefab;
    [SerializeField] private AudioSource enemyScreaming;

    void Update()
    {
        //ask Jorrit to help with sounds
        //add text to prefab, how???
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right *dirx, 0.4f);

        if (hit.collider != null)
        {
            dirx *= -1f;
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        
        if (hp <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            enemyScreaming.Play();
            Destroy(gameObject);
            Instantiate(enemyPrefab, new Vector2(16, 0), Quaternion.identity);
        }
    }
    void Die()
    {
        enemyScreaming.Play();
        Destroy(gameObject);
        enemyDead++;
        pointsText.text = "Points: " + enemyDead;
    }
}
