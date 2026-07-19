using TMPro;

using UnityEngine;

using UnityEngine.EventSystems;



public class ButtonVisualFeedback : MonoBehaviour,

IPointerEnterHandler,

IPointerExitHandler,

ISelectHandler,

IDeselectHandler

{

[Header("References")]

[SerializeField] private TextMeshProUGUI buttonText;



[Header("Materials")]

[SerializeField] private Material normalMaterial;

[SerializeField] private Material glowMaterial;



[Header("Scale")]

[SerializeField] private float hoverScale = 1.03f;



private Vector3 originalScale;

private bool isHighlighted;



private void Awake()

{

originalScale = transform.localScale;

DisableHighlight();

}



public void OnPointerEnter(PointerEventData eventData)

{

EnableHighlight();

}



public void OnPointerExit(PointerEventData eventData)

{

DisableHighlight();

}



public void OnSelect(BaseEventData eventData)

{

EnableHighlight();

}



public void OnDeselect(BaseEventData eventData)

{

DisableHighlight();

}



private void EnableHighlight()

{

if (isHighlighted)

return;



isHighlighted = true;



transform.localScale = originalScale * hoverScale;



if (buttonText != null && glowMaterial != null)

buttonText.fontSharedMaterial = glowMaterial;

}



private void DisableHighlight()

{

isHighlighted = false;



transform.localScale = originalScale;



if (buttonText != null && normalMaterial != null)

buttonText.fontSharedMaterial = normalMaterial;

}

} 

