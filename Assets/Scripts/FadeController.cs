using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 2f;
    public string sceneToChange;

    private void Start()
    {
        // Inicia el juego con un fade in
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0)); // De opaco a transparente
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1, true)); // De transparente a opaco
    }

    IEnumerator Fade(float startAlpha, float endAlpha, bool changeScene = false)
    {
        float time = 0;

        Color panelColor = fadePanel.color;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            panelColor.a = alpha;
            fadePanel.color = panelColor;
            yield return null;
        }

        if (changeScene)
        {
            SceneManager.LoadScene(sceneToChange);
        }
    }
}