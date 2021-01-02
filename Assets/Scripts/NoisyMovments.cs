using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class NoisyMovments : MonoBehaviour
{

    Vector3 StartPos;
    Vector3 RandomRang_Value;
    public float RandomScaler = 1f;

    // Update is called once per frame
    private void Start ()
    {
        StartPos = transform.localPosition;
        RandomRang_Value = new Vector3 (Random.Range (-.2f, .2f), Random.Range (-.2f, .2f), Random.Range (-.2f, .2f));

    }
    void Update ()
    {
        transform.localPosition = StartPos + (new Vector3 (Mathf.Sin (Time.time) * RandomRang_Value.x * RandomScaler, Mathf.Cos (Time.time) * RandomRang_Value.y * RandomScaler, Mathf.Sin (Time.time) * RandomRang_Value.z * RandomScaler));
    }
}
