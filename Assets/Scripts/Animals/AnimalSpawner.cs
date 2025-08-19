using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class AnimalSpawner : MonoBehaviour
{
    public Tilemap spawnAreaTilemap;
    public GameObject cowPrefab;
    public GameObject chickenPrefab;

    public float respawnDelay = 5f; // öldükten sonra yeniden doðma süresi

    void Start()
    {
        SpawnAnimal(cowPrefab);
        SpawnAnimal(chickenPrefab);
    }

    public void SpawnAnimal(GameObject prefab)
    {
        BoundsInt bounds = spawnAreaTilemap.cellBounds;

        while (true)
        {
            Vector3Int randomCell = new Vector3Int(
                Random.Range(bounds.xMin, bounds.xMax),
                Random.Range(bounds.yMin, bounds.yMax),
                0
            );

            if (spawnAreaTilemap.HasTile(randomCell))
            {
                Vector3 spawnPos = spawnAreaTilemap.CellToWorld(randomCell) + spawnAreaTilemap.tileAnchor;
                GameObject animal = Instantiate(prefab, spawnPos, Quaternion.identity);

                // Animal scriptini ayarla
                Animal a = animal.GetComponent<Animal>();
                if (a != null)
                {
                    a.Init(this);
                }
                break;
            }
        }
    }

    public void OnAnimalDied(GameObject animal)
    {
        string tag = animal.tag; // prefab’a “Cow” veya “Chicken” tag’ý ver

        if (tag == "Bull")
        {
            StartCoroutine(RespawnAfterDelay(cowPrefab));
        }
        else if (tag == "Chicken")
        {
            StartCoroutine(RespawnAfterDelay(chickenPrefab));
        }
    }

    IEnumerator RespawnAfterDelay(GameObject prefab)
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnAnimal(prefab);
    }
}
