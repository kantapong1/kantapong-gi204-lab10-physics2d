using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Rigidbody2D rb2d;

    Vector2 moveInput;

    //Walk
    public float Speed;
    float move;

    //Jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Walk with addForce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * Speed);

/*      move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed , rb2d.linearVelocity.y);
*/  
        
        //jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));

            Debug.Log("Jump");
        }
    }

   public void OnCollisionEnter2D(Collision2D Other)
   {
        if (Other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
   }

   public void OnCollisionExit2D(Collision2D other)
   {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
   }
}
