using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Loop : MonoBehaviour
{
    public GameObject[] Box;
    public GameObject A_Zone;
    public GameObject B_Zone;

    // khai bao toc do di chuyen chuong ngai vat
    public float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        MOVE();
    }

    // Ham tao chuong ngai vat
    public void MAKE() {
        // gan vi tri cnv B sang A
        B_Zone = A_Zone;
        // lay ngau nhien 1 vi tri
        int a = Random.Range(0,5);
        // khoi tao cnv A
        A_Zone = Instantiate(Box[a], new Vector3(30,0,0), transform.rotation) as GameObject;
    }

    // Ham di chuyen cnv
    public void MOVE() {
        // di chuyen vi tri cnv A
        A_Zone.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
        // di chuyen vi tri cnv B
        B_Zone.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
        // neu trung vi tri thi huy cnv
        if (A_Zone.transform.position.x <= 0) {
            DEATH();
        }
    }

    // Ham huy cnv
    public void DEATH() {
        // huy cnv B
        Destroy(B_Zone);
        // goi laij ham tao cnv
        MAKE();
    }
}
