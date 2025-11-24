using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text eneimesLeftText;
    [SerializeField] GameObject youWinText;

    int eneimesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    public void AjustEnemiesLeft(int amount)
    {
        eneimesLeft += amount;
        eneimesLeftText.text = ENEMIES_LEFT_STRING + eneimesLeft.ToString();

        if (eneimesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }
   public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Debug.LogWarning("Does not work in the unity editor!! ");
        Application.Quit();
    }
}
