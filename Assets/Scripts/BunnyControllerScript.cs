using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControllerScript : MonoBehaviour {
    [SerializeField]
    public float maxSpeed = 10f;

    [SerializeField]
    bool facingRight = true;

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    Animator anim;

    [SerializeField]
    bool grounded = false;

    [SerializeField]
    public Transform groundCheck;

    [SerializeField]
    float groundRadius = 0.2f;

    [SerializeField]
    public LayerMask whatIsGround;

    [SerializeField]
    public float jumpForce = 700f;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", rb2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}

    void Update()
    {
       if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(0, jumpForce));
        } 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
