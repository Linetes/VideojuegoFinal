using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{

    public LayerMask roomMask;
    public NewLevelGenerator levelGen;
    // Update is called once per frame
        void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomMask);
        if(roomDetection == null && levelGen.stopGeneration == true)
        {
            int rand = Random.Range(0, levelGen.rooms.Length);
            GameObject room = (GameObject)Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            room.transform.parent = levelGen.grid.transform;
            Destroy(gameObject);
        }

    }
}
