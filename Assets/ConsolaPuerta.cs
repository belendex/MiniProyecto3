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
    public Renderer myMaterial;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myMaterial.material.EnableKeyword("_EMISSION");

    }
    public void Update()
    {

        if (playerNear == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                if (isOpen == true)
                {
                    myMaterial.material.color = Color.green;
                    myMaterial.material.SetColor("_EmissionColor", Color.green);
                }
                else
                {
                    myMaterial.material.color = Color.red;
                    myMaterial.material.SetColor("_EmissionColor", Color.red);
                }
            }

            door.SetBool("Open", isOpen);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            playerNear = true;
            UIManager.Instance.ShowTextInteractive();

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            playerNear = false;
            UIManager.Instance.HideTextInteractive();
        }
    }

}
