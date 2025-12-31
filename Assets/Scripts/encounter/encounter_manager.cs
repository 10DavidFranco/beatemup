using UnityEngine;
using System.Collections;

public class encounter_manager : MonoBehaviour
{
    public GameObject[] enemies;
    public int[] wave_breakpoints;
    public Transform[] spawn_points;
    public Transform single_spawnpoint;
    private bool ending_encounter;
    private camera_movement cm;
    public bool has_waves;
    public bool only_one_spawnpoint;
    [SerializeField] private int encounter_id;
    private bool spawn_wave_once;
    public int current_wave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Perhaps encounters should get their id on start, but first lets find camera.
        cm = Utils.get_camera().GetComponent<camera_movement>();
        encounter_id = Utils.AssignEncounterid();
        current_wave = 0;
        spawn_wave_once = false;
    }

    void Awake()
    {
        ending_encounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Utils.get_enemy_deaths() == enemies.Length && encounter_id == Utils.get_current_encounter()) //This will activate for ALL encounters present in a scene. It works. But there needs to be a way to differentiate between the current encounter.
        {
            if (!ending_encounter)
            {
                ending_encounter = !ending_encounter;
                EndEncounter();
            }
            
        }

        if (has_waves)
        {
            if (Utils.get_enemy_deaths() == wave_breakpoints[current_wave])
            {
                if (!spawn_wave_once)
                {
                    spawn_wave_once = true;
                    current_wave++;

                    if (current_wave == wave_breakpoints.Length)
                    {

                    }
                    else
                    {
                        NextWave();
                    }
                }
           
            }
            else
            {
                //wait for wave to finish
            }
        }
    }

    private void EndEncounter()
    {
        cm.stop_camera = false;
        //cm.CalculatePanSpeed();
        cm.encounter_just_ended = true;
        Destroy(this.gameObject);
    }

    public void StartEncounter()
    {
        Utils.reset_enemy_deaths();
        Utils.set_encounter_id(encounter_id);

        if (!has_waves)
        {
            SpawnEnemies();
        }
        else
        {
            StartWaves();
        }
       
        
           
        
        
    }

    void StartWaves()
    {
        current_wave = 0;
        

        for (int i = 0; i < wave_breakpoints[current_wave]; i++)
        {
            if (only_one_spawnpoint)
            {
                Instantiate(enemies[i], single_spawnpoint.position, single_spawnpoint.rotation);
            }
            else
            {
                Instantiate(enemies[i], spawn_points[i].position, spawn_points[i].rotation);
            }
           
        }

    }

    void NextWave()
    {
        for (int i = wave_breakpoints[current_wave - 1]; i < wave_breakpoints[current_wave]; i++)
        {
            if (only_one_spawnpoint)
            {
                Instantiate(enemies[i], single_spawnpoint.position, single_spawnpoint.rotation);
            }
            else
            {
                Instantiate(enemies[i], spawn_points[i].position, spawn_points[i].rotation);
            }
            
        }

        spawn_wave_once = false;
    }

    private void SpawnEnemies()
    {

        if (only_one_spawnpoint)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Instantiate(enemies[i], single_spawnpoint.position, single_spawnpoint.rotation);
            }
        }
        else
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Instantiate(enemies[i], spawn_points[i].position, spawn_points[i].rotation);
            }
        }
        //Remember to add further logic for wave-type spawning.
       
    }
}
