using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Menu : MonoBehaviour
{
    public InputActionProperty pauseButton;
    bool paused = false;
    public List<GameObject> objectsToDisable = new List<GameObject>();
    public List<GameObject> objectsToEnable = new List<GameObject>();

    public List<GameObject> teleportationObjects = new List<GameObject>();
    public List<GameObject> continuousObjects = new List<GameObject>();
    public GameObject menu;
    public Transform playerHead;
    public float spawnDistance = 1;
    public float menuMoveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.action.performed += OnPauseButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = playerHead.position + playerHead.forward.normalized * spawnDistance;
        targetPosition.y = menu.transform.position.y; // Keep the same height as the player's head.

        // Use Lerp to smoothly interpolate between the current position and the target position.
        menu.transform.position = Vector3.Lerp(menu.transform.position, targetPosition, Time.deltaTime * menuMoveSpeed);

        // Look at the player's head position.
        menu.transform.LookAt(new Vector3(playerHead.position.x, menu.transform.position.y, playerHead.position.z));
        menu.transform.forward *= -1;
    }

    private void OnPauseButtonPressed(InputAction.CallbackContext context)
    {
        paused = !paused;

        if (paused)
        {
            foreach (var obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
            foreach (var obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
            menu.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("PAUSED");
        }
        else
        {
            foreach (var obj in objectsToDisable)
            {
                obj.SetActive(true);
            }
            foreach (var obj in objectsToEnable)
            {
                obj.SetActive(false);
            }
            menu.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("UNPAUSED");
        }
    }

    public void TurnOnTeleportation()
    {
        foreach (var obj in teleportationObjects)
        {
            obj.SetActive(true);
        }
        foreach (var obj in continuousObjects)
        {
            obj.SetActive(false);
        }
        Debug.Log("tele on");
    }

    public void TurnOnContinuous()
    {
        foreach (var obj in continuousObjects)
        { 
            obj.SetActive(true);
        }
        foreach (var obj in teleportationObjects)
        {
            obj.SetActive(false);
        }
        Debug.Log("cont on");
    }
}
