using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PictureDrop : MonoBehaviour
{
    [Header("pictures")]
    [SerializeField] private Image picture1;
    [SerializeField] private Image picture2;
    [SerializeField] private Image picture3;
    [SerializeField] private Image picture4;

    [Header("totalNum")]
    [SerializeField] public int picNumber; //拍照图片的总数量
    [SerializeField] public int picIndex; //照片的列表，从下向上逐渐增加（最下边的是1
    
    public void imageDrop(){
        
        for(int i=1;i <= picNumber; i++){
            StartCoroutine(eachImageDown(i));
        }
    }
    public void imageUp(){
        for(int i=1;i <= picNumber; i++){
            StartCoroutine(eachImageUp(i));
        }
    }

    private IEnumerator eachImageDown(int picIndexNumber){
        if(picIndexNumber == 1){

            picture1.transform.DOLocalMoveY(-210,0.3f);
            picture1.transform.DOLocalRotate(new Vector3(0,0,-5),0.2f);
            yield return new WaitForSeconds(0.3f);

        }else if(picIndexNumber == 2){

            picture2.transform.DOLocalMoveY(-80,0.3f);
            picture2.transform.DOLocalRotate(new Vector3(0,0,5),0.2f);
            yield return new WaitForSeconds(0.3f);

        }else if(picIndexNumber == 3){

            picture3.transform.DOLocalMoveY(73,0.3f);
            picture3.transform.DOLocalRotate(new Vector3(0,0,-5),0.2f);
            yield return new WaitForSeconds(0.3f);

        }else if(picIndexNumber == 4){

            picture4.transform.DOLocalMoveY(202,0.3f);
            picture4.transform.DOLocalRotate(new Vector3(0,0,5),0.2f);
            yield return new WaitForSeconds(0.3f);

        }else if(picIndexNumber == 5){


        }else{


        }

        
    }
    private IEnumerator eachImageUp(int picIndexNumber){
        if(picIndexNumber == 1){
            picture1.transform.DOLocalMoveY(327,0f);
            yield return new WaitForSeconds(2f);

        }else if(picIndexNumber == 2){
            picture2.transform.DOLocalMoveY(327,0f);
            yield return new WaitForSeconds(2f);

        }else if(picIndexNumber == 3){
            picture3.transform.DOLocalMoveY(327,0f);
            yield return new WaitForSeconds(2f);

        }else if(picIndexNumber == 4){
            picture4.transform.DOLocalMoveY(327,0f);
            yield return new WaitForSeconds(2f);

        }else if(picIndexNumber == 5){


        }else{


        }

        
    }

}
