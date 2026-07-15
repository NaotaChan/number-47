using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PortraitAnimationManager : MonoBehaviour
{
    [SerializeField]
    private Image portraitImage;

    public void SetPortrait(Sprite sprite) => portraitImage.sprite = sprite;

    public IEnumerator PlayAnimation(CustomerData customer)
    {
        if (customer.animationFrames.Count < 2) yield break;

        int frameIndex = 0;
        while (true)
        {
            portraitImage.sprite = customer.animationFrames[frameIndex];
            frameIndex = (frameIndex + 1) % customer.animationFrames.Count;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
