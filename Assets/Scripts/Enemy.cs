using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    bool avoidHazards;
    [SerializeField]
    bool avoidFalls;
    [SerializeField]
    float xDirection;
    [SerializeField]
    float detectionRange;
    Vector2 castPosition;
    // Start is called before the first frame update
    void Start()
    {
        castPosition = transform.GetChild(0).transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float gravityDirection = NormalizeGravityDirection(GetComponent<Rigidbody2D>().gravityScale);
        RaycastHit2D rayToGround = Physics2D.Raycast(castPosition,new Vector2(xDirection,gravityDirection),detectionRange);
        if (avoidHazards)
        {
            if(rayToGround.collider.gameObject.TryGetComponent<HazardTerrain>(out _))
            {
                xDirection *= -1;
            }
        }
        if (avoidFalls)
        {
            if(rayToGround.collider.gameObject == null)
            {
                xDirection *= -1;
            }
        }
        RaycastHit2D straightRay = Physics2D.Raycast(castPosition, new Vector2(xDirection, 0), detectionRange);
        if(straightRay.collider.gameObject.TryGetComponent(out BoxCollider2D collider) && !collider.isTrigger)
        {
            xDirection *= -1;
        }
    }

    float NormalizeGravityDirection(float gravityValue)
    {
        if (gravityValue > 0)
        {
            return -1;
        }else if(gravityValue < 0)
        {
            return 1;
        }
        return 0;
    }
}
