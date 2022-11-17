using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bullet;
    public GameObject muzzle;

    void Start()
    {
        
    }

    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet, muzzle.transform).GetComponent<Rigidbody2D>().AddForce(muzzle.transform.position * -10, ForceMode2D.Impulse);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
