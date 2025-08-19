using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmManager : MonoBehaviour
{
    public Tilemap farmTilemap;
    public GameObject cropPrefab;
    private Dictionary<Vector3Int, bool> plantedTiles = new Dictionary<Vector3Int, bool>();
    public GameObject player;

    void Update()
    {
        Vector3Int cellPos = farmTilemap.WorldToCell(player.transform.position);

        // F tuþu ile ekim
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (farmTilemap.HasTile(cellPos))
            {
                if (!plantedTiles.ContainsKey(cellPos) || plantedTiles[cellPos] == false)
                {
                    Vector3 spawnPos = farmTilemap.GetCellCenterWorld(cellPos);
                    GameObject crop = Instantiate(cropPrefab, spawnPos, Quaternion.identity);

                    Crop cropScript = crop.GetComponent<Crop>();
                    if (cropScript != null)
                        cropScript.farmManager = this;

                    plantedTiles[cellPos] = true;
                    Debug.Log("Bitki ekildi!");
                }
                else
                {
                    Debug.Log("Bu hücrede zaten bir bitki var!");
                }
            }
        }

        // E tuþu ile hasat
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 center = farmTilemap.GetCellCenterWorld(cellPos);
            Collider2D[] hits = Physics2D.OverlapCircleAll(center, 0.3f);

            foreach (Collider2D hit in hits)
            {
                Crop crop = hit.GetComponent<Crop>();
                if (crop != null && crop.CanHarvest())
                {
                    crop.Harvest();
                    Debug.Log("Crop hasat edildi!");
                }
            }
        }
    }

    public void RemovePlant(Vector3Int cellPos)
    {
        if (plantedTiles.ContainsKey(cellPos))
            plantedTiles[cellPos] = false;
    }
}
