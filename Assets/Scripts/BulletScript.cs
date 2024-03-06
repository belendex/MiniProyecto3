using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Material redMat;
    public Material greenMat;
    public TasksTutoManager tutoManager;
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
        if(collision.gameObject.CompareTag("TutoObject"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = greenMat;
            if(tutoManager != null)
            {
                tutoManager.task03Complete();
            }
        }
        Destroy(gameObject);
    }
}
