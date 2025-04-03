using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float zombieCountPerLevel;
    public Transform zombieParent;
    public static int money = 0;
    public int totalBullet;
    public int upgradeTotalBullet;
    public List<GameObject> zombies;
    private readonly List<GameObject> zombiePool = new List<GameObject>();
    public static bool gameOver;
    public float countDownTime = 180f;
    public float currentTime;
    public static int days = 1;
    public bool playSound;

    public static GameManager instance;

    void Start()
    {
        Invoke(nameof(CreateZombies), 3f);
        Time.timeScale = 1;
        currentTime = countDownTime;
    }

    void Update()
    {
        Timer();
        DayOver();
        ManageZombieCount();
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
            Time.timeScale = 0;
            UIManager.instance.youWinMenu.SetActive(true); // Kazanma men�s�n� a�
        }
    }

    void Awake()
    {
        instance = this;
        
    }

    public void CreateZombies()
    {


        for (int i = 0; i < zombieCountPerLevel; i++)
        {
            GameObject new_zombie = Instantiate(RandomZombie(), RandomPosition(), Quaternion.identity, zombieParent);
            zombiePool.Add(new_zombie);
        }
    }

    public GameObject RandomZombie()
    {

        int rnd = Random.Range(0, days);
        return zombies[rnd];
    }

    public void RespawnZombie(GameObject zombie)
    {
        zombie.transform.position = RandomPosition();
    }

    public Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-24, 14), Random.Range(-20, 6));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpgradeTotalBullet()
    {
        totalBullet += upgradeTotalBullet;
    }

    public void ManageMoney(int value)
    {
        money += value;
        PlayerPrefs.SetInt("MONEY", money);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        UIManager.instance.pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        UIManager.instance.pauseMenu.SetActive(false);
    }

    public void DayOver()
    {
        if (Character.instance.isDead && !playSound)
        {
            UIManager.instance.youLoseMenu.SetActive(true);
            AudioManager.instance.GameLoseSound();
            playSound = true;
        }
            

        if (currentTime <= 0 && !playSound)
        {
            UIManager.instance.youWinMenu.SetActive(true);
            AudioManager.instance.GameWinSound();
            playSound=true;
        }

        if (currentTime <= 0 || Character.instance.isDead)
        {
            Time.timeScale = 0;
        }
    }

    public static void NextDay()
    {
        if (days < 5 && gameOver)
        {
            days++;
            gameOver = false;
        }
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneControl.LoadScene("Game");
    }

    public void ClearZombies()
    {
        foreach (GameObject zombie in zombiePool)
        {
            Destroy(zombie);
        }
        zombiePool.Clear();
    }

    public void ManageZombieCount()
    {
        zombieCountPerLevel = days switch
        {
            1 => 20,
            2 => 30,
            3 => 40,
            4 => 50,
            _ => 60
        };
    }
}
