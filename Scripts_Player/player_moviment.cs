using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moviment : MonoBehaviour
{
    public player_control controller;

    private float horizontalMove = 0f;

    public float runSpeed = 40f;

    private bool jump = false;

    private int numJump = 0;

    private Animator animacio;

    public AudioSource audioData;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    //public AudioClip sound;

    //public AudioClip sound;

    private void Start()
    {
        animacio = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // AudioSource.PlayClipAtPoint(sound, transform.position);

            // audioData.Play(0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animacio.SetBool("jump", true);
        }
    }

    //Moviemnt del personatge en fixedUpdate
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
        animacio.SetBool("jump", false);
    }
}