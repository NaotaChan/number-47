using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI; 
using System.Collections.Generic;

public class ResponseManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup responseCanvasGroup; 

    [SerializeField]
    private Button[] buttons;

    public void SetButtons(IReadOnlyList<CustomerResponse> responses)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = responses[i].text;
        }
    }

    public IEnumerator FadeIn()
    {
        responseCanvasGroup.alpha = 0;
        responseCanvasGroup.gameObject.SetActive(true);
        while (responseCanvasGroup.alpha < 1)
        {
            responseCanvasGroup.alpha += Time.deltaTime * 2f; 
            yield return null;
        }
    }

    public void Hide() 
    {
        responseCanvasGroup.alpha = 0;
        responseCanvasGroup.gameObject.SetActive(false);
    }

}
