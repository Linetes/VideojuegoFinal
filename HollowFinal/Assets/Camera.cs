using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.position.x <= -12)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (player.position.x >= 19)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        
    }
}
