using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentBulletTxt,totalBulletTxt;
    void Start()
    {
        
    }

    
    void Update()
    {
        currentBulletTxt.text = Weapon.instance.currentbulletCount + "/" + Weapon.instance.magazineCount;
        totalBulletTxt.text = Weapon.instance.totalBullet.ToString();
    }
}
