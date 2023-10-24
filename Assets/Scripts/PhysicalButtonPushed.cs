using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhysicalButtonPushed : MonoBehaviour
{
    private bool isButtonPushed;
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ButtonIsPushed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonIsPushed()
    {
        particles.SetActive(!particles.activeSelf);
        Debug.Log("Button Pushed");
    }
}
