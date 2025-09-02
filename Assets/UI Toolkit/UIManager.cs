using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
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

    private Sprite playerImg;
    private Sprite AIImg;

    public Sprite Animal1Img, Animal2Img, Animal3Img, Animal4Img, Animal5Img, Animal6Img, Animal7Img;

    private void Awake()
    {
        //UI Document ¿¬°á
        #region
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
        #endregion
    }

    private void Start()
    {
        root = uiDocument.rootVisualElement;
        root.AddToClassList("DownState");
        root.AddToClassList("NomalState");

        Animal1.style.backgroundImage = new StyleBackground(Animal1Img.texture);
        Animal2.style.backgroundImage = new StyleBackground(Animal2Img.texture);
        Animal3.style.backgroundImage = new StyleBackground(Animal3Img.texture);
        Animal4.style.backgroundImage = new StyleBackground(Animal4Img.texture);
        Animal5.style.backgroundImage = new StyleBackground(Animal5Img.texture);
        Animal6.style.backgroundImage = new StyleBackground(Animal6Img.texture);
        Animal7.style.backgroundImage = new StyleBackground(Animal7Img.texture);
    }

    // Animal 1~7 Bttun Clicked Event
    #region
    private void Animal1_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal1Img);
        PlayerLabel.text = "Animal01";
    }
    private void Animal2_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal2Img);
        PlayerLabel.text = "Animal02";
    }
    private void Animal3_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal3Img);
        PlayerLabel.text = "Animal03";
    }
    private void Animal4_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal4Img);
        PlayerLabel.text = "Animal04";
    }
    private void Animal5_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal5Img);
        PlayerLabel.text = "Animal05";
    }
    private void Animal6_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal6Img);
        PlayerLabel.text = "Animal06";
    }
    private void Animal7_clicked()
    {
        Top1.style.backgroundImage = new StyleBackground(Animal7Img);
        PlayerLabel.text = "Animal07";
    }
    #endregion

    private void ConfirmButton_clicked()
    {
        AIConfirm();
    }

    private void AIConfirm()
    {
        int AITarget = Random.Range(1, 7);
        Top3.style.backgroundImage = new StyleBackground();
        AILabel.text = "AITarget";
    }

    private void StartButton_clicked()
    {
        root.RemoveFromClassList("NomalState");
    }
}