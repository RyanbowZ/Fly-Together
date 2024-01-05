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
            //��ȡȫ��������������·��
            //StartCoroutine(Shot(new Rect(0, 0, Screen.width, Screen.height), null, Application.streamingAssetsPath + "/screenShot.png"));
            StartCoroutine(Shot(new Rect(0, 0, Screen.width, Screen.height), cm, savePath + "/screenShot.png"));
        }*/
        if (Input.GetKey(KeyCode.M))
        {
            CameraCapture(cm, new Rect(0, 0, Screen.width, Screen.height), savePath + "/screenShot2.png");
        }
    }

    /// <summary>
    /// ��ȡָ��Cameraָ�������棬�����浽����
    /// </summary>
    /// <param name="rect">��ȡ���� new Rect(x��ƫ�ƣ�y��ƫ�ƣ���ȡ���ȣ���ȡ�߶�)</param>
    /// <param name="camera">ָ�����</param>
    /// <param name="path">��ȡͼƬ����·�� Ĭ��Ϊ�ղ���Ҫ���浽����</param>
    public IEnumerator Shot(Rect rect, Camera camera = null, string path = null)
    {
        if (!camera)//�����ѡ����ͼ�����Ĭ��Ϊ�������ͼ
        {
            camera = Camera.main;
        }
        RenderTexture rt = new RenderTexture((int)(Screen.width), (int)(Screen.height), 0);//������һ��RenderTexture����СΪ��Ļ�ֱ���
        camera.targetTexture = rt;
        camera.Render();//�ֶ�������ͼ�������Ⱦ
        RenderTexture.active = rt;//�������RenderTexture

        //�����Ƿ񳬳���Ļ��Ⱦ�����������ȡ���߽�
        float width = rect.width + rect.x > Screen.width ? Screen.width - rect.x : rect.width;
        float height = rect.height + rect.y > Screen.height ? Screen.height - rect.y : rect.height;


        //�½�һ��ģ��Texture2D�ȴ������Ⱦͼ���趨Textrue2D�Ĵ�СΪ������Ҫ�Ĵ�С
        Texture2D screenShot = new Texture2D((int)width, (int)height, TextureFormat.ARGB32, false);
        yield return new WaitForEndOfFrame();

        // ע�����ʱ�����Ǵ�RenderTexture.active�ж�ȡ����
        screenShot.ReadPixels(new Rect(rect.x, rect.y, width, height), 0, 0);
        screenShot.Apply();//����������Ϣ
                           // ������ز�������ʹ��camera��������Ļ����ʾ

        //��ԭ�����ͼǰ�ó�ʼ�趨
        camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        if (path != null)
        {
            //����pngͼƬ������Ŀ��·��
            byte[] bytes = screenShot.EncodeToPNG();
            
            FileStream fileStream = File.Create(path);
            fileStream.Dispose();
            File.WriteAllBytes(path, bytes);
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();//ˢ��Unity���ʲ�Ŀ¼
#endif
    }

    public Texture2D CameraCapture(Camera camera, Rect rect, string path)
    {
        RenderTexture render = new RenderTexture((int)rect.width, (int)rect.height, -1);//����һ��RenderTexture���� 
        var tmp = camera.targetTexture;
        camera.gameObject.SetActive(true);//���ý�ͼ���
        camera.targetTexture = render;//���ý�ͼ�����targetTextureΪrender
        camera.Render();//�ֶ�������ͼ�������Ⱦ

        RenderTexture.active = render;//����RenderTexture
        Texture2D tex = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);//�½�һ��Texture2D����
        tex.ReadPixels(rect, 0, 0);//��ȡ����
        tex.Apply();//����������Ϣ

        //camera.targetTexture = null;//���ý�ͼ�����targetTexture
        RenderTexture.active = null;//�ر�RenderTexture�ļ���״̬
        Object.Destroy(render);//ɾ��RenderTexture����

        /*byte[] bytes = tex.EncodeToPNG();//���������ݣ�ת����һ��pngͼƬ
        if (path != null)
        {
            //����pngͼƬ������Ŀ��·��
            
            FileStream fileStream = File.Create(path);
            fileStream.Dispose();
            File.WriteAllBytes(path, bytes);
        }*/
        HuaMian.SetTexture("_MainTex", tex);
        camera.targetTexture = tmp;
        //Debug.Log(string.Format("��ȡ��һ��ͼƬ: {0}", fileName));

        /*#if UNITY_EDITOR
                UnityEditor.AssetDatabase.Refresh();//ˢ��Unity���ʲ�Ŀ¼
        #endif*/

        return tex;//����Texture2D���󣬷�����Ϸ��չʾ��ʹ��
    }

    


}
