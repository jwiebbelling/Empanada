using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private AudioClip jumpSoundEffect;

    public GameObject bullet;

    private bool grounded;


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

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Y) && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
            grounded = false;
        }

        anim.SetBool("running", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}