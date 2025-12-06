using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class ModuleScript : MonoBehaviour
{
    //mod 1
    // pause timestamp: 12.5
    // A: 13, 23.5
    // B: 24, 33
    // C: 33.5, 45
    
    // private referencs
    private VideoControls _videoControls;
    private bool optionSelected = false;
    private float newPauseTime;
    
    [SerializeField] private GameObject modulePanelRef;
    [SerializeField] private GameObject nextModPanelRef;
    
    [TextArea(3,15)]
    [SerializeField] private string notes;

    [Header("Time stamps")] 
    
    [SerializeField] private float pauseTimeStamp;
    
    [SerializeField] private float optionAStartTimeStamp; 
    [SerializeField] private float optionAEndTimeStamp;
    
    [SerializeField] private float optionBStartTimeStamp; 
    [SerializeField] private float optionBEndTimeStamp;
    
    [SerializeField] private float optionCStartTimeStamp; 
    [SerializeField] private float optionCEndTimeStamp;

    [SerializeField] private OptimalAnswer optimalAnswer;

    private OptimalAnswer _selectedAnswer;
    private StartNextMod _startNextModRef;


    private void OnEnable()
    {
        ShowOptionUI(modulePanelRef, false);
        ShowOptionUI(nextModPanelRef, false);
        _videoControls = this.gameObject.GetComponent<VideoControls>();
        _videoControls.PlayVideo();
        newPauseTime = pauseTimeStamp + 1;
        _startNextModRef = this.nextModPanelRef.GetComponent<StartNextMod>();
    }

    private void Update()
    {
        if (_videoControls.GetVideoTime() >= pauseTimeStamp && !optionSelected)
        {
            _videoControls.PauseVideo();
            ShowOptionUI(modulePanelRef,true);
            // optionSelected = true;
        }
        
        if (optionSelected && _videoControls.GetVideoTime() >= newPauseTime)
        {
            _videoControls.PauseVideo(); 

            if (CheckOptimalSolution())
            {
                _startNextModRef.SetIsOptimal();
            }

            ShowOptionUI(_videoControls.gameObject, false);
            if (nextModPanelRef) ShowOptionUI(nextModPanelRef, true);
            
        }
    }

    private void ShowOptionUI(GameObject panelRef, bool uiState)
    {
        panelRef.SetActive(uiState);
    }

    public void SelectOptionA()
    {
        SelectedOption(optionAStartTimeStamp, optionAEndTimeStamp);
        _selectedAnswer = OptimalAnswer.OptionA;
        optionSelected = true;
    }
    
    public void SelectOptionB()
    {
        SelectedOption(optionBStartTimeStamp, optionBEndTimeStamp);
        _selectedAnswer = OptimalAnswer.OptionB;
        optionSelected = true;
    }
    
    public void SelectOptionC()
    {
        SelectedOption(optionCStartTimeStamp, optionCEndTimeStamp);
        _selectedAnswer = OptimalAnswer.OptionC;
        optionSelected = true;
    }
    
    public void SelectOptionD()
    {
        ReDoModule();
    }

    private void SelectedOption(float startTime, float endTime)
    {
        newPauseTime = endTime;
        _videoControls.SetVideoTime(startTime);
        ShowOptionUI(modulePanelRef, false);
    }

    private IEnumerator ResetState()
    {
        _videoControls.PauseVideo();
        ShowOptionUI(modulePanelRef, false);
        
        optionSelected = false;
        _selectedAnswer = OptimalAnswer.None;
        newPauseTime = pauseTimeStamp + 1;
        
        
        yield return null;
        
        _videoControls.RestartVideo();
    }

    public void ReDoModule()
    {
        StartCoroutine(ResetState());
    }

    private bool CheckOptimalSolution()
    {
        return _selectedAnswer == optimalAnswer;
    }

    public OptimalAnswer ReturnSelectedAnswer()
    {
        return _selectedAnswer;
    }
    
}
