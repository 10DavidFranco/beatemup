using UnityEngine;

public class encounter_marker : MonoBehaviour
{
    private camera_movement cm;
    public encounter_manager em;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cm = Utils.get_camera().GetComponent<camera_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "MainCamera")
        {
            cm.stop_camera = true;
            em.StartEncounter();
        }
    }
}
