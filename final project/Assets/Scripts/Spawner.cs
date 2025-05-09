using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform player1Spawn;
    public Transform player2Spawn;

    void Start()
    {
        if (characterPrefabs == null || characterPrefabs.Length == 0)
        {
            Debug.LogError("Character prefab array is empty!");
            return;
        }

        int charIndex1 = PlayerPrefs.GetInt("SelectedCharacterP1", 0);
        int charIndex2 = PlayerPrefs.GetInt("SelectedCharacterP2", 1);

        Debug.Log($"Read from PlayerPrefs: Player1={charIndex1}, Player2={charIndex2}");
        Debug.Log("characterPrefabs.Length = " + characterPrefabs.Length);

        // Clamp the indices to prevent crashing
        charIndex1 = Mathf.Clamp(charIndex1, 0, characterPrefabs.Length - 1);
        charIndex2 = Mathf.Clamp(charIndex2, 0, characterPrefabs.Length - 1);

        Instantiate(characterPrefabs[charIndex1], player1Spawn.position, Quaternion.identity);
        Instantiate(characterPrefabs[charIndex2], player2Spawn.position, Quaternion.identity);

        Debug.Log("Both characters spawned.");
    }
}
