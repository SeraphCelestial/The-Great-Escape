using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float timeLeft;
    public static bool noteIsEnabled;
    public static bool keyHasBeenGot = false;
    public static bool hasUpperLock = false;
    public static bool hasFakeDoor = false;
    public static bool exitCanBeOpened = false;
    public static bool invToggle = false;
    public static bool isOpen = false;
    public static bool floorDoorPlaced = false;
    public static GameObject key;
    public static GameObject fakeDoorItem;
    public static GameObject upperLock;
    public static GameObject fakeDoor;
    public static GameObject fakeDoorImprint;
    public static GameObject floorDoor;
    public static List<GameObject> inventoryObjects = new List<GameObject>();
}
