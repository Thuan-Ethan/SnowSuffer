using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector2D;

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
        PlayerRotation();
        Boost();
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
}
