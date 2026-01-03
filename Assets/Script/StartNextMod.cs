using System;
using System.Collections;
using Script;
using UnityEngine;
using UnityEngine.UIElements;

public class StartNextMod : MonoBehaviour
{
    [SerializeField] private GameObject nextModRef;
    [SerializeField] private GameObject currentModuleRef;
    
    [Header("Option Debrief messages")]
    
    [TextArea(3,15)]
    [SerializeField] private string optionADebriefMessage;
    [TextArea(3,15)]
    [SerializeField] private string optionBDebriefMessage;
    [TextArea(3,15)]
    [SerializeField] private string optionCDebriefMessage;
    
    private Label debriefText;

    [SerializeField] private ModuleScript moduleScriptRef;
    private bool _isOptimalSolution = false;
    
    private void OnEnable()
    {
        VisualElement root = this.GetComponent<UIDocument>().rootVisualElement;
        Button continueButton = root.Q<Button>("continueButton");
        debriefText = root.Q<Label>("debriefTextLabel");
        
        UpdateDebriefText();
        
        continueButton.clicked += ClickedContinue;
    }
    
    private void ClickedContinue()
    {
        
        //TODO: check if is optimal if not, re star form the mod
        
        if (nextModRef && _isOptimalSolution)
        {
            nextModRef.SetActive(true);
            this.gameObject.SetActive(false);
        }

        else
        {
            _isOptimalSolution = false;
            this.currentModuleRef.SetActive(true);
            moduleScriptRef.ReDoModule();
            this.gameObject.SetActive(false);
        }
        
    }

    public void SetIsOptimal()
    {
        _isOptimalSolution = true;
    }

    private void UpdateDebriefText()
    {
        switch (moduleScriptRef.ReturnSelectedAnswer())
        {
            case OptimalAnswer.OptionA:
                debriefText.text = optionADebriefMessage;
                break;
            case OptimalAnswer.OptionB:
                debriefText.text = optionBDebriefMessage;
                break;
            case OptimalAnswer.OptionC:
                debriefText.text = optionCDebriefMessage;
                break;
        }

        // StartCoroutine(UpdateCollider());
    }

    private IEnumerator UpdateCollider()
    {
        yield return null;

        BoxCollider thisCollider = this.gameObject.GetComponent<BoxCollider>();
        Renderer thisRender = this.gameObject.GetComponent<Renderer>();

        thisCollider.size = thisRender.bounds.size;
    }
}
