using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest[] quests;
    private int currentQuestIndex = 0;

    public Quest GetCurrentQuest()
    {
        if (currentQuestIndex < quests.Length)
            return quests[currentQuestIndex];
        return null;
    }

    public void CompleteCurrentQuest()
    {
        currentQuestIndex++;
    }
}
