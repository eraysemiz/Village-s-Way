using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class NPCInteraction : MonoBehaviour
{
    private QuestGiver questGiver;

    private void Start()
    {
        questGiver = GetComponent<QuestGiver>();
        if (questGiver == null)
            Debug.LogError("NPCInteraction: QuestGiver component bulunamadý!");
    }

    private void OnMouseDown()
    {
        Quest quest = questGiver.GetCurrentQuest();

        if (quest == null) return;

        if (!QuestManager.Instance.HasActiveQuest())
        {
            QuestUI.Instance.ShowQuest(quest);
        }
        else if (QuestManager.Instance.activeQuest.isCompleted)
        {
            QuestUI.Instance.ShowQuest(quest);
        }
        else
        {
            // Görev devam ediyor, uyarý ver
            QuestUI.Instance.ShowQuest(QuestManager.Instance.activeQuest);
            QuestUI.Instance.descriptionText.text = "Önce mevcut görevi tamamlamalýsýnýz!";
        }
    }
}
