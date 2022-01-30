using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The Player GameObject
    public GameObject player;

    // The difference between the Camera's position and the Player's position
    private Vector3 offset;

    // A variable to be used to stop the Camera from following the Player when the Player reaches a specific x and y position
    // public float stopX;
    public float stopY;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame. Player moves first, then camera follows
    void LateUpdate()
    {
        if (player.transform.position.y <= stopY)
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
        }
        // Update the position of the Camera so that it follows the Player GameObject
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
