using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum AnimalType{Bull, Chicken}
    public AnimalType type;
    public int health = 1; // tek vuru�ta �lmesi i�in 1
    private AnimalSpawner spawner;
    public GameObject meatPrefab;   // d��ecek et prefab�

    public void Init(AnimalSpawner animalSpawner)
    {
        spawner = animalSpawner;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Spawner�a haber g�nder
        if (spawner != null)
        {
            spawner.OnAnimalDied(gameObject);
        }

        if (meatPrefab != null)
        {
            Instantiate(meatPrefab, transform.position, Quaternion.identity);
        }


        Destroy(gameObject);
    }
}
