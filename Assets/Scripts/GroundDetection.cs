using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool onGround = false;
    const int colisionLayerID = 3;
    private void OnTriggerStay2D(Collider2D colisionObject)
    {
        if (colisionObject.gameObject.layer == colisionLayerID)
        {
            onGround = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D colisionObject)
    {
        if (colisionObject.gameObject.layer == colisionLayerID)
        {
            onGround = false;
        }
    }
}
