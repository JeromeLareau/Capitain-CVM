using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonAction : MonoBehaviour
{
    /// <summary>
    /// Permet d'afficher un panel transmis en paramètre
    /// </summary>
    /// <param name="PanelAOuvrir">Panel à afficher</param>
    public void AfficherPanel(GameObject PanelAOuvrir)
    {
        PanelAOuvrir.SetActive(true);
    }

    /// <summary>
    /// Permet de ferme aussi le panel actuel
    /// </summary>
    /// <param name="PanelAFermer">Panel à fermer</param>
    public void FermerPanel(GameObject PanelAFermer)
    {
        PanelAFermer.SetActive(false);
    }

    /// <summary>
    /// Permet de charger un niveau
    /// </summary>
    /// <param name="nom">Nom du niveau à charger</param>
    public void ChargerNiveau(string nom)
    {
        SceneManager.LoadScene(nom);
    }

    /// <summary>
    /// Permet de fermer l'application
    /// </summary>
    public void Quitter()
    {
        Application.Quit();
    }

    public void LevelCompleteVerification()
    {
        for (int i = 1; i < GameManager.Instance.PlayerData.CompletedLevels.Count; i++)
        {
            if (GameManager.Instance.PlayerData.CompletedLevels["Level"+i])
            {
                Button btn = GameObject.Find("ButtonNiv"+(i+1)).GetComponent<Button>();
                btn.interactable = true;
            }
        }
    }

    public void GemCollectedVerification()
    {
        foreach (string gem in GameManager.Instance.PlayerData.CollectedGems.Keys)
        {
            if (GameManager.Instance.PlayerData.CollectedGems[gem])
            {
                SpriteRenderer sr = GameObject.Find(gem).GetComponent<SpriteRenderer>();
                sr.color = Color.white;
            }
        }
    }
}
