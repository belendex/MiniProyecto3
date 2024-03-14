using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            life vidaPersonaje = other.GetComponent<life>();
            if (vidaPersonaje != null)
            {
                vidaPersonaje.TakeHealth();
            }
        }
    }
}
