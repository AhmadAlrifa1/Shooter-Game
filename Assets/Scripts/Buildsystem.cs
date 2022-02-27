using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildsystem : MonoBehaviour
{

    [SerializeField]
    Transform CamChild;

    [SerializeField]
    Transform FloorBuild;

    public GameObject FloorBuildObject;

    [SerializeField]
    Transform FloorPrefab;

    [SerializeField]
    Transform StairPrefab;

    [SerializeField]
    Transform StairBuild;

    public GameObject StairBuildObject;

    RaycastHit Hit;

    public GameObject Build;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Build.activeSelf == true) 
        {
        if(Physics.Raycast(CamChild.position,CamChild.forward,out Hit, 6f))
        {
            if (FloorBuildObject.activeSelf == true)
            {
                FloorBuild.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x/3) * 3 : 3 , Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y/0) * 0 : 0 + FloorBuild.localScale.y, Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z/3) * 3 : 0);
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(FloorPrefab, FloorBuild.position,Quaternion.identity);
            }
            }
            else if (StairBuildObject.activeSelf == true)
            {
            StairBuild.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x/3) * 3 : 3 , Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y/0) * 0 : 0 + FloorBuild.localScale.y, Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z/3) * 3 : 0);
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(StairPrefab, StairBuild.position,Quaternion.identity);
            }
            }
        }
        }
    }
}
