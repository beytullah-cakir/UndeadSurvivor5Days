using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    //Sahneler aras� ge�i� i�in yaz�ld�
    public void LoadScene(string loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }
}
