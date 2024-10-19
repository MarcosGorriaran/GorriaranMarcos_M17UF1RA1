using UnityEngine;

public class Player : MonoBehaviour, IMove
{
    public static Player instance {get; private set;}
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    GroundDetection groundDetect;
    float height;
    bool dead = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            //Destroy(this);
        }else{
            instance = this;
        }
        
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        height = GetComponent<BoxCollider2D>().size.y / 2;
        groundDetect.transform.localPosition = new Vector3(0, -height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Animator>().ResetTrigger("RunTrigger");
        if(!dead){
            Movement();
        }
        
    }
    public void Movement()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = false;

            transform.GetComponent<Animator>().SetTrigger("RunTrigger");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
            transform.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetComponent<Animator>().SetTrigger("RunTrigger");
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && groundDetect.onGround)
        {
            transform.GetComponent<Rigidbody2D>().gravityScale *= -1;
            bool flipValue = transform.GetComponent<SpriteRenderer>().flipY;
            transform.GetComponent<SpriteRenderer>().flipY = flipValue ? false : true;
            groundDetect.transform.localPosition = new Vector3(0, flipValue ? -height : height, 0);
        }
    }
    public void Kill()
    {
        dead = true;
        transform.GetComponent<Animator>().SetTrigger("Dead");
    }
}