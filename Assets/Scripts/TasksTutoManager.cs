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
    private string task05 = "Sal del campo de tiro";

    //TASKS DIALOGUE
    private string taskDialogue01 = "Soldado este es el campo de tiro, arriba tiene un panel que le irá guiando. ¡NO HAGA EL RIDÍCULO SOLDADO!";
    private string taskDialogue02 = "Ha finalizado el entrenamiento, salga de aquí y prepárese para el despliegue. Recuerda, ¡el mundo le obseva!";

    public TextMeshProUGUI tasksTexts;
    public TextMeshProUGUI dialogueText;
    public MeshRenderer[] objetives;
    public Material hitMaterial;
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
        bool isAllHit = false;
        foreach(MeshRenderer i in objetives)
        {
            if(i.sharedMaterial == hitMaterial)
            {
                isAllHit = true;
            }
            else
            {
                isAllHit = false;
            }
        }

        if(isAllHit)
        {
            tasksTexts.text = "";
            StartCoroutine(SetTaskText(task04));
        }

    }
}
