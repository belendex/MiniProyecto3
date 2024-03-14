using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformsFinals : MonoBehaviour
{
    public bool isBroken = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken == true && collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
