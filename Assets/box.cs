using UnityEngine;

public class box : MonoBehaviour
{
    public ParticleSystem sistemaParticulas;
    private bool activado = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!activado && collision.gameObject.CompareTag("bullet"))
        {
            // Activa el sistema de partículas
            sistemaParticulas.Play();
            activado = true;
        }
    }

    // Método para asignar el sistema de partículas por código
    public void AsignarSistemaParticulas(ParticleSystem sistema)
    {
        sistemaParticulas = sistema;
    }

    void Start()
    {
        // Detén el sistema de partículas al inicio
        sistemaParticulas.Stop();

        // Obtén el componente ParticleSystem adjunto al objeto
        ParticleSystem sistema = GetComponent<ParticleSystem>();

        // Asigna el sistema de partículas al script ActivarSistemaParticulas
        AsignarSistemaParticulas(sistema);
    }
}
