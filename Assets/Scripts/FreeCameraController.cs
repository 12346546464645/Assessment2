using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{

    // ģ��
    public Transform model;
    // ��ת�ٶ�
    public float rotateSpeed = 32f;
    public float rotateLerp = 8;
    // �ƶ��ٶ�
    public float moveSpeed = 1f;
    public float moveLerp = 10f;
    // ��ͷ�����ٶ�
    public float zoomSpeed = 10f;
    public float zoomLerp = 4f;

    // �����ƶ�
    private Vector3 position, targetPosition;
    // ������ת
    private Quaternion rotation, targetRotation;
    // �������
    private float distance, targetDistance;
    // Ĭ�Ͼ���
    private const float default_distance = 5f;

    // Use this for initialization
    void Start()
    {
        // ��ת����
        targetRotation = Quaternion.identity;
        // ��ʼλ����ģ��
        targetPosition = model.position;
        // ��ʼ��ͷ����
        targetDistance = default_distance;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");

        // �������ƶ�
        if (Input.GetMouseButton(1))
        {
            dx *= moveSpeed;
            dy *= moveSpeed;
            targetPosition -= transform.up * dy + transform.right * dx;
        }

        // ����Ҽ���ת
        if (Input.GetMouseButton(2))
        {
            dx *= rotateSpeed;
            dy *= rotateSpeed;
            if (Mathf.Abs(dx) > 0 || Mathf.Abs(dy) > 0)
            {
                // ��ȡ�����ŷ����
                Vector3 angles = transform.rotation.eulerAngles;
                // ŷ���Ǳ�ʾ��������˳����ת������angles.x=30����ʾ��x����ת30�㣬dy�ı�����x��ı仯
                angles.x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
                angles.y += dx;
                angles.x -= dy;
                // ��������ͷ��ת
                targetRotation.eulerAngles = new Vector3(angles.x, angles.y, 0);
            }
        }

        // ����������
        targetDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    }

    private void FixedUpdate()
    {
        rotation = Quaternion.Slerp(rotation, targetRotation, Time.deltaTime * rotateLerp);
        position = Vector3.Lerp(position, targetPosition, Time.deltaTime * moveLerp);
        distance = Mathf.Lerp(distance, targetDistance, Time.deltaTime * zoomLerp);
        // ��������ͷ��ת
        transform.rotation = rotation;
        // ��������ͷλ��
        transform.position = position - rotation * new Vector3(0, 0, distance);
    }
}
