using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //public Material dark, lit;
   
    public CharacterController controller;
    //public Button Transition;

    //��������������ʱ���ٶ�
    public float walkSpeed = 5f;

    //�����ܶ�ʱ���ٶ�
    public float runSpeed = 6f;

    //����
    public float gravity = -9.81f;

    //��ά������x��y��z
    Vector3 velocity;
    public Transform groundCheck;

    //��������Ƿ��������ײ�İ뾶
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //�����Ƿ��ڵ�����
    bool isGrounded;
    public float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //�����⣬�Ƿ��ڵ�����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;//�����ڵ����ϣ�����Ϊ0f����-2f����һЩ
        }

        //��Ծ  ����Ĭ�Ͽո������Ծ����
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //������unity��Ĭ�ϡ�W��Ϊ��ǰ����D�����ң���ͨ������x�᷽��������������ˮƽ������˶�������z�ᣬ����������ǰ���ƶ�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        //�����Ƶķ������ٶ���ˣ�����ʵ��������˶���ͬ���������Time.deltaTimeҲ�ǽ��֡������
        controller.Move(move * walkSpeed * Time.deltaTime);

        //��ά�������е�y   y=1/2*g*t*t
        //������ÿһ֡�ı仯
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //��ͬʱ���¼����ϵġ�W���͡�Q�����������ܲ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * runSpeed * Time.deltaTime);
        }
        /*if (Input.GetKey(KeyCode.E))
        {
            Transition.onClick.Invoke();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }*/
        
       
    }

   

    
}
