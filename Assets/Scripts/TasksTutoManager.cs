using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksTutoManager : MonoBehaviour
{
    //TASKS TEXTS
    private string task01 = "Habla con el sargento de campo";
    private string task02 = "Recoge tu arma del mostrador";
    private string task03 = "Elimina todos los objetivos";
    private string task04 = "Habla con el sargento de nuevo";
    private string task06 = "Vuelve a destruir todos los objetivos con tu otra arma";
    private string task07 = "Habla con el sargento para acabar";
    private string task08 = "Sal del campo de tiro";

    //TASKS DIALOGUE
    private string taskDialogue01 = "Soldado este es el campo de tiro, arriba tiene un panel que le irá guiando. ¡NO HAGA EL RIDÍCULO SOLDADO!";
    private string taskDialogue02 = "Muy bien, ahora prueba con esta otra arma. Tiene mas cadencia pero menos precisión. Prueba a apuntar";
    private string taskDialogue03 = "Ha finalizado el entrenamiento, salga de aquí y prepárese para el despliegue. Recuerda, ¡el mundo le obseva!";

    public TextMeshProUGUI tasksTexts;
    public TextMeshProUGUI dialogueText;
    public MeshRenderer[] objetives;
    public Material hitMaterial;
    public Material noHitMaterial;
    public GameObject buttonExit;

    [SerializeField] private MissionScript soldierTutoMission;
    // Start is called before the first frame update
    void Start()
    {
        tasksTexts.text = "";
        StartCoroutine(SetTaskText(task01));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetTaskText(string text)
    {
        tasksTexts.text = "";

        foreach (char c in text)
        {
            tasksTexts.text = tasksTexts.text + c;

            // Wait for a short time before displaying the next character
            yield return new WaitForSeconds(0.1f); // Adjust the time as needed
        }
    }
    IEnumerator SetDialogueText(string text)
    {
        foreach (char c in text)
        {
            dialogueText.text += c;

            // Wait for a short time before displaying the next character
            yield return new WaitForSeconds(0.1f); // Adjust the time as needed
        }
        yield return new WaitForSeconds(4f);
        dialogueText.text = "";
    }

    public void task01Complete()
    {
        tasksTexts.text = "";
        StartCoroutine(SetDialogueText(taskDialogue01));
        StartCoroutine(SetTaskText(task02));
    }

    public void task02Complete()
    {
        tasksTexts.text = "";
        StartCoroutine(SetTaskText(task03));

    }

    public void task03Complete()
    {
        foreach(MeshRenderer i in objetives)
        {
            if(i.sharedMaterial != hitMaterial)
            {
                return;
            }
        }
        tasksTexts.text = "";
        soldierTutoMission.ourTask = MissionScript.tasks.task04;
        soldierTutoMission.isReady = true;
        StopCoroutine(SetTaskText(task04));
        


    }

    public void task05Complete()
    {
        foreach (MeshRenderer i in objetives)
        {
            i.material = noHitMaterial;
        }

        tasksTexts.text = "";
        StartCoroutine(SetTaskText(task06));
        StartCoroutine(SetDialogueText(taskDialogue02));

    }

    public void task06Complete()
    {
        foreach (MeshRenderer i in objetives)
        {
            if (i.sharedMaterial != hitMaterial)
            {
                return;
            }
        }

        tasksTexts.text = "";
        soldierTutoMission.ourTask = MissionScript.tasks.task07;
        soldierTutoMission.isReady = true;
        StopCoroutine(SetTaskText(task07));
        StartCoroutine(SetTaskText(task07));
    }

    public void task07Complete()
    {
        tasksTexts.text = "";
        StartCoroutine(SetTaskText(task08));
        StartCoroutine(SetDialogueText(taskDialogue03));
        buttonExit.SetActive(true);
    }
}
