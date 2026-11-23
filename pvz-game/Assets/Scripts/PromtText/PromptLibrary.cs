using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string itemName = "zxc";
    public int itemDamage;
    public bool isConsumable;
}

public class PromptLibrary : MonoBehaviour
{
    public ItemData itemInfo;
}
