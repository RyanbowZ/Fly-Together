using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cubeInteractive : MonoBehaviour
{
    #region objects
    //这个脚本用于相互场景间物体的对应
    //相对应场景的交互
    [Header("scence1&4")]
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject two;
    #endregion

    #region varibles
    [Header("varibles")]
    [SerializeField] private float riseHeight;//物体升起的高度
    [SerializeField] private float lowerHeight;//物体降低的高度
    [SerializeField] private float objectsChangeTime;//物体改变的时间
    private bool reNew;
    #endregion

    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo)){
                Debug.DrawLine(ray.origin,hitInfo.point);
                GameObject gameObj = hitInfo.collider.gameObject;
                Debug.Log("click object name is " + gameObj.name);
                if(gameObj.tag == "playable" && reNew){
                    //do something
                }
            }
    }
    }
    //物体升起 direction是面的方向
    private IEnumerator objectRise(GameObject obj,int direction){
        reNew = true;
        if(direction == 1){
            //obj.transform.DOLocalMoveX();
            yield return new WaitForSeconds(objectsChangeTime);
        }else{
            //obj.transform.DOLocalMoveY();
            yield return new WaitForSeconds(objectsChangeTime);
        }
        reNew = false;
    }
    //物体降低
    private IEnumerator objectLower(GameObject obj,int direction){
        reNew = true;
        if(direction == 1){
            //obj.transform.DOLocalMoveX();
            yield return new WaitForSeconds(objectsChangeTime);
        }else{
            //obj.transform.DOLocalMoveY();
            yield return new WaitForSeconds(objectsChangeTime);
        }
        reNew = false;
    }
}
