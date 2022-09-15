using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // moveSpeed = 2.0f;  // Units per second
    }

    void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            // Turn towards Mouse
            var position = transform.position;
            var positionOnScreen = Camera.main.WorldToViewportPoint (position);
            var mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
            
            // Move toward Mouse
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var obj_position = position;
            targetPos.z = obj_position.z;
            obj_position = Vector3.MoveTowards(obj_position, targetPos, moveSpeed * Time.deltaTime);
            transform.position = obj_position;
            
        }

    }
    
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    
 }
