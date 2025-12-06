using UnityEngine;
using UnityEngine.UIElements;

public class OptionButtonPanel : MonoBehaviour
{
    [SerializeField] private string optionAText;
    [SerializeField] private string optionBText;
    [SerializeField] private string optionCText;
    [SerializeField] private string optionDText;
    

    [SerializeField] private ModuleScript _moduleScriptRef;
    
    [TextArea(3, 10)] [SerializeField] private string notes;

    private void OnEnable()
    {
        VisualElement root = this.GetComponent<UIDocument>().rootVisualElement;
        
        Button buttonA = root.Q<Button>("ButtonA");
        Button buttonB = root.Q<Button>("ButtonB");
        Button buttonC = root.Q<Button>("ButtonC");
        Button buttonD = root.Q<Button>("ButtonD");

        buttonA.text = optionAText;
        buttonB.text = optionBText;
        buttonC.text = optionCText;
        buttonD.text = optionDText;
        
        buttonA.clicked += () => _moduleScriptRef.SelectOptionA();
        buttonB.clicked += () => _moduleScriptRef.SelectOptionB();
        buttonC.clicked += () => _moduleScriptRef.SelectOptionC();
        buttonD.clicked += () => _moduleScriptRef.SelectOptionD();
    }
    
    
}
