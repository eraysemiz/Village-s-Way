using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum AnimalType{Bull, Chicken}
    public AnimalType type;
    public int health = 1; // tek vuruþta ölmesi için 1
    private AnimalSpawner spawner;
    public GameObject meatPrefab;   // düþecek et prefabý

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
        // Spawner’a haber gönder
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
