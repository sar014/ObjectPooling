using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] TextMeshProUGUI GameOverText;
    [SerializeField] AudioClip collisionSound;
    [SerializeField] AudioClip GameOverSound;
    float maxHealth = 100f;
    float currentHealth;
    AudioSource[] audioSource;
    AudioSource playerAudio;

    private void Awake() {
        audioSource = FindObjectsOfType<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
    }
   
    void Start()
    {
        //Setting the max health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("asteroid"))
        {
            //Setting collision Sound and then playing it
            playerAudio.clip = collisionSound;
            playerAudio.Play();

            currentHealth -=10;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go negative
            healthBar.SetHealth(currentHealth, maxHealth);
            Debug.Log("Health = "+currentHealth);

            if(currentHealth==0)
            {
                StopAllMusic();

                //Setting Game Over Sound 
                playerAudio.clip = GameOverSound;
                playerAudio.Play();
                
                GameOverText.SetText("Game Over");
                Time.timeScale = 0; //Pauses the game
            }
        }
    }

    void StopAllMusic()
    {
        foreach(var audio in audioSource)
        {
            audio.Stop();
        }
    }
}
