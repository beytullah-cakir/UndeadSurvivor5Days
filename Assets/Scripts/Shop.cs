using TMPro;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public int increaseDamage = 10;
    public int moneyIncrase = 150;
    public TextMeshProUGUI money;
    Weapon weapon;
    SecondaryWeapon secondaryWeapon;
    public TextMeshProUGUI weaponUpgrade, itemUpgrade, weaponDamage, itemDamage,itemBuy;
    public int upgradeWeaponMoney, upgradeItemMoney, buyItemMoney;


    private void Awake()
    {
        weapon = new Weapon();
        secondaryWeapon = new SecondaryWeapon();
    }

    void Start()
    {
    }


    void Update()
    {
        money.text = "$" + $"{PlayerPrefs.GetInt("MONEY")}";

        weaponDamage.text = $"Damage: {weapon.damage}";
        weaponUpgrade.text = $"Upgrade ${upgradeWeaponMoney}";

        itemUpgrade.text = $"Upgrade ${upgradeItemMoney}";
        itemDamage.text = $"Damage: {secondaryWeapon.damage}";
        itemBuy.text = $"{buyItemMoney}";

    }


    public void UpgradeWeapon()
    {
        weapon.damage += increaseDamage;
        PlayerPrefs.SetInt("WEAPONDAMAGE", weapon.damage);
        upgradeWeaponMoney += moneyIncrase;
        PlayerPrefs.SetInt("UPGRADEWEAPONMONEY", upgradeWeaponMoney);
    }

    public void UpgradeItem()
    {
        secondaryWeapon.damage += increaseDamage;
        PlayerPrefs.SetInt("SECONDARYWEAPONDAMAGE", secondaryWeapon.damage);
        upgradeItemMoney += moneyIncrase;
        PlayerPrefs.SetInt("UPGRADEITEMMONEY", upgradeItemMoney);
    }

    public void BuyItem()
    {
        if (GameManager.instance.money >= buyItemMoney)
            GameManager.instance.ManageMoney(-buyItemMoney);
        else
        {
            Debug.Log("Yeterli paranýz yok!");
        }
    }
}

