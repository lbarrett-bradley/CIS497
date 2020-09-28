/*
 * Liam Barrett
 * Prototype 3
 * Allows player to control player object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Set reference variables to components
        rb = GetComponent<Rigidbody>();

        //set reference to our Animator component
        playerAnimator = GetComponent<Animator>();

        //set reference to audio source component
        playerAudio = GetComponent<AudioSource>();

        //start running animation on start
        playerAnimator.SetFloat("Speed_f", 1.0f);

        jumpForceMode = ForceMode.Impulse;

        //Modify gravity if it has not already been increased above -10
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //jump when player presses space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            //set the trigger to play the jump animation
            playerAnimator.SetTrigger("Jump_trig");

            //stop playing dirt particle on jump
            dirtParticle.Stop();

            //play jump sound
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            //play drit particle when player hits the ground
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;

            //play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //play explosion particle
            explosionParticle.Play();

            //play crash sound
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
