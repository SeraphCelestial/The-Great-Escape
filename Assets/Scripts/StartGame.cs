using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject key;
    public GameObject fakeDoorItem;
    public GameObject upperLock;

    private void Start()
    {
        GameManager.key = key;
        GameManager.fakeDoorItem = fakeDoorItem;
        GameManager.upperLock = upperLock;
        GameManager.noteIsEnabled = false;
        GameManager.keyHasBeenGot = false;
        GameManager.hasUpperLock = false;
        GameManager.hasFakeDoor = false;
        GameManager.exitCanBeOpened = false;
        GameManager.floorDoorPlaced = false;
        DontDestroyOnLoad(key);
        DontDestroyOnLoad(fakeDoorItem);
        DontDestroyOnLoad(upperLock);
        GameManager.inventoryObjects.Clear();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.tag == "Title")
            {
                GameManager.timeLeft = 59;
                SceneManager.LoadScene("StartRoom");
            }
        }
    }
}
