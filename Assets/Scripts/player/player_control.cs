using UnityEngine;

public class player_control : MonoBehaviour
{

    Rigidbody2D rb;
    public float move_speed; //actual movement factor
    private float z_placeholder; //placeholder until z logic is determined
    public bool facing_right;

    //we need a formula to calculate an object's sorting order in the gamemap.
    //objects that don't move can be assigned an immutable value based on the formula.
    //objects that do move up and down, need to call a function in their update method.
    public SpriteRenderer sp;

    //For attacking
    public Collider2D attack_box;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
        facing_right = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputMovement();
        HandleSortingOrder();
        HandleAttack();
    }

    void HandleAttack()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            attack_box.enabled = true;  //This should eventually be done inside the attack animation.
        }
        else
        {
            attack_box.enabled = false;
        }*/

        // player is facing right, add force vector.right, else add force vector.lef
        //now for the knockback the question is: where do I actually run this?


            
    }


    ///How do we draw the player sprite:
    void HandleSortingOrder()
    {
        sp.sortingOrder = Utils.draw_order(this.transform.position.y);
       
    }

    void FlipPlayer()
    {
        this.gameObject.transform.Rotate(0f, 180f, 0f, Space.Self);
    }

    void HandleInputMovement()
    {
        ///PERHAPS HERE CHECK FOR ANY EXTERNAL CONDITIONS THAT WOULD CONSTRAIN MOVEMENT

        ////////////////checking flip and direction on x axis
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            if (facing_right)
            {
                FlipPlayer();
                facing_right = !facing_right;
            }
            
        }
        else if (Input.GetAxisRaw("Horizontal")> 0f)
        {
            if (!facing_right)
            {
                FlipPlayer();
                facing_right = !facing_right;
            } 
            
        }else
        {
            
        }
      
       
        //Processing input on both axises.
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            rb.linearVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized * move_speed;
        }else if (Input.GetButton("Horizontal"))
        {
            rb.linearVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f).normalized * move_speed;
        }
        else if (Input.GetButton("Vertical"))
        {
            rb.linearVelocity = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f).normalized * move_speed;
        }
        else
        {
            rb.linearVelocity = new Vector3(0f, 0f, 0f).normalized;
        }

    }


}
