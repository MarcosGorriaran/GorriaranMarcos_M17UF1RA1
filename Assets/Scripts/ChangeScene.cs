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
            ConserveBetweenScenes.DestroyAllInstances();
            if (Player.instance != null)
            {
                Destroy(ConserveBetweenScenes.instance.gameObject);
            }
            
        }
        SceneManager.LoadScene(sceneName);
    }
}
