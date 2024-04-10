using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Yönetici : MonoBehaviour
{
    public List<GameObject> requiredObject;
    public List<GameObject> unrequiredObject;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;


    void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);

    }

    void Update()
    {
        if (requiredObject.Count <= 0)
        {
            winText.gameObject.SetActive(true);
        }

        if (unrequiredObject.Count <= 4)
        {
            loseText.gameObject.SetActive(true);
        }
    }
    


}

