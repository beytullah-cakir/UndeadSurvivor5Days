using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float increaseDamage = 10;
    public TextMeshProUGUI money;
    public Cards[] cards;
    Weapon weapon;


    private void Awake()
    {
        weapon = new Weapon();
    }

    void Start()
    {
        foreach (var card in cards)
        {
            card.damage=weapon.damage;
            card.buy.onClick.AddListener(() =>BuyItem(card));
            card.upgrade.onClick.AddListener(() => UpgradeWeapon(card));
        }
    }


    void Update()
    {
        money.text = "$"+$"{PlayerPrefs.GetInt("MONEY").ToString()}";
    }


    public void UpgradeWeapon(Cards card)
    {
        card.damage += increaseDamage;
        Weapon.instance.damage += card.damage;
        
    }

    public void BuyItem(Cards card)
    {
        if (GameManager.instance.money >= card.cost)
        {
            GameManager.instance.ManageMoney(-card.cost);
            card.buy.gameObject.SetActive(false);
            card.upgrade.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Yeterli paranýz yok!");
        }
    }
}
[System.Serializable]
public class Cards
{
    public string name;
    public Button buy;
    public Button upgrade;
    public float damage;
    public int cost;

}
