using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public string doorNeeded;

    private bool spawned = false;

    private int random;
    public float spawnDelay;

    private Vector3 positionToSpawn;

    private Rooms roomsScript;
    public float waitTime = 4f;

    private Spawnpoint otherSpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);

        roomsScript = GameObject.Find("GameHandler").GetComponent<Rooms>();

        positionToSpawn = transform.position;
        Invoke("SpawnRoom", spawnDelay);
    }

    private void SpawnRoom()
    {
        if (spawned == false)
        {
            if (doorNeeded == "Top")
            {
                random = Random.Range(0, topRooms.Length);
                Instantiate(topRooms[random], positionToSpawn, Quaternion.identity);
            }
            if (doorNeeded == "Bottom")
            {
                random = Random.Range(0, bottomRooms.Length);
                Instantiate(bottomRooms[random], positionToSpawn, Quaternion.identity);
            }
            if (doorNeeded == "Left")
            {
                random = Random.Range(0, leftRooms.Length);
                Instantiate(leftRooms[random], positionToSpawn, Quaternion.identity);
            }
            if (doorNeeded == "Right")
            {
                random = Random.Range(0, rightRooms.Length);
                Instantiate(rightRooms[random], positionToSpawn, Quaternion.identity);
            }
            spawned = true;
            roomsScript.waitTime = spawnDelay + 0.5f;
        }
    }

    private void SpawnClosedRoom()
    {
        if (otherSpawnScript.spawned == false && spawned == false)
        {
            Instantiate(closedRoom, transform.position, Quaternion.identity);
        }
        spawned = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawnpoint")
        {
            otherSpawnScript = other.gameObject.GetComponent<Spawnpoint>();

            Invoke("SpawnClosedRoom", spawnDelay - (spawnDelay/2));
            
        }
        if (other.tag == "Room")
        {
            spawned = true;
        }
    }
}
