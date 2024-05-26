using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public string ilAdi;
    public CityUIManager uiManager;
    private bool isAnswered = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnClicked()
    {
        if (isAnswered) return;

        Debug.Log(ilAdi + " tıklandı!");

        ShowQuestion();
    }

    void ShowQuestion()
    {
        string correctAnswer = ilAdi;
        string[] allCities = {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya",
            "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
            "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne",
            "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
            "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu",
            "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
            "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu",
            "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
            "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray",
            "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan",
            "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
            };
        System.Collections.Generic.List<string> options = new System.Collections.Generic.List<string>();

        options.Add(correctAnswer);
        while (options.Count < 3)
        {
            string randomCity = allCities[Random.Range(0, allCities.Length)];
            if (!options.Contains(randomCity))
            {
                options.Add(randomCity);
            }
        }

        options = ShuffleList(options);
        uiManager.DisplayQuestion("Bu il hangisi?", options.ToArray(), this);
    }

    System.Collections.Generic.List<string> ShuffleList(System.Collections.Generic.List<string> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

    public void SetAnswerResult(bool isCorrect)
    {
        isAnswered = true;
        if (isCorrect)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }
}
