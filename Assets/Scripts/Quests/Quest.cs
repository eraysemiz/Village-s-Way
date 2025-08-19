using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    [TextArea] public string description;

    public enum RequirementType { ChickenMeat, BullMeat, Tomato, Wheat }
    public RequirementType requirement;
    public int requiredAmount;

    public int goldReward;

    [HideInInspector] public int currentAmount;
    [HideInInspector] public bool isCompleted = false;

    public void ResetProgress()
    {
        currentAmount = 0;
        isCompleted = false;
    }

    public void AddProgress(int amount)
    {
        if (isCompleted) return;

        currentAmount += amount;
        if (currentAmount >= requiredAmount)
        {
            currentAmount = requiredAmount;
            isCompleted = true;
            Debug.Log("Görev tamamlandý: " + questName);
        }
    }
}
