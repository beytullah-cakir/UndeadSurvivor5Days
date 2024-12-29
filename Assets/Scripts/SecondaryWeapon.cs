using UnityEngine;

public class SecondaryWeapon : MonoBehaviour
{
    public float speed = 5f;
    public static int damage = 10;


    public static SecondaryWeapon instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
