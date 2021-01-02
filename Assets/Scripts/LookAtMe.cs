using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {
        Quaternion temp = Quaternion.LookRotation ((Camera.main.transform.position - transform.position).normalized, Vector3.up);
        transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, temp.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

}
