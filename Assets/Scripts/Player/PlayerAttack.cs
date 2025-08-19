using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea; // Player’ýn child’ý olacak
    public float attackDuration = 0.2f;

    private bool isAttacking = false;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        attackArea.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        Vector2 dir = playerController.lastMoveDir;

        // yönüne göre collider konumunu ayarla
        if (dir == Vector2.up) attackArea.transform.localPosition = new Vector3(0, 0.5f, 0);
        else if (dir == Vector2.down) attackArea.transform.localPosition = new Vector3(0, -0.5f, 0);
        else if (dir == Vector2.left) attackArea.transform.localPosition = new Vector3(-0.5f, 0, 0);
        else if (dir == Vector2.right) attackArea.transform.localPosition = new Vector3(0.5f, 0, 0);

        attackArea.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackArea.SetActive(false);

        isAttacking = false;
    }
}
