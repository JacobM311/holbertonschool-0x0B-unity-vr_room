using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vignette : MonoBehaviour
{
    public InputActionProperty leftJoyStick;  

    // Start is called before the first frame update
    void Start()
    {
        leftJoyStick.action.performed += joystickMoved;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void joystickMoved(InputAction.CallbackContext context)
    {
        
    }
}
