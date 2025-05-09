using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;

    private int selectedCharacterP1 = 0;
    private int selectedCharacterP2 = 1;

    // Called by Player 1's selection buttons
    public void SelectCharacterForPlayer1(int index)
    {
        if (index >= 0 && index < characters.Length)
        {
            selectedCharacterP1 = index;
            PlayerPrefs.SetInt("SelectedCharacterP1", selectedCharacterP1);
            PlayerPrefs.Save(); // Ensures value is written to disk
            Debug.Log("Player 1 selected index: " + selectedCharacterP1);
        }
        else
        {
            Debug.LogWarning("Invalid Player 1 selection index: " + index);
        }
    }

    // Called by Player 2's selection buttons
    public void SelectCharacterForPlayer2(int index)
    {
        if (index >= 0 && index < characters.Length)
        {
            selectedCharacterP2 = index;
            PlayerPrefs.SetInt("SelectedCharacterP2", selectedCharacterP2);
            PlayerPrefs.Save(); // Ensures value is written to disk
            Debug.Log("Player 2 selected index: " + selectedCharacterP2);
        }
        else
        {
            Debug.LogWarning("Invalid Player 2 selection index: " + index);
        }
    }

    // Called by Start Game button
    public void StartGame()
    {
        Debug.Log("Loading game scene...");
        SceneManager.LoadScene("The Town"); // Replace with your actual game scene name
    }
}
