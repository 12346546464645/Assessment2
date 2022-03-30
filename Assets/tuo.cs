using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuo : MonoBehaviour
{
    private Vector3 _vec3TargetScreenSpace;// Ŀ���������Ļ�ռ�����  
    private Vector3 _vec3TargetWorldSpace;// Ŀ�����������ռ�����  
    private Transform _trans;// Ŀ������Ŀռ�任���  
    private Vector3 _vec3MouseScreenSpace;// ������Ļ�ռ�����  
    private Vector3 _vec3Offset;// ƫ�� 

    void Awake() { _trans = transform; }

    IEnumerator OnMouseDown()

    {

        // ��Ŀ�����������ռ�����ת��������������Ļ�ռ�����   

        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);

        // �洢������Ļ�ռ����꣨Zֵʹ��Ŀ���������Ļ�ռ����꣩   

        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

        // ����Ŀ���������������������ռ��е�ƫ����   

        _vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);

        // ����������   

        while (Input.GetMouseButton(0))
        {

            // �洢������Ļ�ռ����꣨Zֵʹ��Ŀ���������Ļ�ռ����꣩  

            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

            // ��������Ļ�ռ�����ת��������ռ����꣨Zֵʹ��Ŀ���������Ļ�ռ����꣩������ƫ�������Դ���ΪĿ�����������ռ�����  

            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

            // ����Ŀ�����������ռ�����   

            _trans.position = _vec3TargetWorldSpace;

            // �ȴ��̶�����   

            yield return new WaitForFixedUpdate();
        }
    }
}