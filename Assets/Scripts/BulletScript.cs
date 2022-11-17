using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float sceneradius = 15;
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < -sceneradius || transform.position.y < -sceneradius)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > sceneradius || transform.position.y > sceneradius)
        {
            Destroy(gameObject);
        }

    }
}
