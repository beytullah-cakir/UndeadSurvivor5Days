
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> randomItems;
    public GameObject money;


    public static ItemManager instance;

    private Camera mainCamera;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        
    }

    public GameObject RandomItems()
    {
        int index=Random.Range(0, randomItems.Count);
        return randomItems[index];
    }
}
