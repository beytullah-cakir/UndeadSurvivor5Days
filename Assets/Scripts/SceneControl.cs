using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public int loading_scene_index,upgrade_scene_index;
    public void LoadLoadingScene()
    {
        SceneManager.LoadScene(loading_scene_index);
    }

    public void LoadUpgradeScene()
    {
        SceneManager.LoadScene(upgrade_scene_index);
    }

    public void LoadScene(int scene_index)
    {
        SceneManager.LoadScene(scene_index);
    }
}
