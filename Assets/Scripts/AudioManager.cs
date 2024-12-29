using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource weapon, enemyHit, playerHit, gameWin, gameLose,background,button;






    public static AudioManager instance;


    private void Awake()
    {
        instance = this;
    }
   
    public void WeaponSound()
    {
        weapon.Play();
    }

    public void EnemyHitSound()
    {
        enemyHit.Play();
    }

    public void PlayerHitSound()
    {
        playerHit.Play();
    }

    public void GameWinSound()
    {
        background.volume = 0;
        gameWin.Play();
    }

    public void GameLoseSound()
    {
        background.volume = 0;
        gameLose.Play();
    }


    public void ButtonSound()
    {
        button.Play();
    }



}
