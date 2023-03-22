using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{
    public Camera _camera;
    public GameObject _player;
    public float speed;
    public float MaxSize = 7.5f;
    public float MinSize = 5.5f;
    float CameraSize = 6f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("03_Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Thay doi camera theo vi tri character
        if (_player != null) {
            CameraSize = 5f + _player.transform.position.y;
        }
        if (CameraSize >= MaxSize) {
            CameraSize = MaxSize;
        }
        if (CameraSize <= MinSize) {
            CameraSize = MinSize;
        }

        // Cap nhat v tri Camera
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize,CameraSize, Time.deltaTime / speed);
    }
}
