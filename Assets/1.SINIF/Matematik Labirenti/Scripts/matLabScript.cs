using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mathLabScript : MonoBehaviour
{
    public TMP_Text question;
    public int highestAnswer;
    int ans;//Answer to the question
    int num1;//Greater number
    int num2;//Smaller number
    int operation;//Determines with operation to perform. 0 for addition, 1 for substraction
    int wrongAns1;//First wrong answer
    int wrongAns2;//Second wrong answer
    public Button startButton;//Button to start
    public Button geriDon;//Button to return to the question after answering it wrong
    public Button optionA;
    public Button optionB;
    public Button optionC;
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text startButtonText;
    private bool isClickedA;//to disable the option A if the button is clicked and it was wrong
    private bool isClickedB;//to disable the option B if the button is clicked and it was wrong
    private bool isClickedC;//to disable the option C if the button is clicked and it was wrong

    private GameObject soru;
    private GameObject yanlis;
    public Button quit;

    
    void Awake(){
        geriDon.gameObject.SetActive(false);
        optionA.gameObject.SetActive(false);
        optionB.gameObject.SetActive(false);
        optionC.gameObject.SetActive(false);


        soru = GameObject.Find("soru");
        yanlis = GameObject.Find("yanlis");
    }
    void Update()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        optionA.onClick.AddListener(OnOptionButtonAClick);
        optionB.onClick.AddListener(OnOptionButtonBClick);
        optionC.onClick.AddListener(OnOptionButtonCClick);
        geriDon.onClick.AddListener(OnOptionButtongeriDonClick);

    }
    public void backgroundChanger() {
        soru.SetActive(false);
        yanlis.SetActive(true);
}       
    public void backgroundChangerv2() {
        soru.SetActive(true);
        yanlis.SetActive(false);

    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");

    }
    public int randomQuestionGenerator(){
        int randomNum1=Random.Range(1,highestAnswer+1);
        int randomNum2=Random.Range(1,highestAnswer+1);
        num1=Mathf.Max(randomNum1, randomNum2);
        num2=Mathf.Min(randomNum1, randomNum2);
        operation=Random.Range(0,2);
        if (operation==0){
            ans=num1+num2;
            wrongAnswerGenerator(ans);
            question.text=num1+" + "+num2+" işleminin sonucu kaçtır?";
            OptionModifier();
            return ans;    
        }
        else{
            ans=num1-num2;
            wrongAnswerGenerator(ans);
            question.text=num1+" - "+num2+" işleminin sonucu kaçtır?";
            OptionModifier();
            return ans;
        }
        }
    void wrongAnswerGenerator(int ans)
{
    wrongAns1 = Random.Range(1, 21);
    wrongAns2 = Random.Range(1, 21);

    while (wrongAns1 == ans || wrongAns2 == ans || wrongAns1 == wrongAns2)
    {
        wrongAns1 = Random.Range(1, 21);
        wrongAns2 = Random.Range(1, 21);
    }
}
    void OnStartButtonClick(){
        startButtonText.text="Devam Et!";
        optionA.gameObject.SetActive(true);
        optionB.gameObject.SetActive(true);
        optionC.gameObject.SetActive(true);
        randomQuestionGenerator();
        yanlis.SetActive(false);
        startButton.gameObject.SetActive(false);
        isClickedA=false;
        isClickedB=false;
        isClickedC=false;
        
    }
    void OptionModifier(){
            switch(Random.Range(0,3)){
                case 0:
                    answerA.text=ans.ToString();
                    answerB.text=wrongAns1.ToString();
                    answerC.text=wrongAns2.ToString();
                    break;
                case 1:
                    answerA.text=wrongAns1.ToString();
                    answerB.text=ans.ToString();
                    answerC.text=wrongAns2.ToString();
                    break;
                case 2:
                    answerA.text=wrongAns1.ToString();
                    answerB.text=wrongAns2.ToString();
                    answerC.text=ans.ToString();
                    break;
            }        
    }
    void OnOptionButtonAClick(){
        if(ans==int.Parse(answerA.text)){
            buttonInteractOn(optionA);
            buttonInteractOn(optionB);
            buttonInteractOn(optionC);
            backgroundChangerv2();
            optionsInvincible();
            startButton.gameObject.SetActive(true);
            question.text="Doğru!\n Sıradaki odaya geçebilirsin!";

            
        }
        else{
            question.text="Yanlış kapıyı seçtin! Geri dön ve tekrar dene!";
            buttonInteractOff(optionA);
            geriDon.gameObject.SetActive(true);
            backgroundChanger();
            isClickedA=true;
            wrongAnswerSelected();
            
        }
    }
    void OnOptionButtonBClick(){
        if(ans==int.Parse(answerB.text)){
            buttonInteractOn(optionA);
            buttonInteractOn(optionB);
            buttonInteractOn(optionC);
            backgroundChangerv2();
            startButton.gameObject.SetActive(true);
            question.text="Doğru!\n Sıradaki odaya geçebilirsin!";
            optionsInvincible();
            
        }
        else{
            question.text="Yanlış kapıyı seçtin! Geri dön ve tekrar dene!";
            buttonInteractOff(optionB);
            geriDon.gameObject.SetActive(true);
            backgroundChanger();
            isClickedB=true;
            wrongAnswerSelected();
            
        }
    }
    void OnOptionButtonCClick(){
        if(ans==int.Parse(answerC.text)){
            buttonInteractOn(optionA);
            buttonInteractOn(optionB);
            buttonInteractOn(optionC);
            backgroundChangerv2();
            startButton.gameObject.SetActive(true);
            question.text="Doğru!\n Sıradaki odaya geçebilirsin!";
            optionsInvincible();
            

        }
        else{
            question.text="Yanlış kapıyı seçtin! Geri dön ve tekrar dene!";
            buttonInteractOff(optionC);
            geriDon.gameObject.SetActive(true);
            backgroundChanger();
            isClickedC=true;
            wrongAnswerSelected();
            
        }
    }
        void OnOptionButtongeriDonClick(){
            buttonInteractOn(optionA);
            buttonInteractOn(optionB);
            buttonInteractOn(optionC);
            optionA.gameObject.SetActive(true);
            optionB.gameObject.SetActive(true);
            optionC.gameObject.SetActive(true);
    
            backgroundChangerv2(); // "soru" arkaplanına geri dön
            if(operation==0)
                question.text="Yanlış!\n"+num1+" + "+num2+" işleminin sonucu kaçtır?";
            else 
                question.text="Yanlış!\n"+num1+" - "+num2+" işleminin sonucu kaçtır?";

            geriDon.gameObject.SetActive(false);
            if(isClickedA)
                buttonInteractOff(optionA);
            if(isClickedB)
                buttonInteractOff(optionB);
            if(isClickedC)  
                 buttonInteractOff(optionC);

}
    void buttonInteractOn(Button a){
        a.interactable=true;
    }
    void buttonInteractOff(Button a){
        a.interactable=false;
    }
    void wrongAnswerSelected(){
        optionA.gameObject.SetActive(false);
        optionB.gameObject.SetActive(false);
        optionC.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }
    void optionsInvincible(){
        optionA.gameObject.SetActive(false);
        optionB.gameObject.SetActive(false);
        optionC.gameObject.SetActive(false);
    }
    }
