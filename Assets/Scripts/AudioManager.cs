using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource weapon, enemyHit, playerHit, gameWin, gameLose, meleeCombat;






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
        gameWin.Play();
    }

    public void GameLoseSound()
    {
        gameLose.Play();
    }

    public void MeleeCombatSound()
    {
        meleeCombat.Play();
    }


}
