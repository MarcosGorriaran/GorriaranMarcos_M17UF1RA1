using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Canvas))]
public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    Canvas screen;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;        
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        screen = GetComponent<Canvas>();
    }
    public void ShowScreen()
    {
        screen.enabled = true;
        Player.instance.inputDisabled = true;
        PauseGame.instance.disableInput = true;
    }
}
