using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory _instence;
    private int coinCount = 1000;
    public List<InventoryItem> itemList = new List<InventoryItem>();
    public Text coinText;
    void Awake()
    {
        _instence = this;
    }

    private void Start()
    {
        coinText = GameObject.Find("coin/cointext").GetComponent<Text>();
        coinText.text = coinCount.ToString();
    }

    public void  ShowInventory()
    {
        
    }

    public void HideInventory()
    {
        
    }
}
