using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentBulletTxt,totalBulletTxt,timerTxt,totalMoneyTxt,dayTxt;
    public TextMeshProUGUI finish_text;
    public GameObject youWinMenu,pauseMenu,youLoseMenu;
    

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
        totalMoneyTxt.text = $"{GameManager.money}";

        finish_text.text = GameManager.gameOver ? "YOU WIN" : "YOU LOSE";
        dayTxt.text = $"DAY {GameManager.days}";
       
    }
}
