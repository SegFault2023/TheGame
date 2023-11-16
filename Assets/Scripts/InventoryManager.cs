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



    // Start is called before the first frame update
    void Start()
    {

    }

    private void KeyCheck(KeyCode key)
    {

        SelectSlot(key);
        shaderSelectedTime = Time.time;
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
            KeyCheck(KeyCode.N);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            KeyCheck(KeyCode.M);
        }

        if (isAnItemSelected && Time.time >= shaderSelectedTime + 4)
        {
            DeselectAllSlots();
        }
    }

    public Boolean AddItem(string itemName, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemSprite);
                return true;
            }
        }

        return false;
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
        Boolean flag = false;
        

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
                flag = true;

                Debug.Log(i);
                Debug.Log(indexToBeSelected);
                break;
            }

        }

        if(!flag)
        {
            itemSlot[0].selectedShader.SetActive(true);
            itemSlot[0].thisItemSelected = true;
            isAnItemSelected = true;
        }
     

    }


}