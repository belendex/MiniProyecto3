using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{ 
    public int damage;
    private AudioSource Asource;
    public AudioClip Droneclip;

    // Start is called before the first frame update
    void Start()
    {
        Asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Asource.PlayOneShot(Droneclip);
            other.GetComponent<life>().Takedamage(damage);


        }
    }
}
