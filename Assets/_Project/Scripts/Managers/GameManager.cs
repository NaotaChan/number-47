using UnityEngine;

public class GameManager : MonoBehaviour
{
    MentalStateSystem mentalStateSystem = new MentalStateSystem();
    NarrativePhasesSystem narrativePhaseSystem = new NarrativePhasesSystem();

    public MentalStateSystem MentalStateSystem { get { return mentalStateSystem; } }
    public NarrativePhasesSystem NarrativePhaseSystem { get { return narrativePhaseSystem; } }

    void Awake()
    {
        mentalStateSystem.OnMentalStateChanged += HandleMentalStateChanged;

        mentalStateSystem.UpdateMentalState();
        narrativePhaseSystem.SetPhase(NarrativePhases.Enthusiasm);
    }

    void HandleMentalStateChanged(MentalStates newState)
    {
        NarrativePhases mappedPhase = MapMentalStateToPhase(newState);
        narrativePhaseSystem.SetPhase(mappedPhase);
        Debug.Log($"Stato mentale: {newState} → Fase narrativa: {mappedPhase}");
    }

    NarrativePhases MapMentalStateToPhase(MentalStates state)
    {
        switch (state)
        {
            case MentalStates.NORMAL: return NarrativePhases.Enthusiasm;
            case MentalStates.TIRED: return NarrativePhases.Efficiency;
            case MentalStates.OVERLOADED: return NarrativePhases.Performance;
            case MentalStates.BREAKING: return NarrativePhases.Fracture;
            default: return NarrativePhases.Enthusiasm;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}