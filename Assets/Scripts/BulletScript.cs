using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 3;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

    }
}
