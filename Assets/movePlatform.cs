using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    private Vector3 targetPosition;
    private float currentSpeed = 0f;
    private bool shouldMove = false;

    void Start()
    {
        targetPosition = pointB.position;
    }

    void Update()
    {
        if (shouldMove)
        {
            // Calcula la dirección y la distancia hacia el punto de destino
            Vector3 direction = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);

            // Aplica aceleración
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            // Mueve el objeto hacia el punto de destino a la velocidad actual
            transform.position += direction * currentSpeed * Time.deltaTime;

            // Si el objeto llega al punto de destino, cambia al siguiente punto
            if (distance < 0.1f)
            {
                if (targetPosition == pointA.position)
                {
                    targetPosition = pointB.position;
                }
                else
                {
                    targetPosition = pointA.position;
                }
                currentSpeed = 0f; // Reinicia la velocidad al cambiar de dirección
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider activador ha sido tocado
        if (other.gameObject.CompareTag("ActivatorObject"))
        {
            shouldMove = true;
        }
    }
}