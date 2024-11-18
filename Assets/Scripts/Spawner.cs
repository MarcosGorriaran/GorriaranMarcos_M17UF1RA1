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
    List<GameObject> spawnStack;
    [SerializeField]
    float timeBeforeFirstSpawn;
    [SerializeField]
    float spawnTime;

    private void Start()
    {
        spawnStack = new List<GameObject>();
        StartCoroutine(SpawnRoutine());
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
    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        while (true)
        {
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
