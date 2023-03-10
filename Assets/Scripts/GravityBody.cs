using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    private static float GRAVITY_FORCE = 800;
    
    public Vector3 GravityDirection
    {
        get
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Debug.Log("aaaaaaa");
                return hit.normal;
            }
            else
            {
                return Vector3.zero;
            }
        }
    }

    private Rigidbody _rigidbody;
    private List<GravityArea> _gravityAreas;

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityAreas = new List<GravityArea>();
    }
    
    void FixedUpdate()
    {
        Vector3 targetGravityDirection = Vector3.up;
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -targetGravityDirection);

        Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation * _rigidbody.rotation, Time.fixedDeltaTime * 3f);
        _rigidbody.MoveRotation(newRotation);

        _rigidbody.AddForce(GravityDirection * (GRAVITY_FORCE * Time.fixedDeltaTime), ForceMode.Acceleration);
    }

    public void AddGravityArea(GravityArea gravityArea)
    {
        _gravityAreas.Add(gravityArea);
    }

    public void RemoveGravityArea(GravityArea gravityArea)
    {
        _gravityAreas.Remove(gravityArea);
    }
}