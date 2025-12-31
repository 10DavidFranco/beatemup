using UnityEngine;
using System.Collections;

public class enemy_control : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sp;
    public float move_speed;
    public bool is_moving_enemy;

    ///Following player
    public bool follow_player;
    public float x_flip;
    public float y_flip;
    public bool is_facing_right;

    //Attacking, actually attacks will be unique.
    public int health = 3;

    //Knockback
    private bool getting_knocked_back;
    public bool can_knockback;
    public float knockback_val;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    void Awake()
    {
        sp.sortingOrder = Utils.draw_order(this.transform.position.y);
       

        //We will figure out the flipping logic later, for now assume all enemies spawn on the right hand side of the player.
    }

    // Update is called once per frame
    void Update()
    {
        if (is_moving_enemy)
        {
            sp.sortingOrder = Utils.draw_order(this.transform.position.y);
        }
        if (follow_player)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, Utils.get_player().transform.position, move_speed);
            FollowPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player_Attack")
        {
            Debug.Log("Ouch!");
            health--;
            if (can_knockback)
            {
                getting_knocked_back = true;
                StartCoroutine(StopKnockback());
            }
            CheckDeath();
        }
    }

    IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(0.2f);
        getting_knocked_back = false;
    }

   

    void CheckDeath()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Do other stuff
        Utils.increment_enemy_deaths();
        Destroy(this.gameObject);
    }

    

    void FlipEnemy() 
    {
        this.gameObject.transform.Rotate(0f, 180f, 0f, Space.Self);
        is_facing_right = !is_facing_right;
    }

    void FollowPlayer()
    {
        if(this.transform.position.x < Utils.get_player().transform.position.x) //my x is less than players x, they are to the right of me
        {
            if (!is_facing_right)
            {
                FlipEnemy();
            }
            x_flip = 1f;
        }
        else if(this.transform.position.x > Utils.get_player().transform.position.x) //my x is greater than players x, they are to the left of me
        {
            if (is_facing_right)
            {
                FlipEnemy();
            }
            x_flip = -1f;
        }
        else
        {

        }

        if (this.transform.position.y < Utils.get_player().transform.position.y)
        {

            y_flip = 1f;

        }
        else if (this.transform.position.y > Utils.get_player().transform.position.y)
        {

            y_flip = -1f;
        }
        else
        {

        }

        if (!getting_knocked_back)
        {
            rb.linearVelocity = new Vector3(Mathf.Abs(this.transform.position.x - Utils.get_player().transform.position.x) * x_flip, Mathf.Abs(this.transform.position.y - Utils.get_player().transform.position.y) * y_flip, 0f).normalized;
        }
        else
        {
            Debug.Log("Knocking you back");
            rb.linearVelocity = new Vector3(knockback_val * x_flip * -1, 0f, 0f);
           
        }
       
    }
}
