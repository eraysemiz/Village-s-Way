using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int bullMeatCount;
    public int chickenMeatCount;
    public int tomatoCount;
    public int wheatCount;

    public void AddMeat(Animal.AnimalType type)
    {
        if (type == Animal.AnimalType.Chicken)
        {
            chickenMeatCount++;
            FindFirstObjectByType<QuestManager>()?.OnItemCollected(Quest.RequirementType.ChickenMeat, 1);
        }
            
        else if (type == Animal.AnimalType.Bull)
        {
            bullMeatCount++;
            FindFirstObjectByType<QuestManager>()?.OnItemCollected(Quest.RequirementType.BullMeat, 1);
        } 
    }

    public void AddCrop(Crop.CropType type)
    {
        if (type == Crop.CropType.Tomato)
        {
            tomatoCount++;
            FindFirstObjectByType<QuestManager>()?.OnItemCollected(Quest.RequirementType.Tomato, 1);
        }
        else if (type == Crop.CropType.Wheat)
        {
            wheatCount++;
            FindFirstObjectByType<QuestManager>()?.OnItemCollected(Quest.RequirementType.Wheat, 1);
        }
            
    }
}
