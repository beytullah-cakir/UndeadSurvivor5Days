using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bullet;
    public int bulletCount;
    private List<GameObject> bullets;
    public Transform bulletParent;

    public static ObjectPool instance;

    private void Awake()
    {
        instance = this;
        bullets = new List<GameObject>();
    }

    private void CreateBullet()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject new_bullet = Instantiate(bullet, bulletParent);
            new_bullet.SetActive(false);
            bullets.Add(new_bullet);
        }
    }

    void Start()
    {
        CreateBullet();
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
