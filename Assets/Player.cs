using UnityEngine;

public class Player : MonoBehaviour
{
    const float DefaultSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Animator>().ResetTrigger("RunTrigger");
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(DefaultSpeed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;

            transform.GetComponent<Animator>().SetTrigger("RunTrigger");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-DefaultSpeed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetComponent<Animator>().SetTrigger("RunTrigger");
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.GetComponent<Rigidbody2D>().gravityScale *= -1;
            bool flipValue = transform.GetComponent<SpriteRenderer>().flipY;
            transform.GetComponent<SpriteRenderer>().flipY = flipValue ? false : true;
        }
    }
}
