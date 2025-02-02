using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data/Character Data")]
[System.Serializable]
public class CharacterData_SO : ScriptableObject
{
    [Header("States Info")]
    public string characterName;
    public int maxHealth;
    public int currentHealth;
    public int baseDefence;
    public int currentDefence;

    [Header("Kill")]
    public int killPoint;

    [Header("Level")]
    public int currentLevel;
    public int maxLevel;
    public int baseExp;
    public int currentExp;
    public float levelBuff;
    public float LevelMultiplier
    {
        get
        {
            return 1 + ((currentLevel - 1) * levelBuff);
        }
    }
    public void UpdateExp(int point)
    {
        currentExp += point;
        if (currentExp >= baseExp)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel = Mathf.Clamp(currentLevel + 1, 0, maxLevel);
            baseExp += (int)(baseExp * LevelMultiplier);
            maxHealth = (int)(maxHealth * LevelMultiplier);
            currentHealth = maxHealth;
            baseDefence += 2;
            currentDefence += 2;
            GameManager.Instance.playerStates.attackData.LevelUp();
            GameManager.Instance.playerStates.baseAttackData.LevelUp();
            Debug.Log("LEVEL UP!Level:" + currentLevel);
        }
    }
}
