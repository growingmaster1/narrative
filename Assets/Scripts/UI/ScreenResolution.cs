using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenResolution : MonoBehaviour
{
    public static ScreenResolution instance;

    [SerializeField] private GameObject[] cameraObjects;

    [Tooltip("开发时参照的屏幕宽度")]
    public float developWidth;
    [Tooltip("开发时参照的屏幕高度")]
    public float developHeight;

    /// <summary>
    /// 高宽比（开发时）
    /// </summary>
    public static float developHeightWidthRate { get; private set; }

    /// <summary>
    /// 高宽比（实际)
    /// </summary>
    public static float screenHWRate { get; private set; }

    /// <summary>
    /// 世界摄像机rect高的比例
    /// </summary>
    public static float cameraRectHeightRate { get; private set; }

    /// <summary>
    /// 世界摄像机rect宽的比例
    /// </summary>
    public static float cameraRectWidthRate { get; private set; }

    /// <summary>
    /// 真实左下角坐标，供其他函数调用
    /// </summary>
    public static Vector2 LeftDownPointWorldPos;

    /// <summary>
    /// 真实右上角坐标
    /// </summary>
    public static Vector2 RightUpPointWorldPos;

    /// <summary>
    /// 真实高度
    /// </summary>
    public static float realHeight;

    /// <summary>
    /// 真实宽度
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
        ///适配屏幕。实际屏幕比例<=开发比例的 上下黑  反之左右黑
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

