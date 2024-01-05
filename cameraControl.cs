using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
 
 
public class cameraControl : MonoBehaviour
{
    private Transform myTransform;
    public static cameraControl instance;
    public float distance;  //距离
    public GameObject target;
    float time = 0;
    public bool isDragingSlider = false;
    public Vector3 initTargetPos;
    void Start()
    {
        time = Time.time;
        myTransform = transform;
        initTargetPos = target.transform.position;
        //初始化相机
        distance = Vector3.Distance(target.transform.position, transform.position);
        Camera.main.transform.position = target.transform.position - this.transform.forward * distance;
    }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
 
        //鼠标滚轮事件
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
 
            scrollEventByTouShi(Input.GetAxis("Mouse ScrollWheel"));        
        }
        //实现左键拖动平移相机
        if (Input.GetMouseButton(0)&& !isDragingSlider)
        {
            Vector3 p0 = Camera.main.transform.position;
            Vector3 p01 = p0 - Camera.main.transform.right * Input.GetAxisRaw("Mouse X") * 0.08f * Time.timeScale;
            Vector3 p03 = p01 - Camera.main.transform.up * Input.GetAxisRaw("Mouse Y") * 0.08f * Time.timeScale;
 
             Camera.main.transform.position = p03;
            Vector3 change = p03 - p0;
            target.transform.position =change + target.transform.position;
 
            
        }
        //鼠标右键旋转物体
        if (Input.GetMouseButton(1) && !isDragingSlider)
        {
            float axis = Input.GetAxis("Mouse X");
            float axis1 = Input.GetAxis("Mouse Y");
            this.transform.Rotate(Vector3.up * Time.deltaTime * 100 * axis,Space.World);
            this.transform.Rotate(-Vector3.right * Time.deltaTime * 100 * axis1);
 
            Camera.main.transform.position = target.transform.position - this.transform.forward * distance;
 
        }
 
    }

 
    //透视状态下，鼠标滚轮前进后退功能
    public void scrollEventByTouShi(float vall)
    {
        if (vall > 0) //想向前移动
        {
              myTransform.position += myTransform.forward * vall * 30;
              distance = Vector3.Distance(target.transform.position, transform.position);
 
        }
        else   //向后退
        {            
              myTransform.position += myTransform.forward * vall * 30;
              distance = Vector3.Distance(target.transform.position, transform.position);
        }
    }
 
}