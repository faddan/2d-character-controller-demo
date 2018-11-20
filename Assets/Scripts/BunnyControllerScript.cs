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

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
