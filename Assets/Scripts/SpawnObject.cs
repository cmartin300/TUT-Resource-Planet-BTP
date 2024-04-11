using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] int cost;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>();
	}

	public void Spawn(GameObject objectToSpawn){ 
        if(gm.gold >= cost){
			Instantiate(objectToSpawn);
            gm.gold -= cost;
		}
       
    }


}
