using UnityEngine;
using UnityEngine.UI; // NUEVO: Necesario para usar 'Button'
using UnityEngine.SceneManagement; // NUEVO: Necesario para cambiar de escenas
using UnityEngine.InputSystem; // NUEVO: Necesario para usar 'Keyboard'

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject gameOverPanel;
    public Button menuButton;
    private bool gameOverActivo = false;

    public event System.Action<int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (menuButton != null)
            menuButton.onClick.AddListener(irAlMenu);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
        
        OnHealthChanged?.Invoke(currentHealth);

        Debug.Log("Player took damage: " + amount + ". Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (gameOverActivo)
        {
            if (keyboard.mKey.wasPressedThisFrame || keyboard.escapeKey.wasPressedThisFrame)
                irAlMenu();
        }
    }

    void Die()
    {
        if (gameOverActivo) return;
        Debug.Log("Player Died!");
        Time.timeScale = 0f;

        gameOverActivo = true;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        // Add death logic here (e.g., reload scene, show game over screen)
    }

    public void irAlMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
