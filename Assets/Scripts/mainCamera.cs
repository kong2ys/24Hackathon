using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainCamera : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    
    public Transform target;//Player
    [SerializeField]
    private float rotSensitive = 3f;//카메라 회전 감도
    [SerializeField]
    private float dis = 2f;//카메라와 플레이어사이의 거리
    [SerializeField]
    private float RotationMin = -10f;//카메라 회전각도 최소
    [SerializeField]
    private float RotationMax = 80f;//카메라 회전각도 최대
    [SerializeField]
    private float smoothTime = 0.12f;//카메라가 회전하는데 걸리는 시간
    
    private Vector3 targetRotation;
    private Vector3 currentVel;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (_uiManager.deathPanel.activeSelf == false && _uiManager.pausePanel.activeSelf == false && _uiManager.clearPannel.activeSelf == false)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            
            if (target.gameObject.activeSelf == true)
            {
                Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;
                Xaxis = Xaxis - Input.GetAxis("Mouse Y") * rotSensitive;
         

                Xaxis = Mathf.Clamp(Xaxis,RotationMin,RotationMax);
        

                targetRotation = Vector3.SmoothDamp(targetRotation,new Vector3(Xaxis,Yaxis),ref currentVel,smoothTime);
                transform.eulerAngles=targetRotation;


                transform.position = target.position - transform.forward*dis + new Vector3(0,1,0);
            }
        }
    }
}