using System;
using UnityEngine;
using UnityEngine.UIElements;

public class introductionPanel : MonoBehaviour
{
    [SerializeField] private GameObject nextModRef;

    private Label _introBriefMessage;
    
    [Header("Introduction messages")]
    
    [TextArea(3,35)]
    [SerializeField] private string introductionMessage;

    [SerializeField] private string buttonText = "Next";

    private void OnEnable()
    {
        VisualElement root = this.GetComponent<UIDocument>().rootVisualElement;
        Button startModuleButton = root.Q<Button>("startModuleButton");

        _introBriefMessage = root.Q<Label>("introText");

        root.Q<Button>("startModuleButton").text = buttonText;
        
        UpdateBrief();

        startModuleButton.clicked += ClickedStartModule;
    }

    private void UpdateBrief()
    {
        _introBriefMessage.text = introductionMessage;
    }

    private void ClickedStartModule()
    {
        
        if (nextModRef)
        {
            nextModRef.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
