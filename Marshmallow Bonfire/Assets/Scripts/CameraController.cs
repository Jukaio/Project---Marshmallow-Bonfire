using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject mid;
    public GameObject obj1;
    public GameObject obj2;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public Camera leftCamera;
    Vector3 leftCameraPos;

    public Camera rightCamera;
    Vector3 rightCameraPos;

    float distanceOfPlayersHor;
    float distanceOfPlayersVert;
    float secondCamerasHorHalf;

    public Camera mainCamera;

    public RawImage leftCameraRender;
    public RawImage rightCameraRender;

    public Image image;

    public float a;
    public float b;
    public float c;
    float angleOtherSide;

    private void Start()
    {
        mainCamera = mainCamera.GetComponent<Camera>();
        distanceOfPlayersHor = ((mainCamera.transform.position.z * Mathf.Tan((mainCamera.fieldOfView / 2) * Mathf.PI / 180) * -1) * mainCamera.aspect) * 2;
        distanceOfPlayersVert = (mainCamera.transform.position.z * Mathf.Tan((mainCamera.fieldOfView / 2) * Mathf.PI / 180) * -1);

        secondCamerasHorHalf = 0.5f * ((rightCamera.transform.position.z * Mathf.Tan((rightCamera.fieldOfView / 2) * Mathf.PI / 180) * -1) * rightCamera.aspect) *2;

        leftCameraPos = leftCamera.transform.position;
        rightCameraPos = rightCamera.transform.position;
    }

    private void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, mid.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, mid.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

        leftCamera.transform.position = new Vector3(Mathf.Clamp(leftCamera.transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(leftCamera.transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(leftCamera.transform.position.z, minCameraPos.z, maxCameraPos.z));


        Debug.Log(secondCamerasHorHalf + " second!!");

        a = 0;
        b = obj2.transform.position.y - obj1.transform.position.y;
        c = obj2.transform.position.x - obj1.transform.position.x;

        image.transform.rotation = Quaternion.Euler(0, 0, 90 + (Mathf.Rad2Deg * Mathf.Atan(b / c)));

        if ((Mathf.Abs(obj1.transform.position.x - obj2.transform.position.x) > distanceOfPlayersHor - secondCamerasHorHalf * 2))
        {
            leftCameraRender.gameObject.SetActive(true);
            rightCameraRender.gameObject.SetActive(true);
            Debug.LogError("HELP!");
            image.gameObject.SetActive(true);


            if (obj1.transform.position.x < obj2.transform.position.x)
            {
                leftCamera.transform.position = new Vector3(obj1.transform.position.x, leftCameraPos.y, leftCameraPos.z);
                rightCamera.transform.position = new Vector3(obj2.transform.position.x, rightCameraPos.y, rightCameraPos.z);
            }
            else
            {
                leftCamera.transform.position = new Vector3(obj2.transform.position.x, leftCameraPos.y, leftCameraPos.z);
                rightCamera.transform.position = new Vector3(obj1.transform.position.x, rightCameraPos.y, rightCameraPos.z);
            }
 
        }
        else
        {
            leftCameraRender.gameObject.SetActive(false);
            rightCameraRender.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
        }
        Debug.Log((mainCamera.transform.position.z * Mathf.Tan((mainCamera.fieldOfView / 2) * Mathf.PI / 180) * -1)* mainCamera.aspect);
        Debug.Log(distanceOfPlayersHor);
    }
}
