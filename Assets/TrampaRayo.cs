using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaRayo : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    public Vector2 offsetSpeed;
    public Vector2 offset;

    public float timeAttack;
    public float timeWaiting;
    public GameObject laser;
    void Start()
    {
        offset = material.GetTextureOffset("_MainTex");
        StartCoroutine(Attack());

    }

    // Update is called once per frame
    void Update()
    {
        offset += offsetSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(timeWaiting);
        laser.SetActive(false);

        yield return new WaitForSeconds(timeAttack);
        laser.SetActive(true);
        StartCoroutine(Attack());
    }


}
