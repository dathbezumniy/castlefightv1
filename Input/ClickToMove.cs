using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Pathfinding;

public class ClickToMove : MonoBehaviour
{
    private Animator Animator => GetComponent<Animator>();
    private bool mRunning = false;
    private const float rotSpeed = 50f;

    private Seeker Seeker => GetComponent<Seeker>();
    private CharacterController CharController => GetComponent<CharacterController>();

    // Start is called before the first frame update


    // Update is called once per frame
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                InstantlyTurn(hit.point);
                Seeker.StartPath(transform.position, hit.point);
            }
        }
        
        if (CharController.velocity != Vector3.zero)
        {
            mRunning = true;
            Animator.SetBool("running", mRunning);
        }

        if (CharController.velocity == Vector3.zero)
        {
            mRunning = false;
            Animator.SetBool("running", mRunning);
        }

    }




    private void InstantlyTurn(Vector3 destination)
    {
        if ((destination - transform.position).magnitude < 1f) return;

        Vector3 direction = (destination - transform.position);
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * rotSpeed);
    }

}
