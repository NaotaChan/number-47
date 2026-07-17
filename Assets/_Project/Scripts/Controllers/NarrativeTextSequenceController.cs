using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class NarrativeTextSequenceController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    CanvasGroup textCanvasGroup;

    [SerializeField]
    TextMeshProUGUI sequenceText;

    [Header("Sequence Content")]
    [SerializeField]
    List<string> textSequence = new List<string>();

    [Header("Timing")]
    [SerializeField]
    float fadeDuration = 1f;

    [SerializeField]
    float holdDuration = 2f;

    [SerializeField]
    float normalTypingSpeed = 0.05f;

    [SerializeField]
    float fastTypingSpeed = 0.01f;

    [Header("Next Scene")]
    [SerializeField]
    string nextSceneName;

    bool isSpeedingUp = false;

    void Start()
    {
        textCanvasGroup.alpha = 1f;
        sequenceText.text = "";
        StartCoroutine(PlaySequence());
    }

    void Update()
    {
        isSpeedingUp = Input.GetMouseButton(0);
    }

    IEnumerator PlaySequence()
    {
        foreach (string text in textSequence)
        {
            textCanvasGroup.alpha = 1f;
            yield return StartCoroutine(TypeText(text));
            yield return new WaitForSeconds(holdDuration);
            yield return StartCoroutine(FadeCanvasGroup(1f, 0f, fadeDuration));
        }

        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator TypeText(string text)
    {
        sequenceText.text = "";
        foreach (char c in text)
        {
            sequenceText.text += c;
            yield return new WaitForSeconds(isSpeedingUp ? fastTypingSpeed : normalTypingSpeed);
        }
    }

    IEnumerator FadeCanvasGroup(float from, float to, float duration)
    {
        float elapsed = 0f;
        textCanvasGroup.alpha = from;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            textCanvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        textCanvasGroup.alpha = to;
    }
}