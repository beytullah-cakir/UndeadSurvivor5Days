using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentBulletTxt,totalBulletTxt,timerTxt,totalMoneyTxt;
    public TextMeshProUGUI finish_text;
    public GameObject finishMenu,pauseMenu;

    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        currentBulletTxt.text = $"{Weapon.instance.currentBulletCount} / {Weapon.instance.magazineCount}";
        totalBulletTxt.text = GameManager.instance.totalBullet.ToString();
        timerTxt.text= $"{Mathf.Ceil(GameManager.instance.currentTime)}";
        totalMoneyTxt.text = $"{GameManager.instance.money}";

        finish_text.text = GameManager.instance.gameOver ? "YOU WIN" : "YOU LOSE";
        ActiveFinishMenu();
    }


    public void ActiveFinishMenu()
    {
        if(Character.instance.isDead)
            finishMenu.SetActive(true);
    }

}
