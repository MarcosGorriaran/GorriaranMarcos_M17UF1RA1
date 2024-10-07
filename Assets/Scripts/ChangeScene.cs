using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    [SerializeField]
    Vector2 playerStart;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = playerStart;
        SceneManager.LoadScene(sceneName);
    }
}
