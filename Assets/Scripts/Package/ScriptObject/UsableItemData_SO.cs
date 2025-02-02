using UnityEngine;

[CreateAssetMenu(fileName = "Usable Item", menuName = "Data/Package/Usable Item Data")]
[System.Serializable]
public class UsableItemData_SO : ScriptableObject
{
    public int healPoint;
    public int attackPoint;
    public int defensePoint;
}
