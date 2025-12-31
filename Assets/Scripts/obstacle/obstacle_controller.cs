using UnityEngine;

public class obstacle_controller : MonoBehaviour
{
    public bool is_moving_obstacle;
    public SpriteRenderer sp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp.sortingOrder = Utils.draw_order(this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_moving_obstacle)
        {
            sp.sortingOrder = Utils.draw_order(this.transform.position.y);
        }
    }
}
