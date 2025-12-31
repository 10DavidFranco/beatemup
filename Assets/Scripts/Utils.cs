using UnityEngine;

public static class Utils
{
    private static GameObject player = GameObject.FindWithTag("Player");
    private static GameObject cam = GameObject.FindWithTag("MainCamera");
    private static int enemy_deaths = 0;
    private static int current_encounter_id;
    private static int num_encounters;

    public static int draw_order(float y)
    {
       // Debug.Log(y % 1);

        if(y % 1 < 0.5f)
        {
            return 12 - (((int)Mathf.Floor(y) * 2) - 1); //Ranges from (0-6) * 2 (0,2,4,6,8,10,12) - 1 (-1,1,3,5,7,9,11,13)
            
        }
        else
        {
            return 12 - ((int)Mathf.Floor(y) * 2); //Ranges from (0-6) * 2 (0,2,4,6,8,10,12)
        }
        //if y tail is less than 0.5 odds (1-11)
        //else evens (0-12)
        
    }

    public static GameObject get_player()
    {
        return player;
    }

    public static GameObject get_camera()
    {
        return cam;
    }

    public static void increment_enemy_deaths()
    {
        enemy_deaths++;
    }

    public static void reset_enemy_deaths()
    {
        enemy_deaths = 0;
    }

    public static int get_enemy_deaths()
    {
        return enemy_deaths;
    }

    public static void set_encounter_id(int id)
    {
        current_encounter_id = id;
    }

    public static int get_current_encounter()
    {
        return current_encounter_id;
    }

    public static int AssignEncounterid()
    {
        return num_encounters++;
    }
}
