using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image BarraDeVida;
    public static UIManager Instance;
    public GameObject panelGameOver;
    public GameObject panelPause;
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
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(panelPause.activeSelf == true)
            {
                panelPause.gameObject.SetActive(false);
            }
            else
            {
                panelPause.gameObject.SetActive(true);
            }
        }
    }
    public void SetHealthBar(float health, float startingHealth)
    {
        BarraDeVida.fillAmount = health/startingHealth;

    }
    public void ShowPanelGameOver() { 
     panelGameOver.SetActive(true);
    
    }

    public void Reanudar()
    {
        Debug.Log("rea");
        panelPause.SetActive(false);
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
