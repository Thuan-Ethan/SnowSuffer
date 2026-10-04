using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject frogSprite;
    [SerializeField] GameObject dinoSprite;

    void Start()
    {
        Time.timeScale = 0f; // Pause the game at the start
        scoreCanvas.SetActive(false); // Hide the score canvas at the start
    }

    void beginGame()
    {
        Time.timeScale = 1f; // Resume the game
        scoreCanvas.SetActive(true); // Show the score canvas
        gameObject.SetActive(false); // Hide the character selection canvas
    }

    public void chooseFrog()
    {
        frogSprite.SetActive(true); // Show the frog sprite
        beginGame(); // Start the game
    }

    public void chooseDino()
    {
        dinoSprite.SetActive(true); // Show the dino sprite
        beginGame(); // Start the game
    }
}
