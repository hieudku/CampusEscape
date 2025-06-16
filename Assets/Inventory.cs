using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    private static HashSet<string> items = new HashSet<string>();

    public static void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log("Item added: " + itemName);
    }

    public static bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
