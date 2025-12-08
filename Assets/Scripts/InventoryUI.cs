using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private List<GameObject> inventory_ui_buttons = new List<GameObject>();
    [SerializeField] private GameObject default_button;
    [SerializeField] private GameObject button_parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        RefreshInventory();
    }

    // Update is called once per frame
    void RefreshInventory()
    {
        //Debug.Log("Refresh Inventory UI");

        foreach(GameObject button in inventory_ui_buttons)
        {
           Destroy(button.gameObject);
        }
        inventory_ui_buttons.Clear();

        for (int i = 0; i < inventory.GetItems().Count; i++)
        {
            inventory_ui_buttons.Add(Instantiate(default_button, button_parent.transform));
            InventoryUIButton ui_button = inventory_ui_buttons[i].GetComponent<InventoryUIButton>();

            int index = i;
            ui_button.gameObject.GetComponent<Button>().onClick.AddListener(() => OnInventoryUIButton(index));

            ui_button.gameObject.SetActive(true);
            ui_button.SetButton(inventory.GetItems()[i]);
        }

        for(int j = 0; j < inventory_ui_buttons.Count; j++)
        {
            //Debug.Log("Button: " + inventory_ui_buttons[j].GetComponent<InventoryUIButton>().getText() + " Item: " + inventory.GetItems()[j].name + " INDEX: " + j);
        }
        
    }

    public void OnInventoryUIButton(int i) 
    {
        Debug.Log("REMOVEING  " + i);
        inventory.RemoveItem(i);
        RefreshInventory();
    }
}
