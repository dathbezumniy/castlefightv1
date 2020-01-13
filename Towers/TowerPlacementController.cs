using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placeableObjectPrefabWest;

    [SerializeField]
    private GameObject placeableObjectPrefabEast;


    [SerializeField]
    private GameObject actualObjectPrefabWest;

    [SerializeField]
    private GameObject actualObjectPrefabEast;

    Transform eastTeamBuildings;
    Transform westTeamBuildings;

    private bool team; // false - east / true - west //

    private Grid grid;

    private KeyCode WestObjectHotkey = KeyCode.Q;
    private KeyCode EastObjectHotkey = KeyCode.W;

    private GameObject currentPlaceableObject;


    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        eastTeamBuildings = GameObject.Find("EastBuildings").transform;
        westTeamBuildings = GameObject.Find("WestBuildings").transform;

    }


    // Update is called once per frame
    void Update()
    {
        HandleNewObjectHotKey();

        if (currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            SnapIfClicked();
        }
    }

    private void SnapIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Destroy(currentPlaceableObject);
                if (grid.IsReserved(grid.GetNearestPointOnGrid(hitInfo.point)))
                {
                    if (team)
                    {
                        currentPlaceableObject = Instantiate(actualObjectPrefabWest);
                        currentPlaceableObject.transform.SetParent(westTeamBuildings);
                    }
                    else
                    {
                        currentPlaceableObject = Instantiate(actualObjectPrefabEast);
                        currentPlaceableObject.transform.SetParent(eastTeamBuildings);
                    }
                    
                    grid.ReserveSpace(grid.GetNearestPointOnGrid(hitInfo.point));
                    currentPlaceableObject.transform.position = grid.GetNearestPointOnGrid(hitInfo.point);
                    currentPlaceableObject = null;
                }
                else
                {
                    Debug.Log("you cant build here");
                }
            }
        }
    }



    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        var buildingRenderer = currentPlaceableObject.GetComponent<Renderer>();
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (!grid.IsReserved(grid.GetNearestPointOnGrid(hitInfo.point)))
            {
                currentPlaceableObject.transform.position = grid.GetNearestPointOnGrid(hitInfo.point);
                currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                buildingRenderer.material.SetColor("_Color", new Color(1.0f, 0f, 0f, 0.5f));
            }
            else
            {
                buildingRenderer.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0.5f));
                currentPlaceableObject.transform.position = grid.GetNearestPointOnGrid(hitInfo.point);
                currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            }
            
        }
    }

    private void HandleNewObjectHotKey()
    {
        if (Input.GetKeyDown(WestObjectHotkey))
        {
            if(currentPlaceableObject == null)
            {
                
                currentPlaceableObject = Instantiate(placeableObjectPrefabWest);
                team = true;
            }
            else
            {
                Destroy(currentPlaceableObject);
            }

        }

        if (Input.GetKeyDown(EastObjectHotkey))
        {
            if (currentPlaceableObject == null)
            {

                currentPlaceableObject = Instantiate(placeableObjectPrefabEast);
                team = false;
            }
            else
            {
                Destroy(currentPlaceableObject);
            }

        }
    }
}
