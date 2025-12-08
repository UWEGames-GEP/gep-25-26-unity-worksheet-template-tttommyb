using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    public void SetButton(Item item)
    {
        text.text = item.name;
    }

    public string getText()
    {
        return text.text;
    }
}
