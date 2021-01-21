using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankRoomChecker : MonoBehaviour
{
    public GameObject fakeDoor;
    public GameObject floorDoor;

    private void Update()
    {
        if (GameManager.hasFakeDoor == true)
        {
            GameManager.fakeDoor = fakeDoor;
            GameManager.floorDoor = floorDoor;
            GameManager.fakeDoor.SetActive(false);
            if (GameManager.floorDoorPlaced == true)
            {
                GameManager.floorDoor.transform.position = new Vector3(-3.99f, -3.222f, -1);
                if (GameManager.hasUpperLock == true)
                {
                    GameManager.floorDoor.SetActive(false);
                    this.gameObject.SetActive(false);
                    GameManager.hasFakeDoor = false;
                }
                this.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }
}
