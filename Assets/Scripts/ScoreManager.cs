using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public float Score = 0;
    public float Tropiga = 0;

    public bool BossDead;


    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Update()
    {
        if(BossDead)
        {
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Cursor.visible = true;
                BossDead = false;
            }
        }
    }
}
