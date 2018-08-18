using UnityEngine;

using System.Collections;



public class CameraShake : MonoBehaviour

{

    // Transform of the camera to shake. Grabs the gameObject's transform

    // if null.

    private Transform camTransform;



    // How long the object should shake for.

    private float shakeDuration = 0f;



    // Amplitude of the shake. A larger value shakes the camera harder.

    private float shakeAmount = 0.7f;

    private float decreaseFactor = 1.0f;



    Vector3 originalPos;

    public Transform CamTransform;
    //public Transform camTransform;
    public float ShakeDuration;
    //public float shakeDuration;
    public float ShakeAmount;
    //public float shakeAmount;
    public float DecreaseFactor;
    //public float decreaseFactor;
    public Vector3 OriginalPos;
    //public Vector3 originalPos;

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



            ShakeDuration -= Time.deltaTime * DecreaseFactor;

        }

        else

        {

            ShakeDuration = 0f;

            CamTransform.localPosition = OriginalPos;

        }

    }

}