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
        // Display.displays[0] 是主要的默认显示，并始终为 ON，因此从索引 1 开始。
        // 检查是否有其他可用的显示，并激活每个显示。

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
