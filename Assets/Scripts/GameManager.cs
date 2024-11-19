using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float zombieCountPerLevel;// yde -20 6 xde -24 14
    public GameObject zombie;
    public Transform zombieParent;


    public static GameManager instance;


    void Awake()
    {
        instance = this;
        for (int i = 0; i < zombieCountPerLevel; i++)
            SpawnZombie();
    }


    public void SpawnZombie()
    {
        Instantiate(zombie, zombieParent);
        zombie.transform.position = RandomPosition();
    }


    public Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-24, 14), Random.Range(-20, 6));
    }
}
