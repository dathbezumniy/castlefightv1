using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedMovement : MonoBehaviour
{
    private Vector3 newposition;
    public float speed;
    public float walkRange;

    public GameObject graphics;


    // Start is called before the first frame update
    void Start()
    {
        newposition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (Vector3.Distance(newposition, this.transform.position) > walkRange)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, newposition, speed * Time.deltaTime);
                Quaternion transRot = Quaternion.LookRotation(newposition - this.transform.position, Vector3.up);
                graphics.transform.rotation = Quaternion.Slerp(transRot, graphics.transform.rotation,  0.2f);
            }
        }
    }
}
