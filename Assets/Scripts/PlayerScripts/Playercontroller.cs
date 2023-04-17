using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public PowerupController playerPowerUpController;

    public string num;

    public float speed;
    public float jumpforce;
    public Rigidbody2D rb;

    public float fallmultiplier;

    private bool faceright;

    public bool isGrounded;
    public Transform checkGround;
    public float checkRadius;
    public LayerMask whatiIsGround;
    public bool doubleJump;

    public AudioClip jump;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        faceright = true;
        MusicSource.clip = jump;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y -0.2f < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
        bool var = isGrounded || doubleJump;
        if (Input.GetButtonDown("Jump"+num) && var) // jump
        {
            rb.velocity = Vector2.up * jumpforce;
            doubleJump = false;
            MusicSource.Play();
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatiIsGround);
        if (isGrounded)
            doubleJump = true;
        float moveHorizontal = Input.GetAxis("Horizontal" + num);
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        if (!faceright && moveHorizontal > 0)
            flip();
        else if (faceright && moveHorizontal < 0)
            flip();
    }
    void flip()
    {
        faceright = !faceright;
        transform.Rotate(0, 180f, 0);
    }
}

