using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] int size;
     
    void Update()
    {
        //Changes cameras orthographic size to fit on mobile based on screen size
        if (GameData.gameData.IsOnMobile)
        {
            float aspectRatio = Screen.width / (float)Screen.height;
            _camera.orthographicSize = size / aspectRatio / 2f;
       
        }
    }
}
