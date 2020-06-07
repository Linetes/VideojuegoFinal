using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGenerator : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject player;
    public GameObject[] roomsLR;
    public GameObject[] roomsLRB;
    public GameObject[] roomsLRT;
    public GameObject[] roomsLRTB;
    public GameObject grid;

    private int direction;
    private int downCounter;

    public float moveAmountX;
    public float moveAmountY;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn = .25f;


    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration;

    public LayerMask roomMask;
    // Start is called before the first frame update
    private void Start()
    {
        
        int randStartingPos = Random.Range(0, startingPositions.Length);
        int randStartingRoom = Random.Range(0, 5);
        Debug.Log(randStartingPos);
        transform.position = new Vector2(startingPositions[randStartingPos].position.x, startingPositions[randStartingPos].position.y);
        GameObject startRoom = (GameObject)Instantiate(roomsLR[0], transform.position, Quaternion.identity);
        startRoom.transform.parent = grid.transform;
        player.transform.position = new Vector2(transform.position.x-1, transform.position.y-1);

        direction = Random.Range(1, 6);
        
        
    }
    private void Move()
    {
        if (direction == 1 || direction == 2)
        {
            downCounter = 0;
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmountX, transform.position.y);
                transform.position = newPos;

                
                int randRoom = Random.Range(0, 4);
                int rand;
                GameObject room;
                switch(randRoom){
                    case 0:
                        rand = Random.Range(2, roomsLR.Length);
                        room = (GameObject)Instantiate(roomsLR[rand], transform.position, Quaternion.identity);
                        break;
                    case 1:
                        rand = Random.Range(0, roomsLRB.Length);
                        room = (GameObject)Instantiate(roomsLRB[rand], transform.position, Quaternion.identity);
                        break;
                    case 2:
                        rand = Random.Range(0, roomsLRT.Length);
                        room = (GameObject)Instantiate(roomsLRT[rand], transform.position, Quaternion.identity);
                        break;
                    default:
                        rand = Random.Range(0, roomsLRTB.Length);
                        room = (GameObject)Instantiate(roomsLRTB[rand], transform.position, Quaternion.identity);
                        break;
                }
                

                room.transform.parent = grid.transform;

                direction = Random.Range(1, 6);
                if(direction == 3)
                {
                    direction = 2;
                }
                else if(direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if(direction==3 || direction==4){
            downCounter = 0;
            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmountX, transform.position.y);
                transform.position = newPos;

                int randRoom = Random.Range(0, 4);
                int rand;
                GameObject room;
                switch (randRoom)
                {
                    case 0:
                        rand = Random.Range(2, roomsLR.Length);
                        room = (GameObject)Instantiate(roomsLR[rand], transform.position, Quaternion.identity);
                        break;
                    case 1:
                        rand = Random.Range(0, roomsLRB.Length);
                        room = (GameObject)Instantiate(roomsLRB[rand], transform.position, Quaternion.identity);
                        break;
                    case 2:
                        rand = Random.Range(0, roomsLRT.Length);
                        room = (GameObject)Instantiate(roomsLRT[rand], transform.position, Quaternion.identity);
                        break;
                    default:
                        rand = Random.Range(0, roomsLRTB.Length);
                        room = (GameObject)Instantiate(roomsLRTB[rand], transform.position, Quaternion.identity);
                        break;
                }

                room.transform.parent = grid.transform;

                direction = Random.Range(3, 6);

            }
            else
            {
                direction = 5;
            }
        }
        else if(direction == 5)
        {
            int rand;
            downCounter++;
            if(transform.position.y > minY)
            {
                Debug.Log(roomMask);
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomMask);
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        rand = Random.Range(0, roomsLRTB.Length);
                        GameObject room = (GameObject)Instantiate(roomsLRTB[rand], transform.position, Quaternion.identity);
                        room.transform.parent = grid.transform;
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        
                        GameObject room;
                        switch (randBottomRoom)
                        {
                        
                            case 1:
                                rand = Random.Range(0, roomsLRB.Length);
                                room = (GameObject)Instantiate(roomsLRB[rand], transform.position, Quaternion.identity);
                                break;
                            case 2:
                                rand = Random.Range(0, roomsLRT.Length);
                                room = (GameObject)Instantiate(roomsLRT[rand], transform.position, Quaternion.identity);
                                break;
                            default:
                                rand = Random.Range(0, roomsLRTB.Length);
                                room = (GameObject)Instantiate(roomsLRTB[rand], transform.position, Quaternion.identity);
                                break;
                        }
                        

                        room.transform.parent = grid.transform;
                    }

                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountY);
                transform.position = newPos;

                int randRoom = Random.Range(2, 4);
                GameObject room2;
                switch (randRoom)
                {
                    case 2:
                        rand = Random.Range(0, roomsLRT.Length);
                        room2 = (GameObject)Instantiate(roomsLRT[rand], transform.position, Quaternion.identity);
                        break;
                    default:
                        rand = Random.Range(0, roomsLRTB.Length);
                        room2 = (GameObject)Instantiate(roomsLRTB[rand], transform.position, Quaternion.identity);
                        break;
                }

                room2.transform.parent = grid.transform;

                direction = Random.Range(1, 6);
            }
            else
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomMask);
                roomDetection.GetComponent<RoomType>().RoomDestruction();
                GameObject room = (GameObject)Instantiate(roomsLR[1], transform.position, Quaternion.identity);
                room.transform.parent = grid.transform;
                stopGeneration = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0 && !stopGeneration)
        {
            Debug.Log(direction);
            Move();
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
