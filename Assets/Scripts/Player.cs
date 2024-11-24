using UnityEngine;

public class Player : MonoBehaviour, IMove, IKillable
{
    public static Player instance {get; private set;}
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    GroundDetection groundDetect;
    [SerializeField]
    AudioSource shiftGravitySound;
    float height;
    bool dead = false;
    public bool inputDisabled = false;
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
    public bool IsPlayerDead()
    {
        return dead;
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
        if(!dead && !inputDisabled){
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
            shiftGravitySound.Play();
        }
    }
    public void Kill()
    {
        dead = true;
        transform.GetComponent<Animator>().SetTrigger("Dead");
        Rigidbody2D col = GetComponent<Rigidbody2D>();
        col.excludeLayers = 2;
        GameOver.instance.ShowScreen();
    }
}