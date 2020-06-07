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
            int randRoom = Random.Range(0, 4);
            int rand;
            GameObject room;
            switch (randRoom)
            {
                case 0:
                    rand = Random.Range(2, levelGen.roomsLR.Length);
                    room = (GameObject)Instantiate(levelGen.roomsLR[rand], transform.position, Quaternion.identity);
                    break;
                case 1:
                    rand = Random.Range(0, levelGen.roomsLRB.Length);
                    room = (GameObject)Instantiate(levelGen.roomsLRB[rand], transform.position, Quaternion.identity);
                    break;
                case 2:
                    rand = Random.Range(0, levelGen.roomsLRT.Length);
                    room = (GameObject)Instantiate(levelGen.roomsLRT[rand], transform.position, Quaternion.identity);
                    break;
                default:
                    rand = Random.Range(0, levelGen.roomsLRTB.Length);
                    room = (GameObject)Instantiate(levelGen.roomsLRTB[rand], transform.position, Quaternion.identity);
                    break;

            }
            room.transform.parent = levelGen.grid.transform;
            Destroy(gameObject);
        }

    }
}
