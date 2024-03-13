using UnityEngine;

public class enemyZombie : MonoBehaviour
{
    public string tagJugador = "Player";
    public string tagObstaculo = "Obstacle"; // Tag del obstáculo
    public float distanciaMinima = 5f;
    public float velocidadMovimiento = 3f;

    private Transform jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag(tagJugador).transform;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaMinima)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;

            // Raycast para detectar obstáculos
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direccion, out hit, distanciaMinima))
            {
                // Verifica si el objeto detectado tiene la etiqueta de obstáculo
                if (hit.collider.CompareTag(tagObstaculo))
                {
                    // Detiene el movimiento si se detecta un obstáculo
                    return;
                }
            }

            // Mover el enemigo hacia el jugador
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
        }
    }
}

