using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public float zombieCountPerLevel;
    public Transform zombieParent;
    public int money;
    public int totalBullet;
    public int upgradeTotalBullet;
    public GameObject zombie;
    private readonly List<GameObject> zombiePool = new List<GameObject>();
    public bool gameOver;
    public float countDownTime = 180f;
    public float currentTime;

    public static GameManager instance;

    void Start()
    {
        currentTime = countDownTime;
        
    }




    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            gameOver = true;
            AudioManager.instance.GameWinSound();
        }
    }


    void Awake()
    {
        instance = this;

        CreateZombies();
    }


    public void CreateZombies()
    {


        for (int i = 0; i < zombieCountPerLevel; i++)
        {
            GameObject new_zombie = Instantiate(zombie, RandomPosition(), Quaternion.identity, zombieParent);
            zombiePool.Add(new_zombie);
        }

    }

    
    public void RespawnZombie(GameObject zombie)
    {
        zombie.transform.position = RandomPosition();
    }


    //Düþman doðuþ pozisyonunu ayarlamak için yazýldý
    public Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-24, 14), Random.Range(-20, 6));
    }

    //Oyundan çýkmak için yazýldý
    public void QuitGame()
    {
        Application.Quit();
    }


    //Toplam mermi sayýsýný arttýrmak için yazýldý
    public void UpgradeTotalBullet()
    {
        totalBullet += upgradeTotalBullet;
        
    }


    //Para yönetimi için yazýldý
    public void ManageMoney(int value)
    {
        money += value;
        PlayerPrefs.SetInt("MONEY",money);
    }


    //Oyunu durdurunca PauseMenu açýlmasý için yazýldý
    public void PauseMenu()
    {
        Time.timeScale = 0;
        UIManager.instance.pauseMenu.SetActive(true);
    }

    //Oyuna devam etmek için yazýldý
    public void ResumeGame()
    {
        Time.timeScale = 1;
        UIManager.instance.pauseMenu.SetActive(false);
    }

    

    

}
