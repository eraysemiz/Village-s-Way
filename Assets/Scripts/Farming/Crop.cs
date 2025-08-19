using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public Sprite[] growthStages; // 0: ekilmiþ, 4: tamamen yetiþmiþ
    public float totalGrowTime = 20f; // toplam büyüme süresi
    private SpriteRenderer sr;
    private int currentStage = 0;

    [HideInInspector] public FarmManager farmManager;
    private Vector3Int cellPos;

    public enum CropType {Tomato, Wheat}
    public CropType type;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (growthStages.Length > 0)
            sr.sprite = growthStages[0];

        if (farmManager != null)
            cellPos = farmManager.farmTilemap.WorldToCell(transform.position);

        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        float timePerStage = totalGrowTime / (growthStages.Length - 1);

        while (currentStage < growthStages.Length - 1)
        {
            yield return new WaitForSeconds(timePerStage);
            currentStage++;
            sr.sprite = growthStages[currentStage];
        }
    }

    public bool CanHarvest()
    {
        return currentStage == growthStages.Length - 1;
    }

    public void Harvest()
    {
        if (CanHarvest())
        {
            PlayerInventory inventory = farmManager.player.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddCrop(type);
                Debug.Log(type + " hasat edildi!");
            }
            // Tile map üzerindeki ekim bilgisini temizle
            if (farmManager != null)
                farmManager.RemovePlant(cellPos);

            // Destroy crop
            Destroy(gameObject);
        }
    }
}
