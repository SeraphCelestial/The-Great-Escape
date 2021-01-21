using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectMouseOver : MonoBehaviour
{
    public GameObject note;
    public GameObject inventory;
    public GameObject exitUpperLock;
    public Text Timer;

    private void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.Find(gameObject.name) && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
        if (GameManager.noteIsEnabled == true)
        {
            note.SetActive(false);
        }
        if (GameManager.exitCanBeOpened == true)
        {
            exitUpperLock = GameObject.FindGameObjectWithTag("Exit Upper Lock");
            exitUpperLock.transform.position = new Vector3(2.174f, 0.576f, -1);
        }
        if (GameManager.invToggle == true)
        {
            GameManager.isOpen = true;
            foreach (GameObject i in GameManager.inventoryObjects)
            {
                i.SetActive(true);
            }
            inventory.transform.position = new Vector3(-3.84f, -3.67f, -6);
        }
        else
        {
            GameManager.isOpen = false;
            foreach (GameObject i in GameManager.inventoryObjects)
            {
                i.SetActive(false);
            }
            inventory.transform.position = new Vector3(-3.84f, -5.71f, -6);
        }
    }
    private void Update()
    {
        GameManager.timeLeft -= Time.deltaTime;
        Timer.text = "00 " + (GameManager.timeLeft).ToString("0");
        if (GameManager.timeLeft <= 9.49)
        {
            Timer.text = "00 0" + (GameManager.timeLeft).ToString("0");
        }
        if (GameManager.timeLeft <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
            this.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.tag == "Inventory")
            {
                GameManager.invToggle = !GameManager.invToggle;
                if (GameManager.invToggle == true)
                {
                    GameManager.isOpen = true;
                    foreach (GameObject i in GameManager.inventoryObjects)
                    {
                        i.SetActive(true);
                    }
                    inventory.transform.position = new Vector3(-3.84f, -3.67f, -6);
                }
                else
                {
                    GameManager.isOpen = false;
                    foreach (GameObject i in GameManager.inventoryObjects)
                    {
                        i.SetActive(false);
                    }
                    inventory.transform.position = new Vector3(-3.84f, -5.71f, -6);
                }
            }
            else if (hit.collider.tag == "BlankEntrance")
            {
                SceneManager.LoadScene("BlankRoom");
            }
            else if (hit.collider.tag == "StartEntrance")
            {
                SceneManager.LoadScene("StartRoom");
            }
            else if (hit.collider.tag == "ClockLeftEntrance")
            {
                SceneManager.LoadScene("ClockRoomLeft");
            }
            else if (hit.collider.tag == "ClockRightEntrance")
            {
                SceneManager.LoadScene("ClockRoomRight");
            }
            else if (hit.collider.tag == "WindowEntrance")
            {
                SceneManager.LoadScene("WindowRoom");
            }
            else if (hit.collider.tag == "Note")
            {
                GameManager.inventoryObjects.Add(GameManager.key);
                if (GameManager.isOpen == true)
                {
                    GameManager.key.SetActive(true);
                }
                else
                {
                    GameManager.key.SetActive(false);
                }
                GameManager.noteIsEnabled = true;
                GameManager.keyHasBeenGot = true;
                note.SetActive(false);
            }
            else if (hit.collider.tag == "Fake Door")
            {
                GameManager.fakeDoor = GameObject.FindGameObjectWithTag("Fake Door");
                GameManager.inventoryObjects.Add(GameManager.fakeDoorItem);
                if (GameManager.isOpen == true)
                {
                    GameManager.fakeDoorItem.SetActive(true);
                }
                else
                {
                    GameManager.fakeDoorItem.SetActive(false);
                }
                GameManager.fakeDoor.SetActive(false);
                GameManager.hasFakeDoor = true;
            }
            else if (hit.collider.tag == "Door Markings")
            {
                if (GameManager.hasFakeDoor == true)
                {
                    GameManager.floorDoor = GameObject.FindGameObjectWithTag("Floor Door");
                    GameManager.floorDoor.transform.position = new Vector3(-3.99f, -3.222f, -1);
                    GameManager.inventoryObjects.Remove(GameManager.fakeDoorItem);
                    GameManager.fakeDoorItem.SetActive(false);
                    GameManager.floorDoorPlaced = true;
                }
            }
            else if (hit.collider.tag == "Floor Door")
            {
                GameManager.floorDoor.SetActive(false);
                GameManager.inventoryObjects.Add(GameManager.upperLock);
                if (GameManager.isOpen == true)
                {
                    GameManager.upperLock.SetActive(true);
                }
                else
                {
                    GameManager.upperLock.SetActive(false);
                }
                GameManager.hasUpperLock = true;
            }
            else if (hit.collider.tag == "Exit")
            {
                if (GameManager.hasUpperLock == true)
                {
                    exitUpperLock = GameObject.FindGameObjectWithTag("Exit Upper Lock");
                    exitUpperLock.transform.position = new Vector3(2.174f, 0.576f, -1);
                    GameManager.inventoryObjects.Remove(GameManager.upperLock);
                    GameManager.upperLock.SetActive(false);
                    GameManager.hasUpperLock = false;
                    GameManager.exitCanBeOpened = true;
                }
                else if (GameManager.exitCanBeOpened == true && GameManager.keyHasBeenGot == true)
                {
                    GameManager.inventoryObjects.Remove(GameManager.key);
                    GameManager.key.SetActive(false);
                    SceneManager.LoadScene("WinScreen");
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
