using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : MonoBehaviour, IMove
{
    [SerializeField]
    bool avoidHazards;
    [SerializeField]
    bool avoidFalls;
    [SerializeField]
    float xDirection;
    [SerializeField]
    float detectionRange;
    [SerializeField]
    float speed;
    Vector2 castPosition;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        castPosition = transform.GetChild(0).transform.position;
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
        try
        {
            Debug.DrawRay(castPosition, new Vector2(xDirection, 0), Color.red);
            Ray2D ray = new Ray2D(castPosition, new Vector2(xDirection, 0));
            RaycastHit2D straightRay = Physics2D.Raycast(castPosition, new Vector2(xDirection, 0), detectionRange);
            
            if (straightRay.collider.gameObject.TryGetComponent(out BoxCollider2D collider))
            {
                if (!collider.isTrigger)
                {
                    xDirection *= -1;
                }

            }
        }
        catch (NullReferenceException)
        {

        }
        
        //Movement();
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
    public void Movement()
    {
        transform.position += new Vector3(xDirection*speed,0)*Time.deltaTime;
    }
}
