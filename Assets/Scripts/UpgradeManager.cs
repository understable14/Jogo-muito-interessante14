using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeManager : MonoBehaviour
{

    public float DmgMult;
    public float DashCost = 100;
    public GameObject scoreManagerObject;
    public ScoreManager scoreManager;
    public TextMeshProUGUI money;
    public string PreTextMoney = "Tropigas- ";


    public void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        scoreManager.Score = 0; 
    }
    public void Update()
    {
        money.text = PreTextMoney + scoreManager.Tropiga.ToString("0");
    }


    public void ResetUpgrades()
    {
        DmgMult = 1;
        dash.Upgraded = false;
    }



    public void BulletUpgrade()
    {
        DmgMult += 10;
        EnemyDamage.UpgradeDmgMultiplier = DmgMult;
    }
    public void DashUpgrade()
    {
        if (scoreManager.Tropiga >= DashCost & !dash.Upgraded)
        {
            dash.Upgraded = true;
            scoreManager.Tropiga -= DashCost;
        }
    }


    public void MainScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
