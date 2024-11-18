using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTerrain : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IKillable killTarget))
        {
            killTarget.Kill();
        }
    }
}
