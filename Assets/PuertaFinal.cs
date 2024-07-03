using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public PlayerController player;
    public Animator door;
    public bool isActive;
    public bool playerNear;// esta el player cerca?
    public bool CanOpen;
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
                if (isActive == false)
                {
                    isActive = true;
                    PuertaFinal[] puertas = FindObjectsOfType<PuertaFinal>();
                    UIManager.Instance.HideTextInteractive();
                    if (isActive == true)
                    {
                        myMaterial.material.color = Color.white;
                        myMaterial.material.SetColor("_EmissionColor", Color.white);
                    }

                    for (int i = 0; i < puertas.Length; i++)
                    {
                        if (puertas[i].isActive == false)
                        {
                            CanOpen = false;


                            for (int j = 0; j < puertas.Length; j++)
                            {
                                if (puertas[j].isActive == true)
                                {
                                    myMaterial.material.color = Color.white;
                                    myMaterial.material.SetColor("_EmissionColor", Color.white);
                                }
                                else
                                {
                                    puertas[j].myMaterial.material.color = Color.red;
                                    puertas[j].myMaterial.material.SetColor("_EmissionColor", Color.red);
                                }
                            }


                            break;
                        }
                        else
                        {
                            for (int j = 0; j < puertas.Length; j++)
                            {

                                puertas[j].myMaterial.material.color = Color.green;
                                puertas[j].myMaterial.material.SetColor("_EmissionColor", Color.green);

                            }
                            CanOpen = true;

                        }
                    }
                }
            }
            door.SetBool("Open", CanOpen);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (isActive == false)
            {
                playerNear = true;
                UIManager.Instance.ShowTextInteractive();
            }
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
