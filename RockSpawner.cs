using UnityEngine;

public class RockSpawner : MonoBehaviour {
  public GameObject rockPrefab;
  public float spawnRate = 1.0f; //rocks per second
  public float spawnXMin = -8f, spawnXMax = 8f, spawnY = 6f;
  float t;
  void Update(){
    //spawn a rock at a random position
    t += Time.deltaTime; //increment the timer by the time since the last frame
    if(t >= 1f/spawnRate){ //check if the timer has reached the spawn rate 
      t = 0f; //reset the timer
      Vector3 pos = new Vector3(Random.Range(spawnXMin, spawnXMax), spawnY, 0); //generate a random position for the rock
      Instantiate(rockPrefab, pos,Quaternion.identity); //instantiate the rock at the random position
    }
  }
}

