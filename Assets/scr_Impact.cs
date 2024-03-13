using UnityEngine;

public class ChildCollisionHandler : MonoBehaviour
{
    public GameObject particleSystemObject; // Referencia al sistema de partículas
    public float delayAfterBulletCollision = 2f; // Retraso después de recibir una colisión de bala
    public float vibrationIntensity = 0.5f; // Intensidad de la vibración en rotate
    private float delayTimer = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            // Activar el sistema de partículas
            particleSystemObject.SetActive(true);

            // Aplicar un retraso en el movimiento del objeto
            delayTimer = delayAfterBulletCollision;

            // Añadir vibración al objeto
            transform.parent.Rotate(Random.insideUnitSphere * vibrationIntensity);
        }
    }

    void Update()
    {
        // Si hay un retraso, disminuir el temporizador
        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
        }
        else
        {
            // Desactivar el sistema de partículas después del retraso
            particleSystemObject.SetActive(false);
        }
    }
}
