using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    public GameObject[] activeTiles= new GameObject[4];
    public GameObject ramp;
    public GameObject spike;
    public GameObject boost;
    public Vector3 player;
    float distanceBetweenTiles = 18;
    int tileCount;
    int activeTile;
	// Use this for initialization
	void Start ()
    {
        activeTiles[0] = Instantiate(ramp, new Vector3(0, 0, 0), Quaternion.identity);
        activeTiles[0].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[1] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 1, 0, 0), Quaternion.identity);
        activeTiles[1].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[2] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 2, 0, 0), Quaternion.identity);
        activeTiles[2].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[3] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 3, 0, 0), Quaternion.identity);
        activeTiles[3].transform.Rotate(new Vector3(-90, 0, 0));
        tileCount = 4;
        activeTile = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.Find("Player").transform.position;
        if (player.x >= (tileCount - 2) * distanceBetweenTiles)
        {
            DestroyMapTile();
            SpawnMapTile();
        }
	}
    void SpawnMapTile()
    {
        activeTiles[activeTile] = Instantiate(ramp, new Vector3(distanceBetweenTiles * tileCount, 0, 0), Quaternion.identity);
        activeTiles[activeTile].transform.Rotate(new Vector3(-90, 0, 0));
        activeTile += 1;
        if (activeTile >= 4)
        {
            activeTile = 0;
        }
        tileCount += 1;
    }
    void DestroyMapTile()
    {
        Destroy(activeTiles[activeTile]);
    }
    void SpawnPickUps()
    {

    }
}
