using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    private int targetsHit = 0;
    public string nextSceneName; // Nombre de la siguiente escena después de completar la misión
    public Camera mainCamera; // Referencia a la cámara principal
    public Camera missionEndCamera; // Referencia a la cámara para el final de la misión

    public void RegisterTargetHit()
    {
        targetsHit++;

        if (targetsHit >= 3)
        {
            // Cambiar a la cámara de fin de misión
            mainCamera.gameObject.SetActive(false);
            missionEndCamera.gameObject.SetActive(true);

            // Esperar un breve tiempo antes de cambiar de escena
            Invoke("ChangeScene", 60f);
        }
    }

    private void ChangeScene()
    {
        // Cambiar a la siguiente escena cuando se han impactado los tres objetivos
        SceneManager.LoadScene(nextSceneName);
    }
}
