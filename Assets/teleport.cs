using UnityEngine;

public class TP : MonoBehaviour
{
    public Transform destination; // Objeto de destino donde se teletransportará el jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que ha entrado en el collider es el jugador
        {
            TeleportPlayer(other.gameObject); // Llama a la función para teletransportar al jugador
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = destination.position; // Teleporta al jugador a la posición del objeto de destino
        // Aquí puedes añadir efectos de sonido, partículas, animaciones, etc., para mejorar la experiencia de teleportación
    }
}
