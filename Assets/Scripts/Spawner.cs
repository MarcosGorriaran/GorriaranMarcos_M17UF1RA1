using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject elementToSpawn;
    [SerializeField]
    Vector3 spawnOffset;
    List<GameObject> spawnStack = new List<GameObject>();
    [SerializeField]
    float timeBeforeFirstSpawn;
    [SerializeField]
    float spawnTime;
    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }
    private void OnDisable()
    {
        DisableProyectiles();
    }
    private void OnDestroy()
    {
        DestroyProyectiles();
    }

    void DestroyProyectiles()
    {
        foreach(GameObject element in spawnStack)
        {
            Destroy(element);
        }
    }
    void DisableProyectiles() 
    {
        foreach (GameObject element in spawnStack)
        {
            try
            {
                element.SetActive(false);
            }
            catch (System.Exception)
            {

            }
            
        }
    }
    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        while (true)
        {
            spawnStack.RemoveAll(obj=>obj==null);
            GameObject[] inactiveObjects = spawnStack.Where(obj=>!obj.activeSelf).ToArray();
            if (inactiveObjects.Count() > 0)
            {
                inactiveObjects.First().SetActive(true);
                inactiveObjects.First().transform.position = transform.position+spawnOffset;
            }
            else
            {
                GameObject instantiatedElement = Instantiate(elementToSpawn);
                spawnStack.Add(instantiatedElement);
                instantiatedElement.transform.position = transform.position + spawnOffset;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
