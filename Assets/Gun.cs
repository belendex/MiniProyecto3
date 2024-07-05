using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform firePoint; // Punto de disparo
    public GameObject bulletPrefab; // Prefab de la bala
    public int bulletSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            OnFire();

        }
    }

    public void OnFire()
    {
        Debug.Log("entra");



        // Update is called once per frame
        Debug.DrawLine(firePoint.position, firePoint.forward * 10f, Color.red);
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * 10f, Color.blue);
        RaycastHit cameraHit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
        {
            Vector3 shootDirection = cameraHit.point - firePoint.position;
            firePoint.rotation = Quaternion.LookRotation(shootDirection);

            /*float spreadAmount = 0.25f;
            shootDirection.x += Random.Range(-spreadAmount, spreadAmount);
            shootDirection.y += Random.Range(-spreadAmount, spreadAmount);
            shootDirection.z += Random.Range(-spreadAmount, spreadAmount);*/
            // -
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
        }

    }
}