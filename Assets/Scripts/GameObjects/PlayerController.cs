using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameManager gm;
    public AudioSource jumpSound;

    public float jumpForce;
    public float horizontalSpeed;
    public bool xDirectionRight = true;

    private bool isJumping, jumpCancel;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        if(!gm.isPaused)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.touches[0];

                if (touch.phase == TouchPhase.Began)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        jumpSound.Play();
                        isJumping = true;
                        xDirectionRight = false;
                    }
                    else if (touch.position.x > Screen.width / 2)
                    {
                        //print("Right");
                        jumpSound.Play();
                        isJumping = true;
                        xDirectionRight = true;
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    //print("Screen let go");
                }
            }
        }
		

        if(Input.touchCount == 3 && gm.playerIsActive)
        {
            gm.isPaused = true;
        }

        Vector2 playerSize = GetComponent<Renderer>().bounds.size;
        float distance = (transform.position - Camera.main.transform.position).z;
        float leftCamBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + (playerSize.x / 2);
        float rightCamBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0, distance)).x + (playerSize.x / 2);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftCamBorder, rightCamBorder),
                                        (transform.position.y),
                                        transform.position.z);
    }

    private void FixedUpdate()
    {
        if(isJumping)
        {
            jump();
        }

        if(jumpCancel)
        {
            isJumping = false;
        }
    }

    void jump()
    {

        if(xDirectionRight)
        {
            rb.velocity = new Vector2(horizontalSpeed, jumpForce);
            jumpCancel = true;
        }

        if (!xDirectionRight)
        {
            rb.velocity = new Vector2(-horizontalSpeed, jumpForce);
            jumpCancel = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Kill Area")
        {
            gm.killPlayer();

           
        }
    }
}
