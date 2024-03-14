using UnityEngine;
using UnityEngine.SceneManagement;

public class scr : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC; // Nuevo punto de destino
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    public float rotationSpeed = 90f; // Velocidad de rotación en grados por segundo
    public float delayBeforeNextPoint = 1f; // Retraso antes de moverse al siguiente punto
    private bool canMove = true;
    
    
    
    private Vector3 targetPosition;
    private float currentSpeed = 0f;
    private float delayTimer = 0f;
    private Quaternion targetRotation;

    void Start()
    {
        // Al iniciar, establecemos targetPosition en la posición inicial del punto A
        targetPosition = pointA.position;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if(canMove)
        {
            // Si hay un retraso, disminuir el temporizador
            if (delayTimer > 0f)
            {
                delayTimer -= Time.deltaTime;
                return;
            }

            // Calculamos la dirección y la distancia hacia el punto de destino
            Vector3 direction = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);

            // Aplicamos aceleración
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            // Movemos el objeto hacia el punto de destino a la velocidad actual
            transform.position += direction * currentSpeed * Time.deltaTime;

            // Si el objeto llega al punto de destino, cambiamos al siguiente punto
            if (distance < 0.1f)
            {
                // Aplicar retraso antes de moverse al siguiente punto
                delayTimer = delayBeforeNextPoint;

                if (targetPosition == pointA.position)
                {
                    targetPosition = pointB.position;
                }
                else if (targetPosition == pointB.position)
                {
                    targetPosition = pointC.position; // Cambio a la parada C
                }
                else
                {
                    targetPosition = pointA.position;
                }
                currentSpeed = 0f; // Reiniciamos la velocidad al cambiar de dirección

                // Actualizamos la rotación hacia el nuevo punto de destino
                Vector3 newDirection = (targetPosition - transform.position).normalized;
                targetRotation = Quaternion.LookRotation(newDirection, Vector3.up);
            }

            // Rotamos gradualmente el objeto hacia el punto de destino
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void FallDrone()
    {
        canMove = false;
        transform.position = pointA.position;
        transform.rotation = new Quaternion(0, 180, 0, 0);
        Animation animation = GetComponent<Animation>();
        animation.Play();

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("tuto 1");
    }

    
}