using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentBulletTxt,totalBulletTxt,cycleTimeTxt,totalMoneyTxt;
    void Start()
    {
        
    }

    
    void Update()
    {
        currentBulletTxt.text = $"{Weapon.instance.currentBulletCount} / {Weapon.instance.magazineCount}";
        totalBulletTxt.text = GameManager.instance.totalBullet.ToString();
        cycleTimeTxt.text = $"{GameManager.instance.hours:00}:{GameManager.instance.minutes:00}";
        totalMoneyTxt.text=GameManager.instance.money.ToString();
    }
}
