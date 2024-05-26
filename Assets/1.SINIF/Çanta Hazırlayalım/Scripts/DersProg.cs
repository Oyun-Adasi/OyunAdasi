using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DersProg : MonoBehaviour
{

    new Collider2D collider2D;
    public TextMeshProUGUI DersProgramı;
    public GameObject doğruText;
    public GameObject yanlışText;
    public TextMeshProUGUI bitirme;
    Ders Türkçe;
    Ders Matematik;
    Ders HayatBilgisi;
    Ders GörselSanatlar;
    Ders Müzik;
    Ders OyunVeFizikiEtkinlikler;
    Ders SerbestEtkinlikler;
    Ders[] dersProgramı;
    Ders[] dersler;
    string[] herDers;
    int remainingIndex0;
    int remainingIndex1;
    int score=100;
    int neededItems=3;
    int putItems=0;
    public TextMeshProUGUI start;

void Awake()
{
    doğruText.SetActive(false);
    yanlışText.SetActive(false);
    collider2D = GetComponent<Collider2D>();
    dersler = new Ders[]
    {
        Türkçe = new Ders("Türkçe", 2, false),
        Matematik = new Ders("Matematik", 1, false),
        HayatBilgisi = new Ders("Hayat Bilgisi", 1, false),
        GörselSanatlar = new Ders("Görsel Sanatlar", 1, false),
        Müzik = new Ders("Müzik", 1, false),
        OyunVeFizikiEtkinlikler = new Ders("Oyun Ve Fiziki Etkinlikler", 1, false),
        SerbestEtkinlikler = new Ders("Serbest Etkinlikler", 1, false)
    };

    dersProgramı = new Ders[6];
}
    void Start()
    {
        DersProgramıGenerator();
        CreateHerDersArray();
        NeededItemsCalculator();

    }
void DersProgramıGenerator()
{
    List<Ders> remainingLessons = new List<Ders>
    {
        GörselSanatlar,
        Müzik,
        OyunVeFizikiEtkinlikler,
        SerbestEtkinlikler
    };

    int randomIndex = Random.Range(0, 3);
    int randomIndex2 = Random.Range(0, 2);
    switch (randomIndex)
    {
        case 0:
            dersProgramı[0] = dersler[0];
            dersProgramı[1] = dersler[0];
            remainingIndex0=2;
            remainingIndex1=3;
            break;
        case 1:
            dersProgramı[1] = dersler[0];
            dersProgramı[2] = dersler[0];
            remainingIndex0=0;
            remainingIndex1=3;
            break;
        case 2:
            dersProgramı[2] = dersler[0];
            dersProgramı[3] = dersler[0];
            remainingIndex0=0;
            remainingIndex1=1;
            break;
    }
    if(randomIndex==0||randomIndex==2){
        switch(randomIndex2){
            case 0:
                dersProgramı[remainingIndex0]=dersler[1];
                dersProgramı[remainingIndex1]=dersler[1];
                break;
            case 1:
                dersProgramı[remainingIndex1]=dersler[2];
                dersProgramı[remainingIndex0]=dersler[2];
                break;
    }
    }
else
{
    switch (randomIndex2)
    {
        case 0:
            dersProgramı[remainingIndex0] = dersler[1];
            dersProgramı[remainingIndex1] = dersler[2];
            break;
        case 1:
            dersProgramı[remainingIndex1] = dersler[2];
            dersProgramı[remainingIndex0] = dersler[1];
            break; 
    }
}
    for (int i = 4; i < dersProgramı.Length; i++)
    {
        Ders randomLesson = SelectRandomLesson(remainingLessons);
        dersProgramı[i] = randomLesson;
        remainingLessons.Remove(randomLesson);
    }

    for (int i = 0; i < dersProgramı.Length; i++)
    {
        DersProgramı.text += "Ders " + (i + 1) + ": " + dersProgramı[i].dersİsim + "\n";
    }
}
Ders SelectRandomLesson(List<Ders> lessons)
{
    int randomIndex = Random.Range(0, lessons.Count);
    Ders randomLesson = lessons[randomIndex];
    return randomLesson;
}
    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
public void CheckDroppedObject(GameObject droppedObject)
{
    string droppedObjectName = droppedObject.name;
    bool found = false;

    for (int i = 0; i < herDers.Length; i++)
    {
        if (herDers[i] == droppedObjectName)
        {
            yanlışText.SetActive(false);
            doğruText.SetActive(true);
            found = true;
            droppedObject.SetActive(false);
            putItems++;
            break;
            
        }
        else if (droppedObjectName == "Sabit")
        {
            yanlışText.SetActive(false);
            doğruText.SetActive(true);
            found = true;
            droppedObject.SetActive(false);
            putItems++;
            break;
        }
    }

    if (!found)
    {
        Debug.Log("Yanlış!");
        yanlışText.SetActive(true);
        doğruText.SetActive(false);
        score-=10;
    }
}
void CreateHerDersArray()
    {
        List<string> dersList = new List<string>();

        for (int i = 0; i < dersProgramı.Length; i++)
        {
            string dersİsim = dersProgramı[i].dersİsim;

            if (!dersList.Contains(dersİsim))
            {
                dersList.Add(dersİsim);
            }
        }

        herDers = dersList.ToArray();
    }
    void NeededItemsCalculator(){
        for(int i=0;i<herDers.Length;i++){
            switch(herDers[i]){
                case "Türkçe":
                    neededItems+=1;
                    break;
                case "Matematik":
                    neededItems+=5;
                    break;
                case "Hayat Bilgisi":
                    neededItems+=1;
                    break;
                case "Görsel Sanatlar":
                    neededItems+=4;
                    break;
                case "Müzik":
                    neededItems+=0;
                    break;
                case "Oyun Ve Fiziki Etkinlikler":
                    neededItems+=0;
                    break;
                case "Serbest Etkinlikler":
                    neededItems+=1;
                    break;
            }
        }
        Debug.Log(neededItems);
        start.text+=" İpucu: "+neededItems+" tane eşya koyman gerekiyor!";
    }
    public void Finish(){
        doğruText.SetActive(false);
        yanlışText.SetActive(false);
        if(putItems==neededItems){
            bitirme.text="Tebrikler! Tüm gerekli eşyaları koydun!";
        }
        else{
            bitirme.text="Maalesef tüm eşyaları koyamadın. Tekrar dene!";
        }
    }
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
public class Ders
{
    public string dersİsim;
    public int maxSaat;
    public bool isMax;

    public Ders(string dersİsim, int maxSaat, bool isMax)
    {
        this.dersİsim = dersİsim;
        this.maxSaat = maxSaat;
        this.isMax = isMax;
    }
}