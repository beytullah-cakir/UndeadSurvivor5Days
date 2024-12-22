using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public bool isReload;
    public int damage;
    public int magazineCount, upgradeMagazine;
    public float reloadTime, currentBulletCount;
    public Image reloadCircle;
    private Transform firePoint;
    public float weaponCost;
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
        GameObject _bullet = ObjectPool.instance.GetBullet();
        if (_bullet != null)
        {
            _bullet.transform.position = firePoint.position;
            _bullet.transform.rotation = firePoint.rotation;
            _bullet.SetActive(true);
            _bullet.GetComponent<Bullet>().SetTargetPosition(Character.instance.MousePosition());
            currentBulletCount--;
        }
       
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
            _gameManager.totalBullet = 0;
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
