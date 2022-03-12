using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class FinDeNiveau : MonoBehaviour
{
    private Dictionary<string, string> _nextLevels = new Dictionary<string, string>(){
            {"Level1", "Level2"},
            {"Level2", "Level3"},
            {"Level3", "MainMenu"},
        };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            string levelName = SceneManager.GetActiveScene().name;
            Debug.Log("Félicitation, le niveau est terminé.");
            Debug.Log(GameManager.Instance.PlayerData.CompleteLevel(levelName));
            GameManager.Instance.SaveData();
            SceneManager.LoadScene(_nextLevels[levelName]);
        }
    }
}
