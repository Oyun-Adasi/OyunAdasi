using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Kontrolcü : MonoBehaviour
{
    Vector3 offset;
    new Collider2D collider2D;
    public string destinationTag = "DropArea";
    public bool isRequired;
    public TextMeshProUGUI DersProgramı;
    //public TextMeshProUGUI wrongText;
    //public TextMeshProUGUI trueText;
    //public Yönetici yönetici;
    Ders Türkçe;
    Ders Matematik;
    Ders HayatBilgisi;
    Ders GörselSanatlar;
    Ders Müzik;
    Ders OyunVeFizikiEtkinlikler;
    Ders SerbestEtkinlikler;
    Ders[] dersProgramı;
    Ders[] dersler;
    int remainingIndex0;
    int remainingIndex1;
    

    public int score = 0;

void Awake()
{
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
        //wrongText.gameObject.SetActive(false);
        //trueText.gameObject.SetActive(false);
        DersProgramıGenerator();

    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2D.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;

        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag && isRequired == true)
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
                //trueText.gameObject.SetActive(true);
                Invoke("TrueTextSetActiveFalse", 1);
                Destroy(gameObject, 1);

                //int requiredObjectLastIndex = yönetici.requiredObject.Count - 1;
                //yönetici.requiredObject.RemoveAt(requiredObjectLastIndex);
            }
            else
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
                //wrongText.gameObject.SetActive(true);
                Invoke("WrongTextSetActiveFalse", 1);
                Destroy(gameObject, 1);

                //int unrequiredObjectLastIndex = yönetici.unrequiredObject.Count - 1;
                //yönetici.unrequiredObject.RemoveAt(unrequiredObjectLastIndex);
            }
        }
        collider2D.enabled = true;
    }


    void TrueTextSetActiveFalse()
    {
        //trueText.gameObject.SetActive(false);
    }

    void WrongTextSetActiveFalse()
    {
        //wrongText.gameObject.SetActive(false);
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
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
        Debug.Log(i+" "+dersProgramı[i].dersİsim);
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
