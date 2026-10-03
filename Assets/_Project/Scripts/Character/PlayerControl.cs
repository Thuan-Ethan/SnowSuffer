using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    private InputAction moveAction;
    private Rigidbody2D myRigidbody2D;
    private Vector2 moveVector;
    private SurfaceEffector2D surfaceEffector2D;

    public bool canControlPlayer = true;
    private float previousRotation;
    private float totalRotation;
    private int flipCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        // Old method to find the SurfaceEffector2D component in the scene
        //surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        // New method to find the SurfaceEffector2D component in the scene
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        if (canControlPlayer)
        {
            PlayerRotation();
            Boost();
            calculateFlips();
        }
    }

    void PlayerRotation()
    {
        // Torque control based on horizontal input
        myRigidbody2D.AddTorque(-moveVector.x * torqueAmount);
    }
    void Boost()
    {
        // Optimized version using ternary operator
        surfaceEffector2D.speed = (moveVector.y > 0) ? boostSpeed : baseSpeed;
    }
    void calculateFlips()
    {
        // Calculate the number of flips based on the player's rotation
        float currentRotation = transform.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation >= 340f || totalRotation <= -340f)
        {
            flipCount++;
            totalRotation = 0f; // Reset total rotation after a flip
            print("Flips: " + flipCount);
        }
        previousRotation = currentRotation;
        //print(totalRotation);
    }
    public void disableControl()
    {
        canControlPlayer = false;
        surfaceEffector2D.speed = 0f; // Stop the player from moving when control is disabled
    }
}
