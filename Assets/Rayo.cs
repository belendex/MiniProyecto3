using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Rayo : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        life vidaPersonaje = other.GetComponent<life>();
        if (vidaPersonaje != null)
        {
            vidaPersonaje.Takedamage(damage);
        }
    }
}
