using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Hp : MonoBehaviour
{
    public Hp_Drain PlayerHealth;
    public ScoreManager ScoreUi;
    
    public TextMeshProUGUI Tropiga;
    public Text Score;
    
    
    public string PreText2 = "Tropigas- ";
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Score.text = ScoreUi.Score.ToString("0");
        Tropiga.text = PreText2 + ScoreUi.Tropiga.ToString("0");
    }

 

}