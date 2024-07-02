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

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SetPause();
        }
    }


    public void SetPause()
    {
        if (panelPause.activeSelf == true)
        {
            panelPause.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            panelPause.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void SetHealthBar(float health, float startingHealth)
    {
        BarraDeVida.fillAmount = health / startingHealth;

    }
    public void ShowPanelGameOver()
    {
        panelGameOver.SetActive(true);
        Invoke("ReiniciarEscena", 1.5f);
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reanudar()
    {
        panelPause.SetActive(false);
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
