using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public GameObject player;
    public bool stop_camera;
    public bool encounter_just_ended;
    private float max_prev_x;
    private float x_axis_factor;
    public float pan_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        max_prev_x = player.transform.position.x;
        encounter_just_ended = false;
        stop_camera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop_camera){

            if(player.transform.position.x < max_prev_x)
            {
                if (encounter_just_ended)
                {
                    encounter_just_ended = false;
                }
            }
            else
            {
                if (encounter_just_ended)
                {
                    //do something smoother
                    //incrementally add the difference on ther x axis between the camera and the player. make the increments small to accomdate for smoothness.
                    //but not too small that the player can perpetually outrun the camera.
                       
                    this.transform.position = new Vector3(this.transform.position.x + pan_speed, 4.98f, -10f);
                    
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x, 4.98f, -10f);
                }
                
                max_prev_x = this.transform.position.x;
            }
            
        }
        
    }

    
}
