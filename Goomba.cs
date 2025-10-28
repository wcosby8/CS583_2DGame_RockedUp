using UnityEngine;

public class Goomba : MonoBehaviour {
  public int damage = 10;
  public float moveSpeed = 2f;
  public float despawnX = -12f; //despawn when off screen
  Rigidbody2D rb;
  
  void Awake() {
    rb = GetComponent<Rigidbody2D>(); //get the rigidbody component of the goomba
    if(rb !=null){
      //set the body type to dynamic and prevent rotation
      rb.bodyType = RigidbodyType2D.Dynamic;
      rb.constraints = RigidbodyConstraints2D.FreezeRotation; //prevent rotation
    }
  }
  
  void Start(){
    //move left
    if(rb !=null) {
      rb.linearVelocity = new Vector2(-moveSpeed,0);
    }
  }
  
  //
  void Update() {
    if(rb !=null) {
      rb.linearVelocity =new Vector2(-moveSpeed,rb.linearVelocity.y); //maintain horizontal movement
    }
    
    //despawn when off screen
    if(transform.position.x < despawnX) {
      Destroy(gameObject);
    }
  }
  
  void OnCollisionEnter2D(Collision2D c){
    // check if collided with player
    var hp = c.collider.GetComponent<Health>();
    if(hp !=null){
      //get players rigidbody to check velocity
      var playerRb = c.collider.GetComponent<Rigidbody2D>();
      bool isStomping=false;
      
      //check if player is moving downward (jumping down on goomba)
      if(playerRb != null && playerRb.linearVelocity.y < 0){
        isStomping = true;
      }
      
      if(isStomping){
        //if the player stomped from above, destroy the rock goomba without damaging player
        Destroy(gameObject);
      } else {
        //else if the player is hit from side then damage the player
        hp.Damage(damage);
        Destroy(gameObject); //destroy the rock goomba when it hits the player, 
      }
    }
  }
}

