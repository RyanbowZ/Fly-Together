using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XiangJiContoller : MonoBehaviour
{
    string savePath;
    public Camera cm;
    public Material HuaMian;
    private void Awake()
    {
        savePath = Application.dataPath + "/SaveInfo";
        if (!Directory.Exists(savePath))
        {

            
            Directory.CreateDirectory(savePath);
            File.Create(savePath + "/546851439f99");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            //截取全屏，保存至本地路径
            //StartCoroutine(Shot(new Rect(0, 0, Screen.width, Screen.height), null, Application.streamingAssetsPath + "/screenShot.png"));
            StartCoroutine(Shot(new Rect(0, 0, Screen.width, Screen.height), cm, savePath + "/screenShot.png"));
        }*/
        if (Input.GetKey(KeyCode.M))
        {
            CameraCapture(cm, new Rect(0, 0, Screen.width, Screen.height), savePath + "/screenShot2.png");
        }
    }

    /// <summary>
    /// 截取指定Camera指定区域画面，并保存到本地
    /// </summary>
    /// <param name="rect">截取区域 new Rect(x轴偏移，y轴偏移，截取长度，截取高度)</param>
    /// <param name="camera">指定相机</param>
    /// <param name="path">截取图片保存路径 默认为空不需要保存到本地</param>
    public IEnumerator Shot(Rect rect, Camera camera = null, string path = null)
    {
        if (!camera)//如果不选定截图相机则默认为主相机截图
        {
            camera = Camera.main;
        }
        RenderTexture rt = new RenderTexture((int)(Screen.width), (int)(Screen.height), 0);//先设置一个RenderTexture，大小为屏幕分辨率
        camera.targetTexture = rt;
        camera.Render();//手动开启截图相机的渲染
        RenderTexture.active = rt;//激活这个RenderTexture

        //验算是否超出屏幕渲染，如果超出则取最大边界
        float width = rect.width + rect.x > Screen.width ? Screen.width - rect.x : rect.width;
        float height = rect.height + rect.y > Screen.height ? Screen.height - rect.y : rect.height;


        //新建一个模板Texture2D等待相机渲染图像，设定Textrue2D的大小为我们需要的大小
        Texture2D screenShot = new Texture2D((int)width, (int)height, TextureFormat.ARGB32, false);
        yield return new WaitForEndOfFrame();

        // 注：这个时候，它是从RenderTexture.active中读取像素
        screenShot.ReadPixels(new Rect(rect.x, rect.y, width, height), 0, 0);
        screenShot.Apply();//保存像素信息
                           // 重置相关参数，以使用camera继续在屏幕上显示

        //还原各项截图前得初始设定
        camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        if (path != null)
        {
            //生成png图片保存至目标路径
            byte[] bytes = screenShot.EncodeToPNG();
            
            FileStream fileStream = File.Create(path);
            fileStream.Dispose();
            File.WriteAllBytes(path, bytes);
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();//刷新Unity的资产目录
#endif
    }

    public Texture2D CameraCapture(Camera camera, Rect rect, string path)
    {
        RenderTexture render = new RenderTexture((int)rect.width, (int)rect.height, -1);//创建一个RenderTexture对象 
        var tmp = camera.targetTexture;
        camera.gameObject.SetActive(true);//启用截图相机
        camera.targetTexture = render;//设置截图相机的targetTexture为render
        camera.Render();//手动开启截图相机的渲染

        RenderTexture.active = render;//激活RenderTexture
        Texture2D tex = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);//新建一个Texture2D对象
        tex.ReadPixels(rect, 0, 0);//读取像素
        tex.Apply();//保存像素信息

        //camera.targetTexture = null;//重置截图相机的targetTexture
        RenderTexture.active = null;//关闭RenderTexture的激活状态
        Object.Destroy(render);//删除RenderTexture对象

        /*byte[] bytes = tex.EncodeToPNG();//将纹理数据，转化成一个png图片
        if (path != null)
        {
            //生成png图片保存至目标路径
            
            FileStream fileStream = File.Create(path);
            fileStream.Dispose();
            File.WriteAllBytes(path, bytes);
        }*/
        HuaMian.SetTexture("_MainTex", tex);
        camera.targetTexture = tmp;
        //Debug.Log(string.Format("截取了一张图片: {0}", fileName));

        /*#if UNITY_EDITOR
                UnityEditor.AssetDatabase.Refresh();//刷新Unity的资产目录
        #endif*/

        return tex;//返回Texture2D对象，方便游戏内展示和使用
    }

    


}
