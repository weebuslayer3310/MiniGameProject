using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator PlayerAnimation;
    public AudioSource PlayerAudio;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    private float JumpForce = 750.0f;
    public float GravityModifier = 2;
    public bool isOnGround = true;
    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        //apply gravity to the game
        Physics.gravity = Physics.gravity * GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //make the player jump by pressing "Space", prevent player from double jump, and prove that the game is not over yet.
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && GameOver == false){
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
            PlayerAnimation.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(JumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            DirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle")){
            GameOver = true;
            Debug.Log("Game Over man!!");
            PlayerAnimation.SetBool("Death_b", true);
            PlayerAnimation.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(CrashSound, 1.0f);
        }
    }
}
