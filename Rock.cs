using UnityEngine;

public class Rock : MonoBehaviour {
  public int damage = 10; 
  public float despawnY = -6f; //the y position at which the rock will be destroyed no matter what, it also gets destroyed when it collides with another onject
  void OnCollisionEnter2D(Collision2D c){ //when the rock collides with another object
    var hp = c.collider.GetComponent<Health>(); //get the Health component of the object the rock collided with
    if(hp != null){ hp.Damage(damage); } //if the object has a Health component, damage it
    Destroy(gameObject); 
  }
  void Update(){ 
    if(transform.position.y < despawnY) Destroy(gameObject); 
    } //if the rock's y position is less than the despawn y position, destroy the rock
}

