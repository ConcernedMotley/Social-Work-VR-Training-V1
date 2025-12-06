using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RestartPanel : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = this.GetComponent<UIDocument>().rootVisualElement;
        
        Button restartButton = root.Q<Button>("restartButton");

        restartButton.clicked += RestartScene;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("Social Work Office");
    }
}
