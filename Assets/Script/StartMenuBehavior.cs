using UnityEngine;
using UnityEngine.UIElements;

public class StartMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject initialModRef;
    
    private void OnEnable()
    {
        VisualElement root = this.GetComponent<UIDocument>().rootVisualElement;
        
        Button startButton = root.Q<Button>("StartButton");
        Button quitButton = root.Q<Button>("QuitButton");

        startButton.clicked += () =>
        {
            initialModRef.SetActive(true);
            this.gameObject.SetActive(false);
        };
        quitButton.clicked += Application.Quit;
    }
    
}
