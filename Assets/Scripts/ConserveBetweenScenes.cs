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
        instances.Remove(instanceID);
    }
    public static void DestroyAllInstances()
    {
        foreach (GameObject instance in instances.Values)
        {
            Destroy(instance);
        }
        instances = new Dictionary<string, GameObject> ();
    }
    public static void AddInstance(GameObject obj)
    {
        if (!instances.ContainsKey(obj.name))
        {
            DontDestroyOnLoad(obj);
            instances.Add(obj.name, obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}
