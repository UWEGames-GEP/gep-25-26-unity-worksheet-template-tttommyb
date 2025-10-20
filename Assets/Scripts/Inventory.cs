using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<string> items = new List<string>();
    [SerializeField] private GameManager game_manager;

    void Update()
    {
        if(game_manager.getState() == 1) { return; }
      if(Input.GetKeyDown(KeyCode.UpArrow))
      {
            addItem("Sword");
      }
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
            removeItem("Sword");
      }
    }

    void addItem(string item) 
    {
        items.Add(item);
    }

    void removeItem(string item)
    {
        items.Remove(item);
    }
}
