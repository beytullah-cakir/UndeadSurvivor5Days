using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public Button playButton, upgradeButton;
    //Sahneler aras� ge�i� i�in yaz�ld�
    public static void LoadScene(string loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }

    private void Update()
    {
        
    }

    public void NextLevel()
    {
        GameManager.NextDay();
    }


    public void GameOver()
    {
        if (GameManager.days >= 5)
        {
            playButton.gameObject.SetActive(false);
            upgradeButton.gameObject.SetActive(false);
        }
    }

}
