using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class NPCInteraction : MonoBehaviour
{
    private QuestGiver questGiver;

    private void Start()
    {
        questGiver = GetComponent<QuestGiver>();
        if (questGiver == null)
            Debug.LogError("NPCInteraction: QuestGiver component bulunamad�!");
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
            // G�rev devam ediyor, uyar� ver
            QuestUI.Instance.ShowQuest(QuestManager.Instance.activeQuest);
            QuestUI.Instance.descriptionText.text = "�nce mevcut g�revi tamamlamal�s�n�z!";
        }
    }
}
