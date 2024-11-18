using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Vector3 direction;
    private void Update()
    {
        transform.position += (direction.normalized*speed)*Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IKillable killable))
        {
            killable.Kill();
        }
            gameObject.SetActive(false);
    }
}
