using UnityEngine;


[ExecuteInEditMode]
public class CameraForward : MonoBehaviour
{
    public Vector3 forward;

    void Start()
    {
        
    }


    void Update()
    {
        forward = transform.forward;
    }
}
