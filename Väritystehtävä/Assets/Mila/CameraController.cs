using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] int size;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (GameData.gameData.IsOnMobile)
        {

           // float width = Screen.width * Screen.width;
            //float height = Screen.height * Screen.height;
            float aspectRatio = Screen.width / (float)Screen.height;
            _camera.orthographicSize = size / aspectRatio / 2f;
          //  _camera.orthographicSize = size / width * height / 2;
        }
    }
}
