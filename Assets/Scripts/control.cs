using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject human; 
    public float value;
    public Vector3 sizeChange;

    public void MoveLeft()
    {
        value = value - 0.1f;
        human.transform.position = new Vector3(value, 0, 0);
    }


    public void RotateLeft()
    {
        human.transform.Rotate(0f, 0f, 20f);
    }

    public void Grow()
    {
        human.transform.localScale = human.transform.localScale + sizeChange;
    }
}
