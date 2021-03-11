using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public float timer;
	public float rate;
	public Camera m_Camera;
	public GameObject bulletPrefab;
	private GameObject bullet;
	private RaycastHit hitInfo;
	private Vector3 targetPoint;
	public GameObject bulletPoint;
	public LayerMask layer_Layer;

	public GameObject turret;

	void Start()
    {
		timer = 0.0f;
		rate = 10.0f;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Mouse0))//按下滑鼠左鍵
		{
			timer += Time.deltaTime;//計時器計時
			if (timer > 1f / rate)//如果計時大於子彈的發射速率（rate每秒幾顆子彈）
			{
				/*
				//通過攝像機在螢幕中心點位置發射一條射線
				Ray ray = m_Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height*0.77f, 0));
				if (Physics.Raycast(ray, out hitInfo))//如果射線碰撞到物體
				{
					targetPoint = hitInfo.point;//記錄碰撞的目標點
												//Debug.DrawLine(m_Camera.transform.position, hitInfo.point,Color.red,0.2f);
				}
				//在槍口的位置例項化一顆子彈，按子彈發射點出的旋轉，進行旋轉
				bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
				bullet.transform.LookAt(targetPoint);//子彈的Z軸朝向目標
				Destroy(bullet, 5);//在10S後銷燬子彈
				*/
				bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, turret.transform.rotation);
				Destroy(bullet, 5);//在10S後銷燬子彈
				timer = 0;//時間清零
			}
		}
		Debug.DrawLine(targetPoint, bulletPoint.transform.position, Color.green, 0.2f);
	}
}
