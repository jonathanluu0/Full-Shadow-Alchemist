using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Transition Test");
    }

    public void OpenOptions()
    {
        // Implement options menu functionality here
    }

    public void QuitGame()
    {
        //This is a check for the play editor for testing.
        #if UNITY_EDITOR
            //If it is the Unity editor then stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            //If it is a build and running outside of unity this will run
            //and quit the application.
            Application.Quit();
        #endif
    }
}

