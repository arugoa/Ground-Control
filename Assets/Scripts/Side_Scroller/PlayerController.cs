using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpSpeed;
    private bool playerInput;
    private bool playerInputDown;
    private bool playerInputUp;
    private bool canJump=true;
    public float jumpTime;
    public float initJumpTime;
    private bool isGrounded;
    public bool decreaseTime;
    [SerializeField]private Transform legs;
    public LayerMask ground;
    [SerializeField]private float radius;
    [SerializeField] private float maxVel;
    public float currentVel;
    public bool crouch;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initJumpTime = jumpTime;
        currentVel = rb.velocity.y;
        anim.SetBool("walk", true);
    }
    
    private void Update()
    {
        //Jump Input Check 
        playerInput = Input.GetKey(KeyCode.Space);
        playerInputDown = Input.GetKeyDown(KeyCode.Space);
        playerInputUp = Input.GetKeyUp(KeyCode.Space);

        // Grounded Check
        RaycastHit2D hit = Physics2D.Raycast(legs.transform.position, Vector2.down, 0.2f, ground);
        isGrounded = hit.collider != null;

        // Visualize Ray in Scene View 
        Color rayColor = isGrounded ? Color.green : Color.red; // Green if grounded, red otherwise
        Debug.DrawRay(legs.transform.position, Vector2.down * 0.7f, rayColor);
        
        //Velocity Clamp
        if(rb.velocity.y > maxVel)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVel);
        }

        //Variable Jump
        if (decreaseTime)
        {
            jumpTime -= Time.deltaTime;
        }
        if (!isGrounded)
        {
            decreaseTime = true;
        }
        if (isGrounded)
        {
            jumpTime = initJumpTime;
            decreaseTime = false;
        }
        if (playerInput && jumpTime>0f)
        {
            rb.AddForce(transform.up * jumpSpeed * jumpTime, ForceMode2D.Force);
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }

        //Crouch
        if (Input.GetKey(KeyCode.C))
        {
            //crouch anim
            anim.SetBool("crouch", true);
        }
        else
        {
            anim.SetBool("crouch", false);
        }
    }
}