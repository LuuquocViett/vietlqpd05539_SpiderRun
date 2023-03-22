using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game_Manager : MonoBehaviour
{
    public int GameLV;
    public float GameSpeed;
    public Box_Loop _BL;
    public Scroll_Mapping _SM;
    public GameObject Player;


    private float meter;
    private int getMoney = 0;

    //
    public GameObject gameOver;
    public GameObject gameComplete;
    public GameObject Pause;

    //text get value gold and meter
    public TMP_Text[] gold_Label;
    public TMP_Text[] meter_label;


    void Start()
    {
        GameSpeed = _BL.Speed;
    }

    // Update is called once per frame
    void Update()
    { 
            METERUPDATE();
    }

    //Tuong tac giao dien

    void METERUPDATE() {
        meter += Time.deltaTime * GameSpeed;
        meter_label[2].text = string.Format("{0:N0}<color=#ff3366> m</color>", meter);
        meter_label[0].text = meter_label[1].text = meter_label[2].text;
        
    }

    private void GameLevelUp()
    {
        GameLV += 1;
        GameSpeed += 3;
        _SM.ScrollSpeed += 0.1f;
        _BL.Speed = GameSpeed;
    }

    public void GAMEOVER()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);


    }
    //get coin
    public void GETCOIN()
    {
        getMoney += 1;
        gold_Label[0].text = string.Format("{0:N0}", getMoney);
        gold_Label[2].text= gold_Label[1].text = gold_Label[0].text ;
        if (getMoney >= 10 && GameLV == 1)
        {
           GameLevelUp();
        }
        if (getMoney >= 30 && GameLV == 2)
        {
            GameLevelUp();
        }
        if (getMoney >= 100 && GameLV == 3)
        {
            GameLevelUp();
        }
        if (getMoney >= 150 && GameLV == 4)
        {
            GameLevelUp();
        }
        if (getMoney >= 200 && GameLV == 5)
        {
            GameComplete();
        }
    }
    void GameComplete()
    {
        gameComplete.SetActive(true);
        Player.SetActive(false);
        Time.timeScale = 0;
    }


    public void PauseGame(bool check) 
    {
        if (check)
        {
            Time.timeScale = 0;
            Pause.SetActive(check);
        }
        else
        {
            Time.timeScale = 1;
            Pause.SetActive(check);
        }
    }
}
