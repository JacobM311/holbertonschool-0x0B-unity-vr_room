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
    public GameObject Vignette;
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
        targetPosition.y = menu.transform.position.y;

        menu.transform.position = Vector3.Lerp(menu.transform.position, targetPosition, Time.deltaTime * menuMoveSpeed);

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
    }

}
