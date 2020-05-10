using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof (TextMeshProUGUI))]

public class OpenHyperlinks : MonoBehaviour, IPointerClickHandler
{
    [Space (10)]

    public TextMeshProUGUI hyperlinkText;

    public void OnPointerClick (PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink (hyperlinkText, Input.mousePosition, Camera.main);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = hyperlinkText.textInfo.linkInfo [linkIndex];

            Application.OpenURL (linkInfo.GetLinkID ());
        }
    }
}