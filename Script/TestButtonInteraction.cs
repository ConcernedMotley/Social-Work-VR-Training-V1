using UnityEngine;
using UnityEngine.UIElements;

public class TestButtonInteraction : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = this.GetComponent<UIDocument>().rootVisualElement;

        Button button1 = root.Q<Button>("Button1");
        Button button2 = root.Q<Button>("Button2");
        Button button3 = root.Q<Button>("Button3");

        button1.clicked += () => SetColor(Color.red);
        button2.clicked += () => SetColor(Color.skyBlue);
        button3.clicked += () => SetColor(Color.springGreen);

    }

    private void SetColor(Color color)
    {
        rend.material.color = color;
    }
}
