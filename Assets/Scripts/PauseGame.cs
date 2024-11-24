using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PauseGame : MonoBehaviour
{
    public static PauseGame instance;
    public bool disableInput;
    Canvas menu;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        menu = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !disableInput)
        {
            
            if (Time.timeScale == 0)
            {
                Player.instance.inputDisabled = false;
                Time.timeScale = 1;
                menu.enabled = false;
            }
            else
            {
                Player.instance.inputDisabled = true;
                Time.timeScale = 0;
                menu.enabled = true;
            }

        }
    }
}
