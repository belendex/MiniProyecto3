using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float cadencia;
    public float damage;

    public Transform firePoint; // Punto de disparo
    public GameObject bulletPrefab; // Prefab de la bala
    public int bulletSpeed = 50;

    //SETTINGS PARA HACERG EL ZOOM
    public CinemachineVirtualCamera virtualCamera;
    public float normalFOV = 45f; // FOV normal
    public float changedFOV = 30f; // FOV cuando se presiona el control
    public float lerpTime = .8f; // Tiempo para alcanzar el FOV cambiado
    private float currentLerpTime;

    [SerializeField] private GameObject gunRoot;
    private float tiempoTranscurrido = 0f;
    public enum typeweapon
    {
        Pistol,
        Rifle,
    }
    public typeweapon type;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {

            OnFire();

        }
        Zoom();
    }

    public void OnFire()
    {
        if (tiempoTranscurrido >= this.cadencia)
        {
            tiempoTranscurrido = 0;
            Debug.DrawLine(firePoint.position, firePoint.forward * 10f, Color.red);
            Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * 10f, Color.blue);
            RaycastHit cameraHit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
            {
                Vector3 shootDirection = cameraHit.point - firePoint.position;
                firePoint.rotation = Quaternion.LookRotation(shootDirection);

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
                bullet.GetComponent<BulletScript>().tipoArma = this.type.ToString();
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
            }
        }

    }

    private void Zoom()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Incrementa el tiempo de interpolación
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            // Cambia el FOV suavemente hacia el valor deseado
            float fov = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, changedFOV, currentLerpTime / lerpTime);
            virtualCamera.m_Lens.FieldOfView = fov;
        }
        else
        {
            // Restablece el tiempo de interpolación
            currentLerpTime = 0f;

            // Vuelve al FOV normal suavemente
            float fov = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, normalFOV, Time.deltaTime * lerpTime * 2);
            virtualCamera.m_Lens.FieldOfView = fov;
        }
    }
}
