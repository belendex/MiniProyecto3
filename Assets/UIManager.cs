using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image BarraDeVida;
    public static UIManager Instance;
    public GameObject panelGameOver;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealthBar(float health, float startingHealth)
    {
        BarraDeVida.fillAmount = health/startingHealth;

    }
    public void ShowPanelGameOver() { 
     panelGameOver.SetActive(true);
    
    }
    
}
