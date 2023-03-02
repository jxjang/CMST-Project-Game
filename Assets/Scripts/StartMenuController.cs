using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    private UIDocument uiDoc;
    private GroupBox root;
    private VisualElement visButtons;
    private Button buttonStart;
    private Button buttonExit;

    private void Awake()
    {
        uiDoc = GetComponent<UIDocument>();
        root = uiDoc.rootVisualElement.Q<GroupBox>("root");
        visButtons = root.Q<VisualElement>("buttons");
        buttonStart = visButtons.Q<Button>("buttonStart");
        buttonExit = visButtons.Q<Button>("buttonExit");
    }

    private void Start()
    {
        buttonStart.clicked += () => SceneManager.LoadScene("game");
        buttonExit.clicked += () => ExitButtonClicked();
    }

    private void ExitButtonClicked()
    {
        //if (!Application.isEditor)
        //{
        //    Application.Quit();
        //}
        //else
        //{
        //    Debug.Log("Exit button was clicked.");
        //}
        Application.Quit();
    }
}
