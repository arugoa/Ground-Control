using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float jumpSpeed;
    private bool playerInput;
    private bool isGrounded;
    [SerializeField]private Transform legs;
    public LayerMask ground;
    [SerializeField]private float radius;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /* Grounded Check */
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, ground);
        isGrounded = hit.collider != null;

        /* Visualize Ray in Scene View */
        Color rayColor = isGrounded ? Color.green : Color.red; // Green if grounded, red otherwise
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, rayColor);


        /* Player Movement */
        playerInput = Input.GetKeyDown(KeyCode.Space);
        if (playerInput && isGrounded)
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }
}
