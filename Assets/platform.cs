using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;
    public float delayBeforeNextPoint = 1f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        // Al iniciar, establecemos el punto de destino inicial
        targetPosition = pointA.position;
    }

    void Update()
    {
        if (isMoving)
        {
            // Movemos la plataforma hacia el punto de destino
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Si la plataforma llega al punto de destino, cambiamos al siguiente punto
            if (transform.position == targetPosition)
            {
                // Aplicamos un retraso antes de moverse al siguiente punto
                isMoving = false;
                Invoke("ChangeTarget", delayBeforeNextPoint);
            }
        }
    }

    void ChangeTarget()
    {
        // Cambiamos el punto de destino
        targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        isMoving = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto que colisiona es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            // Convertimos al jugador en hijo de la plataforma
            collision.collider.transform.SetParent(transform);
            isMoving = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificamos si el objeto que sale de la colisión es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            // Liberamos al jugador de ser hijo de la plataforma
            collision.collider.transform.SetParent(null);
        }
    }
}

