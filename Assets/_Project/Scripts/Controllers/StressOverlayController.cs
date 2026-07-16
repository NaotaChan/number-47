using System;
using UnityEngine;
using UnityEngine.UI;

public class StressOverlayController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    Image panelStressOverlay;

    [SerializeField]
    GameManager gameManager;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetOverlayAlpha();

        gameManager.MentalStateSystem.OnStressValueChanged += UpdateOverlayAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateOverlayAlpha(int stressValue)
    {
        Color c = panelStressOverlay.color;
        c.a = (float)stressValue / 100;
        panelStressOverlay.color = c;
    }

    void ResetOverlayAlpha()
    {
        Color c = panelStressOverlay.color;  
        c.a = 0;                              
        panelStressOverlay.color = c; 
    }
}
