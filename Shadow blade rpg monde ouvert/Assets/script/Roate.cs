using UnityEngine;

public class Roate : MonoBehaviour
{
    public Transform target; 
    public float distance = 10.0f;
    public float distanceMax = 10f;
    public float distanceMin = 0f;
    public float sensitivityX = 4.0f; 
    public float sensitivityY = 4.0f; 
    public float minYAngle = -20f; 
    public float maxYAngle = 80f; 

    private float currentX = 0f;
    private float currentY = 0f;
    public bool premiere;
    public float distanceEncours;

    public float scrollSensitivity = 1.0f;
    void Start()
    {
        premiere = false;
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        distance = distanceMax;
        distance = 5f;
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
        
        //if()returne; bloque tout la suite de script
        if (!premiere)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                // Exemple d'action : afficher la direction dans la console
                if (scroll > 0)
                {
                    distance += 5f * Time.deltaTime ;
                }
                else if (scroll < 0)
                {
                    distance += -5f * Time.deltaTime;
                }

                if (distance >= distanceMax)
                {
                    distance = distanceMax;
                }

                if (distance <= distanceMin)
                {
                    distance = distanceMin;
                }

                if (Input.GetKeyDown(KeyCode.J))
                {
                    distanceMin = 0f;
                    distance = 0f;
                }

                if (distance <= 0)
                {
                    distance = distanceMin;
                } 
            }
            
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            premiere = !premiere;
            if (premiere == true)
            {
                distanceEncours = distance;
                distance = 0;
            }
            else
            {
                distance = distanceEncours;
            }
        }
    }
    

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
    }
}