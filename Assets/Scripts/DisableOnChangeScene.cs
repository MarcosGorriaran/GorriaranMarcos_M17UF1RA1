using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ConserveBetweenScenes))]
public class DisableOnChangeScene : MonoBehaviour
{
    [SerializeField]
    GameObject[] elementsToConserve;
    string originalScene;
    bool currentlyOnOriginalScene=true;
    bool[] originalyEnabled;
    void Awake()
    {
        originalScene = SceneManager.GetActiveScene().name;
        originalyEnabled = new bool[elementsToConserve.Length];
        foreach(GameObject obj in elementsToConserve)
        {
            ConserveBetweenScenes.AddInstance(obj.name,obj);
        }
    }
    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }
    private void OnSceneChange(Scene current, Scene next)
    {
        if(currentlyOnOriginalScene)
        {
            UpdateOriginalyEnabled();
        }
        currentlyOnOriginalScene = false;
        DisableAllObjects();
        if (next.name == originalScene)
        {
            currentlyOnOriginalScene = true;
            for (int i = 0; i < elementsToConserve.Length; i++)
            {
                elementsToConserve[i].SetActive(originalyEnabled[i]);
            }
        }
        
    }
    private void UpdateOriginalyEnabled()
    {
        for (int i = 0; i < elementsToConserve.Length; i++)
        {
            originalyEnabled[i] = elementsToConserve[i].activeSelf;
        }
    }
    private void DisableAllObjects()
    {
        foreach (GameObject obj in elementsToConserve)
        {
            obj.SetActive(false);
        }
    }
}
