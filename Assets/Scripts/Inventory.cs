using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<string> items = new List<string>();
    [SerializeField] private List<int[]> tree_pointers = new List<int[]>(); // Stores Left and Right Pointers
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
        items.Add(item);
        int index = items.Count - 1;
        for(int i = 0; i < items.Count;)
        {
            if (item.CompareTo(items[i]) <= 0)
            {
                if (tree_pointers[i][0] == 0) 
                {
                    tree_pointers[i][0] = index;
                    tree_pointers.Add(new int[2]);
                    return;
                }
                i = tree_pointers[i][0];
                continue;
            }
            if (item.CompareTo(items[i]) > 0)
            {
                if (tree_pointers[i][1] == 0)
                {
                    tree_pointers[i][1] = index;
                    tree_pointers.Add(new int[2]);
                    return;
                }
                i = tree_pointers[i][1];
                continue;

            }
        }
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
            items.Add(collisionItem.itemName);
            Destroy(collisionItem.gameObject);
        }
    }

}

