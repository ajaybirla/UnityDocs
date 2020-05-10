using System;
using System.IO;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Space (10)]

    public TextMeshProUGUI documentText;
    public TextMeshProUGUI fontSizeText;

    [Space (10)]

    public GameObject menuPanelGameObject;

    [Space (10)]

    public VerticalLayoutGroup verticalLayoutGroup;

    [Space (10)]

    public RectTransform fullScreenRectTransform;

    private bool isFullScreen = false;

    public void OnFullScreenButtonClicked ()
    {
        isFullScreen = !isFullScreen;

        menuPanelGameObject.SetActive (!isFullScreen);

        fullScreenRectTransform.rotation = Quaternion.Euler (0.0f, 0.0f, isFullScreen ? 180.0f : 0.0f);

        verticalLayoutGroup.padding.left = (isFullScreen ? 128 : 640);

        verticalLayoutGroup.enabled = false;

        verticalLayoutGroup.enabled = true;
    }

    public void OnFontSizeSliderValueChanged (float fontSize)
    {
        fontSizeText.text = ((int) fontSize).ToString ();

        documentText.fontSize = fontSize;
    }

    public void OnOpenFileButtonClicked ()
    {
        string desktopPath = Environment.GetFolderPath (Environment.SpecialFolder.DesktopDirectory);

        var filePath = StandaloneFileBrowser.OpenFilePanel ("Open File", desktopPath, "txt", false);

        if (filePath.Length > 0)
        {
            if (!string.IsNullOrEmpty (filePath [0]))
            {
                string fileText = File.ReadAllText (new Uri (filePath [0]).LocalPath);

                documentText.text = fileText;
            }
        }
    }

    public void OnHelpButtonClicked ()
    {
        Application.OpenURL ("http://digitalnativestudios.com/textmeshpro/docs/rich-text/");
    }

    public void OnQuitButtonClicked ()
    {
        Application.Quit ();
    }
}
