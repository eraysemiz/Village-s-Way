using TMPro;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryScreen; // Canvas içindeki envanter paneli
    private bool isOpen = false;
    private PlayerInventory inventory;

    public TextMeshProUGUI tomatoCount;
    public TextMeshProUGUI wheatCount;
    public TextMeshProUGUI bullMeatCount;
    public TextMeshProUGUI chickenMeatCount;


    private void Start()
    {
        inventoryScreen.SetActive(false);
        inventory = FindFirstObjectByType<PlayerInventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isOpen)
                OpenInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
                CloseInventory();
        }

        if (isOpen)
            UpdateUI();
    }

    public void OpenInventory()
    {
        inventoryScreen.SetActive(true);
        isOpen = true;
        Time.timeScale = 0f; // Oyunu durdur    
        // Cursor’u göster (özellikle FPS/TPS oyunlarýnda gerekli olabilir)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInventory()
    {
        inventoryScreen.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f; // Oyunu devam ettir
        // Cursor’u gizle (eðer oyununda normalde gizliyorsan)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UpdateUI()
    {
        bullMeatCount.text = ": " + inventory.bullMeatCount;
        chickenMeatCount.text = ": " + inventory.chickenMeatCount;
        tomatoCount.text = ": " + inventory.tomatoCount;
        wheatCount.text = ": " + inventory.wheatCount;
    }
}
