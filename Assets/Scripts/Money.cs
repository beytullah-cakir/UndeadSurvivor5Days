using UnityEngine;

public class Money : MonoBehaviour
{
    private Transform _player;
    public float moveSpeed = 5f;       
    

       

    void Start()
    {
        _player=GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, _player.position) < 0.1f)
        {
            Destroy(gameObject);
            GameManager.instance.money++;
        }
    }
}
