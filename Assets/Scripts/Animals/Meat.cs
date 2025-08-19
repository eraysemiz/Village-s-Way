using UnityEngine;

public class Meat : MonoBehaviour
{
    public Animal.AnimalType type; // Cow veya Chicken

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.AddMeat(type);
            Destroy(gameObject);
        }
    }
}
