using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushed : MonoBehaviour
{
    public Animator animator;
    private bool isDoorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonIsPushed()
    {
          ToggleDoor();
          Debug.Log("Button Pushed");
    }

    void ToggleDoor()
    {
        if (isDoorOpen)
        {
            animator.SetTrigger("CloseDoor");
            isDoorOpen = false;
        }
        else
        {
            animator.SetTrigger("OpenDoor");
            isDoorOpen = true;
        }
    }
}
