using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePersonaje : MonoBehaviour
{
    
    public GameObject pantallaGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void EncenderPanel(){

        pantallaGameOver.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EncenderPanel();
            StartCoroutine(Esperar());

        }

    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
