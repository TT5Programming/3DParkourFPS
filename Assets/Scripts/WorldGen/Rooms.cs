using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public List<GameObject> rooms;

    public float waitTime = 1;
    private bool spawnedGoal;
    public GameObject goal;

    void Update()
    {
        if (waitTime <= 0 && spawnedGoal == false)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(goal, rooms[i].transform.position, Quaternion.identity);
                    spawnedGoal = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
