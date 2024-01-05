using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pictureClick : MonoBehaviour
{
    //该脚本作用处理了点击图片在场景中生成物体的功能
    [SerializeField] private GameObject bridge;
    


    //生成桥（在满足条件的时候进行调用
    public void bridgePicture(){
        //use shader or something
        bridge.SetActive(true);
    }
}
