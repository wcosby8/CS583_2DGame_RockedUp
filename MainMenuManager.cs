using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager _; //Singleton pattern, which means there can only be one instance of the MainMenuManager in the scene

    [SerializeField] private bool _debugMode; 

    public enum MainMenuButtons {play, settings, credits, quit}; 

    [SerializeField] private string _sceneToLoadAfterClickingPlay;

    public void Awake(){ //Awake is called when the script instance is being loaded
        if(_ == null){ //If there is no instance of the MainMenuManager in the scene
            _ = this; //Set the instance to the current instance of the MainMenuManager
        }
        else{ 
            Debug.LogError("There are more than 1 MainMenuManager's in the scene"); //Log an error
        }
    }

    public void MainMenuButtonClicked(MainMenuButtons buttonClicked){
        DebugMessage("Button CLicked: " + buttonClicked.ToString()); //Log the button that was clicked
        switch(buttonClicked){
            case MainMenuButtons.play:
                PlayClicked(); //Call the PlayClicked method
                break;
            case MainMenuButtons.settings:
                break;
            case MainMenuButtons.credits:
                break;
            case MainMenuButtons.quit:
                QuitGame(); //Call the QuitGame method
                break;
            default:
                Debug.Log("Button clicked that wasnt implemented in MainMenuManagerMethod");
                break;

        }
    }

    private void DebugMessage(string message){
        if(_debugMode){ //If debug mode is enabled
            Debug.Log(message); //Log the message
        }
    }

    public void PlayClicked(){
        SceneManager.LoadScene(_sceneToLoadAfterClickingPlay); //Load the playble game scene
    }

    public void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode(); //exit play mode in the editor
        #else
            Application.Quit(); //quit the application
        #endif
   }


}
