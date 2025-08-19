using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animal animal = collision.GetComponent<Animal>();
        if (animal != null)
        {
            animal.TakeDamage(1); // tek vuru�ta �ld�rmek i�in
        }
    }
}
