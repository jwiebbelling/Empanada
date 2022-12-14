using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;
    public float dirx = 1f;
    //private Animator anim;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);
    }
}