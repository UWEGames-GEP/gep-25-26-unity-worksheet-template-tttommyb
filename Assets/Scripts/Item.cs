using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]  string item_name;

    public string getItemName()
    {
        return item_name;
    }
}
