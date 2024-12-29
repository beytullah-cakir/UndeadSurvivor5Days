using TMPro;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public int increaseDamage = 10;
    public int moneyIncrase = 150;
    public TextMeshProUGUI money;
    GameManager gameManager;
    public TextMeshProUGUI weaponUpgrade, itemUpgrade, weaponDamage, itemDamage,itemBuy;
    public static int upgradeWeaponMoney=160, upgradeItemMoney=160, buyItemMoney=100;
    public static bool isBuyedItem;
    


    private void Awake()
    {
        gameManager = new GameManager();
    }

    void Start()
    {
    }


    void Update()
    {
        
        //money.text = "$" + $"{GameManager.instance.money}";
        weaponDamage.text = $"Damage: {Weapon.damage}";
        weaponUpgrade.text = $"Upgrade ${upgradeWeaponMoney}";

        itemUpgrade.text = $"Upgrade ${upgradeItemMoney}";
        itemDamage.text = $"Damage: {SecondaryWeapon.damage}";
        itemBuy.text = $"{buyItemMoney}";
        money.text = "$" + $"{GameManager.money}";

    }


    public void UpgradeWeapon()
    {
        if (GameManager.money >= upgradeWeaponMoney)
        {
            Weapon.damage += increaseDamage;
            gameManager.ManageMoney(-upgradeWeaponMoney);
            PlayerPrefs.SetInt("WEAPONDAMAGE", Weapon.damage);
            upgradeWeaponMoney += moneyIncrase;
            PlayerPrefs.SetInt("UPGRADEWEAPONMONEY", upgradeWeaponMoney);
        }
        else print("not");
        
        
    }

    public void UpgradeItem()
    {
        if (GameManager.money >= upgradeItemMoney)
        {
            SecondaryWeapon.damage += increaseDamage;
            gameManager.ManageMoney(-upgradeItemMoney);
            PlayerPrefs.SetInt("SECONDARYWEAPONDAMAGE", SecondaryWeapon.damage);
            upgradeItemMoney += moneyIncrase;
            PlayerPrefs.SetInt("UPGRADEITEMMONEY", upgradeItemMoney);
        }
        else print("not");


    }

    public void BuyItem()
    {
        if (GameManager.money >= buyItemMoney)
        {
            gameManager.ManageMoney(-buyItemMoney);
            isBuyedItem = true;
        }
            
        else
        {
            Debug.Log("Yeterli paranýz yok!");
        }
    }
}

