using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Material redMat;
    public Material greenMat;
    public TasksTutoManager tutoManager;
    public string tipoArma;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        tutoManager = GameObject.FindFirstObjectByType<TasksTutoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {   
        Debug.Log("colisioné con:"+collision.gameObject.name);
        Debug.Log("pos Bala " + transform.position);
        if(collision.gameObject.CompareTag("TutoObject"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = greenMat;
            if(tutoManager != null)
            {
                if(tipoArma == "Pistol")
                {
                    tutoManager.task03Complete();
                }
                else if (tipoArma=="Rifle")
                {
                    tutoManager.task06Complete();
                }
            }
        }

        Destroy(gameObject);



    }
}
