using UnityEngine;

public class TriggerChangeScene : ChangeScene
{
    [SerializeField]
    Vector2 playerStart;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out _))
        {
            
            if(!deleteAllInstances)
            {
                collision.transform.position = playerStart;
            }

            LoadScene();
        }
        
    }
}
