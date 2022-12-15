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
    
    public GameObject enemyPrefab;
    [SerializeField] private Text pointsText;
    [SerializeField] private AudioSource enemyScreaming;
    private Animator anim;

    private void Start()
    {
        if (pointsText == null)
        {
            pointsText = GameObject.FindGameObjectWithTag("PointsText").GetComponent<Text>();
        }
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //ask Jorrit to help with sounds == make animation play sound, not the enemy
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
            GetComponent<Collider2D>().enabled = false;
            anim.SetTrigger("enemypoof");
            anim.Play("enemydie");
            Instantiate(enemyPrefab, new Vector2(16, 0), Quaternion.identity);
        }
    }
    void Die()
    {
        anim.Play("enemydie");
        anim.SetTrigger("enemypoof");
        enemyDead++;
        pointsText.text = "Points: " + enemyDead;
    }
    void Scream()
    {
        enemyScreaming.Play();

        if (enemyScreaming == null)
        {
            enemyScreaming = GameObject.FindGameObjectWithTag("Scream").GetComponent<AudioSource>();
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
