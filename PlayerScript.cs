using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor.Experimental.GraphView;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private float direction = 0f;
    private float directionY = 0f;
    private bool grounded = true;

    public float speed;
    public float groundCheckDistance;
    public float jumpSpeed;
    public LayerMask groundMask;

    public void OnMove(CallbackContext ctx) // Clicar D o A
    {
        direction = ctx.ReadValue<float>(); // actualitzar cap a on es mou -1, 1 etc.
    }

    public void OnJump(CallbackContext ctx)
    {
        directionY = ctx.ReadValue<float>(); // actualitzar cap a on es mou -1, 1 etc.
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocityY); // per a que es mogui xd
        
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red, 1); // Dibuixar Raycast

        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        grounded &= rb.linearVelocity.y <= 0f;

        if (grounded)
            rb.linearVelocity += jumpSpeed * Vector2.up * directionY; // actualitzar direccio Y
        

        if (direction > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (direction < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}


/*
fdfd 
 
*/
