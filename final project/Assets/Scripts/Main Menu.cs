using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("The Town"); // Replace with the name of your main game scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // This will close the game when built
    }
}