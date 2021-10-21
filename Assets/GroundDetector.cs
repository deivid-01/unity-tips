using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerGround;
    public static bool onGround;
    void Start()
    {
        
    }

    // Update is called once per frame
 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * distance);
    }
}
