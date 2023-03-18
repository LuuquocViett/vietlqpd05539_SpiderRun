using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Get : MonoBehaviour
{
    public Sound_Player _SP;
    public Player_Move _PM;
    public int Get_Coin_Count;
    public Game_Manager _gm;
    // Start is called before the first frame update
    void Start()
    {
        // tim doi tuong game trong scene
        GameObject a = GameObject.Find("05_GameManager");
        if (a!=null)_gm = a.GetComponent<Game_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Su kien Trigger
    void OnTriggerEnter (Collider Get) {
        // neu la tag "coin"
        if (Get.tag == "coin") {
            Get.gameObject.SetActive(false);
            Get_Coin_Count += 1;
            if (_gm != null) {
                _gm.GETCOIN();
            }
            if (_SP != null) {
                _SP.SoundPlay(1);
            }
        }
        // neu tag la DeathZone
        if (Get.tag == "DeathZone") {
            Debug.Log("Die");
            if (_PM.status != PlayerMoveStatus.Die) {
                _PM.status = PlayerMoveStatus.Die;
                // Handheld.Vibrate();
                this.gameObject.GetComponent<Rigidbody>().AddForce (0,-50f,0);
                if (_gm != null){
                    _gm.GAMEOVER();
                }
                if (_SP != null) {
                    _SP.SoundPlay(2);
                }
                if (_fade != null) {
                    _Fade.FadeOut();
                }
            }
        }
    }
}
