using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float zombieCountPerLevel;
    public GameObject zombie;
    public Transform zombieParent;
    public Light2D globalLight;
    private GameObject[] entityLigth;
    public float gameStartHour;
    public float gameEndHour;
    public float gameDurationInSeconds;
    public int hours, minutes;
    public float currentTime;
    public float money;
    private Button _quitButton;
    public float totalBullet;
    public float upgradeTotalBullet;
    public List<GameObject> enemys;

    public static GameManager instance;

    void Start()
    {
        currentTime = gameStartHour;
    }


    void ManageLigth(bool open)
    {
        entityLigth = GameObject.FindGameObjectsWithTag("EntityLigth");
        foreach (var entity in entityLigth)
        {
            Light2D light = entity.GetComponent<Light2D>();
            light.enabled = open;
        }
    }
    void AdjustLighting()
    {

        if (currentTime < 18f)
        {
            ManageLigth(false);
            globalLight.intensity = Mathf.Lerp(1.0f, 0.6f, (currentTime - gameStartHour) / 6f);
        }
        else
        {
            ManageLigth(true);
            globalLight.intensity = Mathf.Lerp(0.6f, 0.2f, (currentTime - 18f) / 6f);
        }
    }

    void Update()
    {
        float gameTimePerSecond = (gameEndHour - gameStartHour) / gameDurationInSeconds;
        currentTime += gameTimePerSecond * Time.deltaTime;


        hours = Mathf.FloorToInt(currentTime);
        minutes = Mathf.FloorToInt((currentTime - hours) * 60f);


        if (currentTime >= gameEndHour)
        {
            Time.timeScale = 0;
        }
        AdjustLighting();

        if (zombieParent.childCount < zombieCountPerLevel)
            SpawnZombie();

        

    }


    void Awake()
    {
        instance = this;
        for (int i = 0; i < zombieCountPerLevel; i++)
            SpawnZombie();
    }


    public void SpawnZombie()
    {
        int enemyIndex = Random.Range(0, enemys.Count);
        GameObject newZombie=Instantiate(enemys[enemyIndex],RandomPosition(),Quaternion.identity);
        newZombie.transform.parent = zombieParent;
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

}
