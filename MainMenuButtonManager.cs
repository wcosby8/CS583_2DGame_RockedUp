using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.MainMenuButtons _buttonType; //the type of button that was clicked
    public void ButtonClicked(){
        MainMenuManager._.MainMenuButtonClicked(_buttonType); //call the MainMenuButtonClicked method in the MainMenuManager
    }
}
