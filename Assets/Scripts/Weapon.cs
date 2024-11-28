using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public bool isReload;
    public float
        reloadTime,
        magazineCount,
        currentBulletCount,
        upgradeMagazine;
    public Image reloadCircle;
    public GameObject bullet;
    private Transform firePoint;
    public static Weapon instance;
    private GameManager _gameManager;

    private void Awake()
    {
        instance = this;
        
    }


    private void Update()
    {
        if ((currentBulletCount <= 0 || (Input.GetKeyDown(KeyCode.R) && currentBulletCount < magazineCount)) && BulletIsOver())
            StartCoroutine(Reload());
        else
            StopAllCoroutines();




    }

    private void Start()
    {
        currentBulletCount = magazineCount;
        firePoint=transform.GetChild(0);
        _gameManager = GameManager.instance;
    }

    public void Fire()
    {
        GameObject _bullet=Instantiate(bullet,firePoint.position,firePoint.rotation);
        _bullet.GetComponent<Bullet>().SetTargetPosition(Character.instance.MousePosition());
        currentBulletCount--;
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
        
        if (_gameManager.totalBullet > magazineCount)
        {
            _gameManager.totalBullet -= magazineCount;
            currentBulletCount = magazineCount;
        }
        else
        {
            currentBulletCount = _gameManager.totalBullet;
            _gameManager.totalBullet = 0f;
        }
       
        
    }


    public bool BulletIsOver()
    {
        return _gameManager.totalBullet + currentBulletCount > 0;
    }


    

    public void UpgradeMagazine()
    {
        magazineCount += upgradeMagazine;
    }
















}
