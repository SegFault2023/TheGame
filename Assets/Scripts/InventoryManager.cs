using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    private Boolean isAnItemSelected = false;
    private float shaderSelectedTime;

    public Boolean compareTrashBinTags(String binTag, int index)
    {
        if (itemSlot[index].getItemImageTag() == binTag) { return true; }
        return false;
    }


    public int getSelectedIndex() 
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemSelected) return i;
        }
        return -1;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }


        if (Input.GetKeyDown(KeyCode.N))
        {
            SelectSlot(KeyCode.N);
            shaderSelectedTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SelectSlot(KeyCode.M);
            shaderSelectedTime = Time.time;
        }

        if (isAnItemSelected && Time.time >= shaderSelectedTime + 4)
        {
            DeselectAllSlots();
        }
    }

    public Boolean AddItem(string itemName, Sprite itemSprite, String itemTag)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemSprite, itemTag);
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(int index)
    {

        itemSlot[index].RemoveItem();
    }

    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
            isAnItemSelected = false;
        }
    }

    public void SelectSlot(KeyCode key)
    {
        int indexToBeSelected = 0;
        
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemSelected)
            {

                itemSlot[i].selectedShader.SetActive(false);
                itemSlot[i].thisItemSelected = false;

                if (key == KeyCode.N)
                {
                    if (i == 0)
                    {
                        indexToBeSelected = itemSlot.Length - 1;
                    }

                    else
                    {
                        indexToBeSelected = i - 1;
                    }
                }

                else if (key == KeyCode.M)
                {
                    if (i == itemSlot.Length - 1)
                    {
                        indexToBeSelected = 0;
                    }

                    else
                    {
                        indexToBeSelected = i + 1;
                    }
                }

                itemSlot[indexToBeSelected].selectedShader.SetActive(true);
                itemSlot[indexToBeSelected].thisItemSelected = true;


                return;
            }

        }

       
        itemSlot[0].selectedShader.SetActive(true);
        itemSlot[0].thisItemSelected = true;
        isAnItemSelected = true;
        
    }

}