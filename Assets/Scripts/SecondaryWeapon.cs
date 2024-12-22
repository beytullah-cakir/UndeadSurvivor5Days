using UnityEngine;

public class SecondaryWeapon : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 10;


    public static SecondaryWeapon instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
