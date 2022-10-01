using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDestination : MonoBehaviour
{
    public enum DestinationTag
    { 
        ENTER, A, B, C  //ABC代表三个地点
    }

    public DestinationTag destinationTag;
}
