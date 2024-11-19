using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int magazineCount;
    public int currentbulletCount;
    public int totalBullet;
    public bool isReload;
    public float reloadTime;
    public Image reloadCircle;







    public static Weapon instance;

    private void Awake()
    {
        instance = this;
        
    }


    private void Update()
    {
        if (currentbulletCount <= 0 && BulletIsOver())
            StartCoroutine(Reload());
        else
            StopAllCoroutines();

       
        
        
    }






    private void Start()
    {
        currentbulletCount= magazineCount;
        
    }

    public void Fire()
    {
        currentbulletCount--;
    }


    IEnumerator Reload()
    {
        isReload = true;
        float elapsedTime = 0f;
        while (elapsedTime < reloadTime)
        {
            elapsedTime += Time.deltaTime;
            reloadCircle.fillAmount = elapsedTime / reloadTime;
            yield return null;
        }
        reloadCircle.fillAmount = 0f;
        isReload = false;
        totalBullet -= magazineCount;
        if(totalBullet<=0)
            totalBullet = 0;
        currentbulletCount = magazineCount;
    }


    public bool BulletIsOver()
    {
        return totalBullet+currentbulletCount > 0;
    }

   










}
