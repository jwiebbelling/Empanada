using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    public GameObject bullet;
    private float facingDirX = 1f;
    public AudioSource jumpEffect;
    public AudioSource shootingSound;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //moving left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //save direction to use later in bullet
        float dirx = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);
        if (dirx != 0)
        {
            facingDirX = dirx;
        }

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("running", dirx != 0);
        anim.SetBool("grounded", grounded);

        if (Input.GetKeyDown("space") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            jumpEffect.Play();
            anim.SetTrigger("jump");
            grounded = false;
        }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            shootingSound.Play();
            GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet.GetComponent<BulletScript>().dirx = facingDirX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}