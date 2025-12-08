using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameManager game_manager;

    Transform world_items_transform;

    void Update()
    {
        if(game_manager.GetState().getStateName() == "Pause") { return; }

        world_items_transform = GameObject.Find("Items").transform;
     }

    void AddItem(Item item) 
    {
        string item_name = item.getItemName();
        for (int i = 0; i < items.Count; i++)
        {
            int c = item_name.CompareTo(items[i].getItemName());

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

    public void RemoveItem(Item item)
    {
            Vector3 current_position = transform.position;
            Vector3 forward = transform.forward;

            Vector3 new_position = current_position + forward;
            new_position += new Vector3(0, 1, 0);

            Quaternion current_rotation = transform.rotation;
            Quaternion new_rotation = current_rotation * Quaternion.Euler(0, 0, 180);

            GameObject new_item = Instantiate(item.gameObject, new_position, new_rotation, world_items_transform);
            new_item.SetActive(true);
            new_item.name = item.getItemName();

            Item removed = item;
            items.Remove(item);

            removed.gameObject.SetActive(false);
            removed.transform.SetParent(null);

    }

    public void RemoveItem()
    {
        if (game_manager.GetState().getStateName() == "Gameplay" && items.Count > 0)
        {
            Item item = items[0];

            RemoveItem(item);
        }
    }

    public void RemoveItem(int i) 
    {
        if(i < items.Count) 
        {
            Debug.Log(items[i].name);
            RemoveItem(items[i]);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item collisionItem = hit.gameObject.GetComponent<Item>();

        if (collisionItem != null)
        {
            collisionItem.gameObject.SetActive(false);
            AddItem(collisionItem);
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }
}

