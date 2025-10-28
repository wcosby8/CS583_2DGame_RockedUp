using UnityEngine;

public class GoombaSpawner : MonoBehaviour {
  public GameObject goombaPrefab;
  public float spawnRate = 3.0f; //goombas per second
  public float spawnY = -3f; //spawn on the ground
  public float spawnX = 10f; //spawn from the right side of screen
  float t;
  
  void Update() {
    //spawn a goomba at a regular interval
    t += Time.deltaTime;
    if(t >= 1f/spawnRate){ //if the timer has reached the spawn rate
      t = 0f;
      Vector3 pos = new Vector3(spawnX, spawnY, 0); 
      Instantiate(goombaPrefab, pos,Quaternion.identity);
    }
  }
}

