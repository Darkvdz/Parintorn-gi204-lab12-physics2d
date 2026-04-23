using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpforce = 450;


    private Rigidbody2D rb;
    private float moveInputValue; // A = -1 / D = 1

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInputValue = (Keyboard.current.dKey.isPressed ? 1 : 0)
            - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        rb.linearVelocity = new Vector2(moveInputValue * speed, rb.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpforce));
        }
    }
}
