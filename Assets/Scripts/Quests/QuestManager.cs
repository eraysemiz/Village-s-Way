using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public Quest activeQuest;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public bool HasActiveQuest() => activeQuest != null && !activeQuest.isCompleted;

    public void AcceptQuest(Quest quest)
    {
        if (!HasActiveQuest())
        {
            activeQuest = quest;
            activeQuest.currentAmount = 0;
            activeQuest.isCompleted = false;
            Debug.Log("Yeni görev alındı: " + quest.questName);
        }
        else
        {
            Debug.Log("Önce mevcut görevi tamamlamalısın!");
        }
    }

    // PlayerInventory’den çağrılacak
    public void OnItemCollected(Quest.RequirementType type, int amount)
    {
        if (activeQuest != null && !activeQuest.isCompleted && activeQuest.requirement == type)
        {
            activeQuest.currentAmount += amount;

            if (activeQuest.currentAmount >= activeQuest.requiredAmount)
            {
                activeQuest.currentAmount = activeQuest.requiredAmount;
                activeQuest.isCompleted = true;
                Debug.Log("Görev tamamlandı: " + activeQuest.questName);
            }
        }
    }

    public void CompleteQuest(QuestGiver giver = null)
    {
        if (activeQuest != null && activeQuest.isCompleted)
        {
            Debug.Log($"Görev Tamamlandı! Ödül: {activeQuest.goldReward} altın");

            // Görevi tamamladığını QuestGiver'a bildir
            if (giver != null)
            {
                giver.CompleteCurrentQuest();
            }

            activeQuest = null; // yeni görev alınabilir
        }
    }
}
