using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    //Sahneler arasý geçiþ için yazýldý
    public void LoadScene(string loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }
}
