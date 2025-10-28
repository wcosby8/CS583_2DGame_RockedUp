using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
  public float moveSpeed = 5f;
  public float jumpForce = 10f;
  public float groundCheckDistance = 0.1f; //the distance to check if the player is grounded
  public float jumpCooldown = 0.5f; //cooldown timer to prevent rapid jumping,also grounded means the player is touching the ground, so the player can jump
  Rigidbody2D rb; 
  Health health; //reference to the health component
  float horizontalInput;
  bool wasGroundedLastFrame = false; //track if we were grounded last frame
  float jumpTimer = 0f; //timer to track jump cooldown

  AudioManager audioManager; //access to the audio manager script
  
  void Awake(){ 
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    rb = GetComponent<Rigidbody2D>(); //get the rigidbody component of the player
    health = GetComponent<Health>(); //get the health component to check if player is dead
  }
  
  bool IsGrounded(){
    //raycasting is a way to check if the player is touching the ground
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance); //raycast down from the player's position to the groundCheckDistance
    return hit.collider != null; //if the raycast hits something, return true, otherwise return false
  }
  
  void Update(){
    //don't allow input if player is dead
    if (health.currentHP <= 0) {
      horizontalInput = 0; //stop movement input
      return; //exit early if dead
    }
    
    bool isGrounded = IsGrounded();
    
    //get horizontal input only
    horizontalInput = Keyboard.current.aKey.isPressed ? -1 : (Keyboard.current.dKey.isPressed ? 1 : 0); //if the a key is pressed, set the horizontal input to -1, if the d key is pressed, set the horizontal input to 1, otherwise set the horizontal input to 0
    
    //decrement jump timer
    if (jumpTimer > 0f){
      jumpTimer -= Time.deltaTime;
    }
    
    //play landing sound when transitioning from air to ground
    if (isGrounded&&!wasGroundedLastFrame){
      audioManager.PlaySFX(audioManager.land); //play the landing sound
    }
    
    //jump with spacebar, only if grounded and jump timer has expired
    if (isGrounded && jumpTimer <= 0f && Keyboard.current.spaceKey.wasPressedThisFrame){
      rb.linearVelocity=new Vector2(rb.linearVelocity.x, jumpForce); //set the vertical velocity of the player to the jumpForce
      audioManager.PlaySFX(audioManager.jump);//play the jump sound
      jumpTimer = jumpCooldown; //start the cooldown timer
    }
    
    wasGroundedLastFrame = isGrounded; //remember if we were grounded this frame
  }
  
  void FixedUpdate(){ 
    rb.linearVelocity=new Vector2(horizontalInput * moveSpeed,rb.linearVelocity.y); //set the horizontal velocity of the player to the horizontal input multiplied by the moveSpeed
  }
}
