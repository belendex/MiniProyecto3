using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConsolaPuerta : MonoBehaviour
{
    public PlayerController player;
    public Animator door;
    public bool isOpen;
    public bool playerNear;// esta el player cerca?

    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    public void Update()
    {

        if (playerNear == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
            }
            door.SetBool("Open", isOpen);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            playerNear = true;
            //prendo canvas de interaccion 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            playerNear = false;
            //apago canvas de interaccion 
        }
    }

}
