using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public struct StateFrameSet
{
    public MentalStates state;
    public List<Sprite> frames;
    public float secondsPerFrame;
}


public class StressDeformableObjectController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    Image targetImage;

    [Header("Frame sets per stato")]
    [SerializeField]
    List<StateFrameSet> stateFrameSets;

    Coroutine animationCoroutine;

    void Start()
    {
        gameManager.MentalStateSystem.OnMentalStateChanged += OnStateChanged;

        PlayFramesForState(gameManager.MentalStateSystem.CurrentState);
    }

    void OnStateChanged(MentalStates newState)
    {
        PlayFramesForState(newState);
    }

    void PlayFramesForState(MentalStates state)
    {
        StateFrameSet? set = GetFrameSetForState(state);

        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        if (set == null || set.Value.frames == null || set.Value.frames.Count == 0)
        {
            return;
        }

        animationCoroutine = StartCoroutine(AnimateFrames(set.Value.frames, set.Value.secondsPerFrame));
    }

    StateFrameSet? GetFrameSetForState(MentalStates state)
    {
        foreach (StateFrameSet set in stateFrameSets)
        {
            if (set.state == state)
            {
                return set;
            }
        }
        return null;
    }

    IEnumerator AnimateFrames(List<Sprite> frames, float secondsPerFrame)
    {
        int index = 0;

        if (frames.Count == 1)
        {
            targetImage.sprite = frames[0];
            yield break;
        }

        while (true)
        {
            targetImage.sprite = frames[index];
            index = (index + 1) % frames.Count;
            yield return new WaitForSeconds(secondsPerFrame);
        }
    }
}