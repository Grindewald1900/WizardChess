using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerater : MonoBehaviour
{
    public GameObject _whiteCamp;
    public GameObject _blackCamp;
    public static ObjectGenerater SharedInstance;

    private void Start()
    {
        SharedInstance = this;
    }

    public GameObject GetCampSphere(bool isBlack)
    {
        if (isBlack) return Instantiate(_blackCamp);
        return Instantiate(_whiteCamp);
    }
}
