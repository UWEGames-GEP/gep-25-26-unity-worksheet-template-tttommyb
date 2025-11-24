using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<string> items = new List<string>();
    [SerializeField] private GameManager game_manager;

    void Update()
    {
        if(game_manager.getState().getStateName() == "Pause") { return; }

         if (Input.GetKeyDown(KeyCode.DownArrow))
         {
                removeItem("orb");
         }
     }

    void addItem(string item) 
    {
        for (int i = 0; i < items.Count; i++)
        {
            int c = item.CompareTo(items[i]);

            if (c < 0)            
            {
                items.Insert(i, item);
                return;
            }
            else if (c == 0)
            {
                Debug.Log("EQUAL");
                
            }
        }
        items.Add(item);

    }

    void removeItem(string item)
    {
        items.Remove(item);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item collisionItem = hit.gameObject.GetComponent<Item>();

        if (collisionItem != null)
        {
            addItem(collisionItem.itemName);
            Destroy(collisionItem.gameObject);
        }
    }

}

