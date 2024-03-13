using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    // Referencia al sistema de partículas
    public GameObject sistemaParticulas;
    
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró en el trigger tiene la etiqueta "bullet"
        if (other.CompareTag("bullet"))
        {
            // Activar el sistema de partículas si está desactivado
            if (!sistemaParticulas.activeSelf)
            {
                
                
                sistemaParticulas.SetActive(true);
            }
        }
    }
}
