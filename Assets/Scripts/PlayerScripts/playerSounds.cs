using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds : MonoBehaviour {

    public string num;
    public Rigidbody2D rb;

    public AudioClip walk;
    public AudioSource MusicSource;
    public float moveHorizontal;
    public bool isGrounded;
    public Transform checkGround;
    public float checkRadius;
    public LayerMask whatiIsGround;

    void Start () {
        MusicSource.clip = walk;
    }
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatiIsGround);
        moveHorizontal = Input.GetAxis("Horizontal"+num);
        if(moveHorizontal!= 0 && isGrounded && MusicSource.isPlaying == false)
        {
            MusicSource.Play();
        }
    }
}
