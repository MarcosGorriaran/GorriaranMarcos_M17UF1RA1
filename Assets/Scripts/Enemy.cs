using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : MonoBehaviour, IMove
{
    [SerializeField]
    float xDirection;
    [SerializeField]
    float detectionRange;
    [SerializeField]
    float speed;
    Vector2 castPosition;
    const int ColliderLayer = 3;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        castPosition = transform.position;
        float gravityDirection = NormalizeGravityDirection(GetComponent<Rigidbody2D>().gravityScale);
        SpriteYOrientation(gravityDirection);
        SpriteXOrientation(xDirection);
        try
        {
            Debug.DrawRay(castPosition, new Vector2(xDirection, 0), Color.red);
            Ray2D ray = new Ray2D(castPosition, new Vector2(xDirection, 0));
            RaycastHit2D[] straightRay = Physics2D.RaycastAll(castPosition, new Vector2(xDirection, 0), detectionRange);

            if (straightRay.Count()!=0 && straightRay.Where(col=>col.collider.gameObject.layer==ColliderLayer).Count()>0)
            {
                xDirection *= -1;
            }
        }
        catch (NullReferenceException)
        {

        }
        
        Movement();
    }

    void SpriteYOrientation(float gravityDirection)
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        if(gravityDirection > 0)
        {
            sprite.flipY = true;
        }else if(gravityDirection < 0)
        {
            sprite.flipY = false;
        }
    }
    void SpriteXOrientation(float xDirection)
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        if(xDirection > 0)
        {
            sprite.flipX = false;
        }else if(xDirection < 0)
        {
            sprite.flipX = true;
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
    public void Movement()
    {
        transform.position += new Vector3(xDirection*speed,0)*Time.deltaTime;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player killTarget))
        {
            killTarget.Kill();
        }
    }
}
