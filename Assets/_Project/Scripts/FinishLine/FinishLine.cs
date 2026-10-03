using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void Start()
    {
        finishPartical.Stop();
    }
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem finishPartical;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collision.gameObject.layer == layerIndex)
        {
            finishPartical.Play();
            Invoke("RestartLevel", restartDelay);
            Debug.Log(collision.gameObject.name + " has reached the finish line!");
        }
    }

    void RestartLevel()
    {
        // Restart the current level
        SceneManager.LoadScene(0);
    }
}
