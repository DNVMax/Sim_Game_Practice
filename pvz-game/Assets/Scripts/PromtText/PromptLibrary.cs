using UnityEngine;

// Обязательно пишем эту строчку перед классом или структурой
[System.Serializable]
public class ItemData
{
    public string itemName = "Penis";
    public int itemDamage;
    public bool isConsumable;
}

public class PromptLibrary : MonoBehaviour
{
    // Благодаря [System.Serializable] этот класс появится в инспекторе Unity!
    public ItemData itemInfo;
}