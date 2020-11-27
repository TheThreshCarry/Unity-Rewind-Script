using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindControll3D : MonoBehaviour
{
    List<Vector3> positions;
    List<Quaternion> rotations;
    Rigidbody rb;
    public bool isRewinding = false;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isRewinding = true;
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            isRewinding = false;
        }
    }
    private void FixedUpdate()
    {
        if (isRewinding && positions.Count != 2 && rotations.Count != 1)
        {
            rb.isKinematic = true;
            transform.position = positions[0];
            transform.rotation = rotations[0];
            positions.RemoveAt(0);
            rotations.RemoveAt(0);
            Debug.Log("Working");
        }
        else if (positions.Count < Mathf.RoundToInt(5f * 1f / Time.fixedDeltaTime))
        {
            rb.isKinematic = false;
            positions.Insert(0, transform.position);
            rotations.Insert(0, transform.rotation);

        }
    }
}
