using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;
using Label = UnityEngine.UIElements.Label;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;

    private VisualElement Top;
    private VisualElement Top1, Top2, Top3;
    private Label PlayerLabel, AILabel;

    private VisualElement Mid;
    private Button Animal1, Animal2, Animal3, Animal4, Animal5, Animal6, Animal7;

    private VisualElement Bot;
    private Button ConfirmButton, StartButton;


    private void Awake()
    {
        root = uiDocument.rootVisualElement;
        // Top Section
        Top = root.Q<VisualElement>("Top");
        Top1 = root.Q<VisualElement>("Top1");
        Top2 = root.Q<VisualElement>("Top2");
        Top3 = root.Q<VisualElement>("Top3");
        PlayerLabel = root.Q<Label>("PlayerLabel");
        AILabel = root.Q<Label>("AILabel");

        // Mid Section
        Mid = root.Q<VisualElement>("Mid");
        Animal1 = root.Q<Button>("Animal1");
        Animal2 = root.Q<Button>("Animal2");
        Animal3 = root.Q<Button>("Animal3");
        Animal4 = root.Q<Button>("Animal4");
        Animal5 = root.Q<Button>("Animal5");
        Animal6 = root.Q<Button>("Animal6");
        Animal7 = root.Q<Button>("Animal7");

        // Bot Section
        Bot = root.Q<VisualElement>("Bot");
        ConfirmButton = root.Q<Button>("Confirm");
        StartButton = root.Q<Button>("GameStart");

        Animal1.clicked += Animal1_clicked;
        Animal2.clicked += Animal2_clicked;
        Animal3.clicked += Animal3_clicked;
        Animal4.clicked += Animal4_clicked;
        Animal5.clicked += Animal5_clicked;
        Animal6.clicked += Animal6_clicked;
        Animal7.clicked += Animal7_clicked;
        ConfirmButton.clicked += ConfirmButton_clicked;
        StartButton.clicked += StartButton_clicked;
    }

    private void Start()
    {
        root = uiDocument.rootVisualElement;
        root.AddToClassList("DownState");
        root.AddToClassList("NomalState");
    }

    private void Animal1_clicked()
    {
        throw new System.NotImplementedException();
    }
    private void Animal2_clicked()
    {
        throw new NotImplementedException();
    }
    private void Animal3_clicked()
    {
        throw new NotImplementedException();
    }
    private void Animal4_clicked()
    {
        throw new NotImplementedException();
    }
    private void Animal5_clicked()
    {
        throw new NotImplementedException();
    }
    private void Animal6_clicked()
    {
        throw new NotImplementedException();
    }
    private void Animal7_clicked()
    {
        throw new NotImplementedException();
    }

    private void StartButton_clicked()
    {
        root.RemoveFromClassList("NomalState");
    }

    private void ConfirmButton_clicked()
    {
        throw new NotImplementedException();
    }
}