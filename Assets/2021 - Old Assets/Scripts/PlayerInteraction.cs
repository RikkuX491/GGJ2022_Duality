using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    // The background music for the current scene
    public AudioSource currentBackgroundMusic;

    // Play this sound when an event occurs in the game
    public AudioSource youFoundMeAudio;

    // The SpriteRenderer for the first Sprite for the Demon
    public SpriteRenderer demonSprite1;

    // The second Sprite for the Demon to switch to when an event occurs
    public Sprite demonSprite2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the Player collides with the Demon...
        if (collision.gameObject.CompareTag("Demon"))
        {
            // Stop the player from moving
            PlayerMovement.canMove = false;

            // Make the current background music stop playing
            currentBackgroundMusic.Stop();

            // Change the sprite for the Demon
            demonSprite1.sprite = demonSprite2;            

            // Play the "You Found Me" audio
            youFoundMeAudio.Play(0);

            // Load Scene 2
            Invoke("changeScene", 5.0f);            
        }
    }

    private void changeScene()
    {
        SceneManager.LoadScene(1);
    }
}
