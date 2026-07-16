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

    const float minRadius = -0.2f;
    const float maxRadius = 0.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetOverlayRadius();

        gameManager.MentalStateSystem.OnStressValueChanged += UpdateOverlayRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateOverlayRadius(int stressValue)
    {
        float radius = minRadius + ((float)stressValue / 100) * (maxRadius - minRadius);
        panelStressOverlay.material.SetFloat("_CleanRadius", radius);
    }

    void ResetOverlayRadius()
    {
        panelStressOverlay.material.SetFloat("_CleanRadius", minRadius);
    }
}