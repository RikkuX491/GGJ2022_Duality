using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The Player GameObject
    private GameObject player;

    public GameObject player1;
    public GameObject player2;

    // The difference between the Camera's position and the Player's position
    private Vector3 offset;

    // A variable to be used to stop the Camera from following the Player when the Player reaches a specific x and y position
    // public float stopX;
    public float stopY;
    public float stopXneg;
    public float stopXpos;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMovement.leader == 1)
        {
            player = player1;
        }
        else
        {
            player = player2;
        }
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame. Player moves first, then camera follows
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (PlayerMovement.leader == 1)
            {
                PlayerMovement.leader = 2;
                Player2Movement.leader = 2;
                player = player2;
            }
            else
            {
                PlayerMovement.leader = 1;
                Player2Movement.leader = 1;
                player = player1;
            }            
        }

        if (player.transform.position.y <= stopY)
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
        }
        // Update the position of the Camera so that it follows the Player GameObject
        else
        {
            if(player.transform.position.x <= stopXneg || player.transform.position.x >= stopXpos)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y + offset.y, transform.position.z);
            }
            else transform.position = player.transform.position + offset;
        }
    }
}
