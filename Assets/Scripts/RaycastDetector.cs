using TMPro;
using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    public Camera playerCamera;
    public Transform gunRoot;
    public float raycastDistance = 3;

    public TextMeshProUGUI textObject;
    public TextMeshProUGUI subtitle;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    public TasksTutoManager tutoManager;
    public PlayerController playerController;
    [SerializeField] private GameObject weapons;

    private void Update()
    {
        // Lanzar un raycast desde la cámara en la dirección en la que se está mirando
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * raycastDistance, Color.green);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance) && hit.collider.gameObject.GetComponent<InteractableItem>())
        {
            InteractableItem hitInteractable = hit.collider.gameObject.GetComponent<InteractableItem>();
            MissionScript hitMission = hit.collider.gameObject.GetComponent<MissionScript>();

            if (hitInteractable.item == InteractableItem.typeItem.Gun)
            {
                textObject.text = "Press " + interactKey + " to take a pistol";
                
                if (Input.GetKeyDown(interactKey))
                {
                    

                    if (hitInteractable.ObjetoEncendido != null)
                    {
                        hitInteractable.ObjetoEncendido.SetActive(true);
                        FindObjectOfType<WeaponManager>().inactive = false;
                        playerController.isReadyToFire = true;

                    }
                    else
                    {
                        Debug.LogError("no tengo objeto que encender");
                    }


                    if (hitMission != null && hitMission.isTuto && hitMission.ourTask == MissionScript.tasks.task02 && hitMission.isReady)
                    {
                        tutoManager.task02Complete();
                        hitMission.isReady = false;
                    }
                    else if (hitMission != null && hitMission.isTuto && hitMission.ourTask == MissionScript.tasks.task05 && hitMission.isReady)
                    {
                        tutoManager.task05Complete();
                        hitMission.isReady = false;
                    }
                    weapons.SetActive(false);

                }

            }
            else if(hitInteractable.item == InteractableItem.typeItem.SoldierTuto)
            {
                if(hitMission.isReady)
                {
                    textObject.text = "Press " + interactKey + " to speak with sargeant";
                }

                if (Input.GetKeyDown(interactKey))
                {
                    if (hitMission != null && hitMission.isTuto && hitMission.ourTask == MissionScript.tasks.task01 && hitMission.isReady)
                    {
                        tutoManager.task01Complete();
                        hitMission.isReady = false;
                        weapons.SetActive(true); 
                    }
                    else if (hitMission != null && hitMission.isTuto && hitMission.ourTask == MissionScript.tasks.task04 && hitMission.isReady)
                    {
                        tutoManager.task05Complete();
                        hitMission.isReady = false;
                    }
                    else if (hitMission != null && hitMission.isTuto && hitMission.ourTask == MissionScript.tasks.task07 && hitMission.isReady)
                    {
                        tutoManager.task07Complete();
                        hitMission.isReady = false;
                    }
                }
            }
        }
        
        else
        {
            textObject.text = "";
        }
    }
}
