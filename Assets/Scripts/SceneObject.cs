using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    protected  void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] ����Ҫ��Ĭ����ʾ����ʼ��Ϊ ON����˴����� 1 ��ʼ��
        // ����Ƿ����������õ���ʾ��������ÿ����ʾ��

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
