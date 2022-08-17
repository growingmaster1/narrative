using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenResolution : MonoBehaviour
{
    public static ScreenResolution instance;

    [SerializeField] private GameObject[] cameraObjects;

    [Tooltip("����ʱ���յ���Ļ���")]
    public float developWidth;
    [Tooltip("����ʱ���յ���Ļ�߶�")]
    public float developHeight;

    /// <summary>
    /// �߿�ȣ�����ʱ��
    /// </summary>
    public static float developHeightWidthRate { get; private set; }

    /// <summary>
    /// �߿�ȣ�ʵ��)
    /// </summary>
    public static float screenHWRate { get; private set; }

    /// <summary>
    /// ���������rect�ߵı���
    /// </summary>
    public static float cameraRectHeightRate { get; private set; }

    /// <summary>
    /// ���������rect��ı���
    /// </summary>
    public static float cameraRectWidthRate { get; private set; }

    /// <summary>
    /// ��ʵ���½����꣬��������������
    /// </summary>
    public static Vector2 LeftDownPointWorldPos;

    /// <summary>
    /// ��ʵ���Ͻ�����
    /// </summary>
    public static Vector2 RightUpPointWorldPos;

    /// <summary>
    /// ��ʵ�߶�
    /// </summary>
    public static float realHeight;

    /// <summary>
    /// ��ʵ���
    /// </summary>
    public static float realWidth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        developHeightWidthRate = developHeight / developWidth;
        screenHWRate = ((float)Screen.height) / Screen.width;
        cameraRectHeightRate = developHeight / ((developWidth / Screen.width) * Screen.height);
        cameraRectWidthRate = developWidth / ((developHeight / Screen.height) * Screen.width);

        if (developHeightWidthRate <= screenHWRate)
        {
            LeftDownPointWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(0, (1 - cameraRectHeightRate) / 2, 0));
            RightUpPointWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(1, (1 + cameraRectHeightRate) / 2, 0));
        }
        else
        {
            LeftDownPointWorldPos = Camera.main.ViewportToWorldPoint(new Vector3((1 - cameraRectWidthRate) / 2, 0, 0));
            RightUpPointWorldPos = Camera.main.ViewportToWorldPoint(new Vector3((1 + cameraRectWidthRate) / 2, 1, 0));
        }

        realWidth = RightUpPointWorldPos.x - LeftDownPointWorldPos.x;
        realHeight = RightUpPointWorldPos.y - LeftDownPointWorldPos.y;

        SceneManager.sceneLoaded += FitScene;
    }

    public void FitScene(Scene next, LoadSceneMode mode)
    {
        cameraObjects = GameObject.FindGameObjectsWithTag("Cameras");
        FitCamera(Camera.main);
        foreach (GameObject item in cameraObjects)
        {
            FitCamera(item.GetComponent<Camera>());
        }
    }

    public static void FitCamera(Camera camera)
    {
        ///������Ļ��ʵ����Ļ����<=���������� ���º�  ��֮���Һ�
        if (developHeightWidthRate <= screenHWRate)
        {
            camera.rect = new Rect(0, (1 - cameraRectHeightRate) / 2, 1, cameraRectHeightRate);
        }
        else
        {
            camera.rect = new Rect((1 - cameraRectWidthRate) / 2, 0, cameraRectWidthRate, 1);
        }
    }
}

