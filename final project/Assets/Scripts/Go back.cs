using UnityEngine;
using UnityEngine.SceneManagement;

public class goback : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("OpeningScreen"); // Replace with the name of your main game scene
    }
}