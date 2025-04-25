using UnityEngine;
using UnityEngine.SceneManagement;

public class changingscenes : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("OpeningScreen"); // Replace with the name of your main game scene
    }

    public void Skip()
    {
        SceneManager.LoadScene("EnchantedForest"); // Replace with the name of your main game sceneDebug.Log("EnchantedForest");

    }
}