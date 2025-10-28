using UnityEngine;

public class Health : MonoBehaviour {
  public int maxHP = 100; 
  public int currentHP; 
  public System.Action<int,int> onHealthChanged; //the event that is called when the health of the object changes
  public System.Action onDeath; 
  public System.Action onDamage; 

  void Awake(){ //awake is called when the script instance is being loaded
    currentHP = maxHP; 
    onHealthChanged?.Invoke(currentHP,maxHP); 
    }

  public void Damage(int amt){ //the method that is called to damage the object, amt is the amount of damage to deal
    currentHP = Mathf.Max(0, currentHP - amt);
    onDamage?.Invoke(); //call the onDamage event when damage is taken
    onHealthChanged?.Invoke(currentHP,maxHP); 
    if(currentHP==0) onDeath?.Invoke(); //call the onDeath event if the current health is 0
  }
}

