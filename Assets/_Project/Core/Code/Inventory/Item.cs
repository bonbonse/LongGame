using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string Name = string.Empty;
    public string Description = string.Empty;
    public string Type = string.Empty;
    public Sprite Icon = null;
    public int Count = 0;
    public int MaxCount = 10;
}
