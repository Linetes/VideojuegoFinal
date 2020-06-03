using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGenerator : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject player;
    public GameObject[] rooms;
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
        Debug.Log(randStartingPos);
        transform.position = new Vector2(startingPositions[randStartingPos].position.x, startingPositions[randStartingPos].position.y);
        GameObject startRoom = (GameObject)Instantiate(rooms[0], transform.position, Quaternion.identity);
        startRoom.transform.parent = grid.transform;
        player.transform.position = new Vector2(transform.position.x, transform.position.y);

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

                int rand = Random.Range(0, rooms.Length);
                GameObject room = (GameObject)Instantiate(rooms[rand], transform.position, Quaternion.identity);

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

                int rand = Random.Range(0, rooms.Length);
                GameObject room = (GameObject)Instantiate(rooms[rand], transform.position, Quaternion.identity);

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
            downCounter++;
            if(transform.position.y > minY)
            {
                Debug.Log(roomMask);
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomMask);
                if(roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        GameObject room = (GameObject)Instantiate(rooms[3], transform.position, Quaternion.identity);
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
                        GameObject room = (GameObject)Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);

                        room.transform.parent = grid.transform;
                    }

                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountY);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                GameObject room2 = (GameObject)Instantiate(rooms[rand], transform.position, Quaternion.identity);

                room2.transform.parent = grid.transform;

                direction = Random.Range(1, 6);
            }
            else
            {
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
