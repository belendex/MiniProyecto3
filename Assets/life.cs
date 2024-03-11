using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;
    public bool alive; // para controlar la muerte y los controles
    // Start is called before the first frame update
  
    void Start()
    {
        alive = true;
        currentHealth = startingHealth;
        UIManager.Instance.SetHealthBar(currentHealth, startingHealth);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Takedamage (float damage)
    {
        currentHealth -= damage;
        UIManager.Instance.SetHealthBar(currentHealth, startingHealth);
        if (currentHealth <= 0) { 
            alive = false;

            UIManager.Instance.ShowPanelGameOver();
        }
    }

}
