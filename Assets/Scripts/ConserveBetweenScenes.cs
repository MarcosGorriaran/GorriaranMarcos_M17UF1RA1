using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConserveBetweenScenes : MonoBehaviour
{
    public static Dictionary<string,GameObject> instances { get; private set; } = new Dictionary<string,GameObject>();
    public static ConserveBetweenScenes instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    public static void DestroyInstance(string instanceID)
    {
        Destroy(instances[instanceID]);
    }
    public static void DestroyAllInstances()
    {
        foreach (string instance in instances.Keys)
        {
            DestroyInstance(instance);
        }
    }
    public static void AddInstance(string key,GameObject obj)
    {
        if (!instances.ContainsKey(key))
        {
            DontDestroyOnLoad(obj);
            instances.Add(key, obj);
        }
        else
        {
            Destroy(obj);
        }
        
    }
}
