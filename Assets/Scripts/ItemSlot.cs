using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ItemSlot : MonoBehaviour
{
    //=====ITEM DATA=====//
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;


    //====ITEM SLOT====//
    public GameObject selectedShader;
    public bool thisItemSelected;
    
   

    [SerializeField]
    private Image itemImage;

  

    public void AddItem(string itemName, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;
    
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }


}