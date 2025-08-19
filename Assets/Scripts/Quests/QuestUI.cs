using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public static QuestUI Instance;

    [Header("UI Elemanları")]
    public GameObject panel;
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI rewardText;
    public Button okButton;

    private Quest currentQuest;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        panel.SetActive(false);
        okButton.onClick.AddListener(OnOkButton);
    }

    public void ShowQuest(Quest quest)
    {
        currentQuest = quest;

        questNameText.text = quest.questName;
        descriptionText.text = quest.description;
        rewardText.text = $"Ödül: {quest.goldReward} altın";

        panel.SetActive(true);
    }

    private void OnOkButton()
    {
        panel.SetActive(false);

        if (currentQuest != null)
        {
            // Eğer görev tamamlandıysa CompleteQuest çağır
            if (currentQuest.isCompleted)
            {
                QuestManager.Instance.CompleteQuest();
            }
            // Görev alınacaksa AcceptQuest çağır
            else if (!QuestManager.Instance.HasActiveQuest())
            {
                QuestManager.Instance.AcceptQuest(currentQuest);
            }
        }
    }
}
