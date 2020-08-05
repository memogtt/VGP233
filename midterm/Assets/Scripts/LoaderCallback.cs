    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool mIsFirstUpdate = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (mIsFirstUpdate)
        {
            mIsFirstUpdate = false;
            Loader.LoaderCallback();
        }

    }
}
