using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_ui : MonoBehaviour
{
    public GameObject normal_ui;
    public GameObject aim_ui;

    public GameObject normal_camera;
    public GameObject aim_camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            normal_ui.SetActive(!normal_ui.activeSelf);
            aim_ui.SetActive(!aim_ui.activeSelf);
            normal_camera.SetActive(!normal_camera.activeSelf);
            aim_camera.SetActive(!aim_camera.activeSelf);
        }
    }
}
