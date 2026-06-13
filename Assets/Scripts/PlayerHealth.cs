using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    private PlayerController playerController;
    private Animator anim;

    public TextMeshProUGUI hpText;

    public GameObject gameOverPanel;

    private void Start()
    {
        currentHP = maxHP;

        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateHPUI();
    }

    private void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP + " / " + maxHP;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        anim.SetTrigger("Die");

        UpdateHPUI();

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("PLAYER MORREU");

        if (anim != null)
        {
            anim.SetTrigger("Die");
        }

        if (playerController != null)
        {
            playerController.isDead = true;
            GetComponent<PlayerController>().enabled = false;

        }
       
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
        }

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
