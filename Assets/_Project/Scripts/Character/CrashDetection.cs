using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem crashPartical;

    private void Start()
    {
        crashPartical.Stop();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            crashPartical.Play();
            Invoke("RestartLevel", restartDelay);
            Debug.Log(collision.gameObject.name + " has lost!");
        }
    }

    void RestartLevel()
    {
        // Restart the current level
        SceneManager.LoadScene(0);
    }
}
