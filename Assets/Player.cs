using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    [SerializeField]
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Animator>().ResetTrigger("RunTrigger");
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;

            transform.GetComponent<Animator>().SetTrigger("RunTrigger");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
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
