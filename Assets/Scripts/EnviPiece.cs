using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviPiece : MonoBehaviour
{
	private GameManager gm;
	private Camera mainCam;
	[SerializeField] Transform objectToPlace;

	bool isSelected;

	[SerializeField] float waitTimeBtwGold;
	private float timer;
	[SerializeField] int goldIncrease;

	private AudioSource source;


	[SerializeField] GameObject effect;
	[SerializeField] float timeToLive;

	

	private void Awake()
	{
		source = GetComponent<AudioSource>();
		mainCam = Camera.main;
		gm = FindAnyObjectByType<GameManager>();

		isSelected = true;
		transform.position = Vector3.zero;
		timer = waitTimeBtwGold;
	}

	private void Update()
	{
		if(isSelected){
			Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast(ray, out hitInfo))
			{
				objectToPlace.position = hitInfo.point;
				objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
			}

		}

		if (Input.GetMouseButtonDown(0) && isSelected)
		{
			Instantiate(effect, transform.position, Quaternion.identity);
			source.pitch = Random.Range(0.75f, 1.25f);
			source.Play();
			transform.parent = gm.planet.transform;
			isSelected = false;
		}

		if(timer <= 0){ 
			
			gm.gold += goldIncrease;
			timer = waitTimeBtwGold;
		} else{ 
			timer -= Time.deltaTime;
		}

		if(timeToLive < 0) 
		{
			Instantiate(effect, transform.position, Quaternion.identity);
			GameObject.Destroy(this.gameObject);
		}
		else
		{
			timeToLive -= Time.deltaTime;
		}

	}
}
