using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum CameraBehavior
    {
        Normal,
        NormalAdjusted,
        NoX,
        NoZ,
        LookAt,
        Transition
    }

    public GameObject ronny;
    public float scale;

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 normalCameraForward;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeInBehavior;
    [SerializeField]
    private CameraBehavior behavior;


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 direction = (ronny.transform.position - transform.position).normalized;
            direction *= scale;
            transform.position = ronny.transform.position - direction;
        }
    }

   
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x, ronny.transform.position.y, transform.position.z);
        if(behavior == CameraBehavior.Normal)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, transform.position + offset, ref velocity, 1 / speed);
            mainCamera.transform.forward = normalCameraForward;
            timeInBehavior++;
        }
    }
}
