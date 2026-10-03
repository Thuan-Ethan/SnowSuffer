using UnityEngine;

public class PowerupItemManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;
    PlayerControl player;
    SpriteRenderer spriteRenderer;
    float timeLeft;

    void Start()
    {
        player = FindAnyObjectByType<PlayerControl>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if (spriteRenderer.enabled == false)
        {
            if(timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                Debug.Log("Time left: " + timeLeft);
            }
           else
            {
                Debug.Log("Time's up");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            // Active the powerup effect
            player.activatePowerup(powerup);
            spriteRenderer.enabled = false; // hide the powerup item after collection
        }
    }
}
