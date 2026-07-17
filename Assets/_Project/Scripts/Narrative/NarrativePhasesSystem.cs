using UnityEngine;
using System;


public enum NarrativePhases
{
    Enthusiasm,
    Efficiency,
    Performance,
    Fracture,
    Ending
}


public class NarrativePhasesSystem
{
    NarrativePhases currentPhase;

    public NarrativePhases CurrentPhase { get { return currentPhase; } }

    public event Action<NarrativePhases> OnPhaseChanged;

    public void SetPhase(NarrativePhases newPhase)
    {
        if (newPhase == currentPhase)
        {
            return;
        }

        currentPhase = newPhase;
        OnPhaseChanged?.Invoke(currentPhase);
    }
}