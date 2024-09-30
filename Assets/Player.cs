using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Animator idle;
    [SerializeField]
    Animator move;
    const float DefaultSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(DefaultSpeed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-DefaultSpeed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.GetComponent<Rigidbody2D>().gravityScale *= -1;
            bool flipValue = transform.GetComponent<SpriteRenderer>().flipY;
            transform.GetComponent<SpriteRenderer>().flipY = flipValue ? false : true;
        }
    }
}
