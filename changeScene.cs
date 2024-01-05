using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class changeScene : MonoBehaviour
{
    private bool canMove;
    private float rotateTime;
    [SerializeField] private GameObject world;
    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && canMove){
            canMove = false;
            StartCoroutine(moveSceneCube());
        }
    }

    private IEnumerator moveSceneCube(){
        canMove = false;
        //world.transform.DOLocalRotate();
        yield return new WaitForSeconds(rotateTime);
        canMove = true;
    }

}
