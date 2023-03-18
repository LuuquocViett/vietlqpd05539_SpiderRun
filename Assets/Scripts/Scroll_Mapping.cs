using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Mapping : MonoBehaviour
{
    // khai bao toc do scroll
    public float ScrollSpeed = 0.5f;
    // khai bao khoang cach offset
    float Offset;

    void Update() {
        // khoang cach di chuyen
        Offset += Time.deltaTime * ScrollSpeed;
        //render mapping
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Offset, 0.01f);
    }
}
