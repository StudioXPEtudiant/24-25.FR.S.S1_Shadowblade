using UnityEngine;

public class Roate : MonoBehaviour
{
    public Transform target; 
    public float distance = 10.0f; 
    public float sensitivityX = 4.0f; 
    public float sensitivityY = 4.0f; 
    public float minYAngle = -20f; 
    public float maxYAngle = 80f; 

    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.RightAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
    }
}