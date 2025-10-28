using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
  public float roundTime = 90f;
  public TextMeshProUGUI timerText;
  public TextMeshProUGUI messageText;
  public Health playerHealth;
  public AudioManager audioManager;

  //this is the health bar that will be used to display the player's health
  public Slider healthBar;

  float t; 
  bool ended; //t is the timer, ended is a boolean that is used to check if the game has ended

  void Start() {
    t = roundTime;
    messageText.text = "";
    if (healthBar) { //if the health bar is not null which means the health bar is in the scene
      healthBar.minValue = 0; 
      healthBar.maxValue = playerHealth.maxHP; //set the maximum value of the health bar to the maximum health of the player
      healthBar.value = playerHealth.currentHP; //set the value of the health bar to the current health of the player
    }
    
    playerHealth.onDeath += Lose; //onDeath come from the Health.cs script, onDeath is the event that is called when health reaches 0
    //lose is the method that is called when the player dies
    playerHealth.onDamage += PlayHitSound; //subscribe to the onDamage event to play hit sound
  }

  void PlayHitSound() {
    if (audioManager && audioManager.hitByRock) {
      audioManager.PlaySFX(audioManager.hitByRock);
    }
  }

  void Update() {
    //if the game has ended and the R key is pressed, restart the game, which will load the main menu
    if (ended && Keyboard.current.rKey.wasPressedThisFrame) {
      Restart();
      return;
    }
    
    if (ended) return; //if the game has ended, return and do not continue with the code
    
    t -= Time.deltaTime;// decrement the timer by the time since the last frame
    timerText.text = Mathf.CeilToInt(t).ToString();//update the timer text to the current timer
    
    if (healthBar) healthBar.value = playerHealth.currentHP;//update the health bar to the current health of the player

    if (t <= 0) Win();// if the timer is 0, call the Win method

    
    if (Keyboard.current.escapeKey.wasPressedThisFrame) TogglePause();// if the escape key is pressed, call the TogglePause method
  }

  
  void Win(){ 
    ended = true; //set the game to ended
    messageText.text = "You Win! Press R for Main Menu"; 
    }

  void Lose(){ 
    ended = true; 
    messageText.text ="You Lose! Press R for Main Menu";
    
    //play death sound
    if (audioManager && audioManager.death) {
      audioManager.PlaySFX(audioManager.death);
    }
    }

  void TogglePause(){ 
    Time.timeScale =Time.timeScale==0 ? 1 : 0; //if the time scale is 0, set it to 1, otherwise set it to 0
    }

  void Restart(){ 
    UnityEngine.SceneManagement.SceneManager.LoadScene(0); //load the main menu scene
    }
}


