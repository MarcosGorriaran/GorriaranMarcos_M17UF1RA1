using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    [SerializeField]
    protected bool deleteAllInstances = false;
    public void LoadScene()
    {
        if (deleteAllInstances)
        {
            if (Player.instance != null)
            {
                Destroy(Player.instance.gameObject);
            }
            if(PauseGame.instance != null)
            {
                Destroy(PauseGame.instance.gameObject);
            }
            if(MusicController.instance != null)
            {
                Destroy(MusicController.instance.gameObject);
            }
        }
        SceneManager.LoadScene(sceneName);
    }
}
