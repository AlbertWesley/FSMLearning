using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrips : MonoBehaviour {

    private Transform Turret;
    private float curSpeed, targetSpeed, rotSpeed;
    private float maxForwardSpeed = 50f;
    private float maxBackwardSpeed = -50f;
	void Start () {
        rotSpeed = 35f;
        Turret = gameObject.transform.GetChild(0).transform;
        var sss = 1;
        var ttt = 2;//更改动力学模型
	}

	// Update is called once per frame
	void Update () {
        UpdateControl();
	}
    void UpdateControl()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray RayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist = 0;
        if(playerPlane.Raycast(RayCast,out dist))
        {
            Vector3 rayHitPoint = RayCast.GetPoint(dist);
            Quaternion targetRotation = Quaternion.LookRotation(rayHitPoint - transform.position);
            Turret.rotation = Quaternion.Slerp(Turret.rotation, targetRotation, 0.05f);
        }
        if(Input.GetKey(KeyCode.W))
        {
            targetSpeed = maxForwardSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetSpeed = maxBackwardSpeed;
        }
        else
        {
            targetSpeed = 0;
        }
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -rotSpeed*Time.deltaTime, 0));
         }
         if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }
        curSpeed = Mathf.Lerp(curSpeed,targetSpeed,0.04f);
        this.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
    }
}
