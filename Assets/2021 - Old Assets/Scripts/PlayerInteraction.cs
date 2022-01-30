using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{

    // Is the character holding an item?
    private bool isHoldingItem = false;
    private GameObject item;

    public GameObject sunStone;
    public GameObject moonStone;
    public GameObject demonTreeLeft;
    public GameObject demonTreeRight;
    public GameObject bridgeRoad;
    public GameObject leftBridgeEdge;

    public bool interaction1Complete = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interaction1Complete)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Z) && isHoldingItem)
        {
            item.SetActive(true);
            isHoldingItem = false;
            if (sunStone.activeInHierarchy)
            {
                demonTreeLeft.SetActive(false);
            }
            if (moonStone.activeInHierarchy)
            {
                demonTreeRight.SetActive(false);
            }
        }
        
        if (!sunStone.activeInHierarchy && !moonStone.activeInHierarchy)
        {
            demonTreeLeft.SetActive(false);
            demonTreeRight.SetActive(false);
            bridgeRoad.SetActive(true);
            leftBridgeEdge.transform.position = new Vector3(leftBridgeEdge.transform.position.x - 1.5f, leftBridgeEdge.transform.position.y, leftBridgeEdge.transform.position.z);
            interaction1Complete = true;
}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the Player collides with the Sun Stone
        if (collision.gameObject.CompareTag("Sun Stone") && !isHoldingItem)
        {
            item = collision.gameObject;
            collision.gameObject.SetActive(false);
            isHoldingItem = true;
            demonTreeLeft.SetActive(true);
        }
        if(collision.gameObject.CompareTag("Moon Stone") && !isHoldingItem)
        {
            item = collision.gameObject;
            collision.gameObject.SetActive(false);
            isHoldingItem = true;
            demonTreeRight.SetActive(true);
        }

        // If the Player has reached the end of Scene 1
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(1);
        }
    }
    
}
