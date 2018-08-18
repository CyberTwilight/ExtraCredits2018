using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake2 : MonoBehaviour {


    private Transform CamTransform;

    public float ShakeDuration;

    public float ShakeAmount;

    public float DecreaseFactor;

    public Vector3 OriginalPos;

    void Awake()

    {

        if (CamTransform == null)

        {

            CamTransform = GetComponent<Transform>();

        }

    }



    void OnEnable()

    {

        OriginalPos = CamTransform.localPosition;

    }



    void Update()

    {

        if (ShakeDuration > 0)

        {

            CamTransform.localPosition = OriginalPos + Random.insideUnitSphere * ShakeAmount;
            ShakeDuration -= DecreaseFactor;

        }

        else

        {

            ShakeDuration = 0f;

            CamTransform.localPosition = OriginalPos;

        }

    }
}
