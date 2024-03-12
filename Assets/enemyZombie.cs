using UnityEngine;

public class enemyZombie : MonoBehaviour
{
    public string tagJugador = "Player"; // Etiqueta del jugador
    public float distanciaMinima = 5f; // Distancia mínima para acercarse al jugador
    public float velocidadMovimiento = 3f; // Velocidad de movimiento hacia el jugador

    private Transform jugador; // Transform del jugador

    void Start()
    {
        // Buscar el jugador por su etiqueta al inicio
        jugador = GameObject.FindGameObjectWithTag(tagJugador).transform;
    }

    void Update()
    {
        // Calcular la distancia entre este objeto y el jugador
        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Si la distancia es menor que la distancia mínima, moverse hacia el jugador
        if (distancia < distanciaMinima)
        {
            // Calcular dirección hacia el jugador
            Vector3 direccion = (jugador.position - transform.position).normalized;

            // Mover este objeto hacia el jugador con velocidad de movimiento
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
        }
    }
}
