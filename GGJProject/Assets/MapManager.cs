using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    GameObject[] activeTiles= new GameObject[6];
    public GameObject ramp;
    public GameObject spikes;
    public GameObject spike;
    public GameObject boosts;
    public GameObject boost;
    bool picked;
    //public Vector3 player;
    float distanceBetweenTiles = 18f;
    int tileCount;
    int activeTile;
	// Use this for initialization
	void Start ()
    {
        activeTiles[0] = Instantiate(ramp, new Vector3(0, 0, 0), Quaternion.identity);
        activeTiles[0].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[0].transform.localScale = (new Vector3(100, 100, 100));
        activeTiles[1] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 1, 0, 0), Quaternion.identity);
        activeTiles[1].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[1].transform.localScale = (new Vector3(100, 100, 100));
        activeTiles[2] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 2, 0, 0), Quaternion.identity);
        activeTiles[2].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[2].transform.localScale = (new Vector3(100, 100, 100));
        activeTiles[3] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 3, 0, 0), Quaternion.identity);
        activeTiles[3].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[3].transform.localScale = (new Vector3(100, 100, 100));
        activeTiles[4] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 4, 0, 0), Quaternion.identity);
        activeTiles[4].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[4].transform.localScale = (new Vector3(100, 100, 100));
        activeTiles[5] = Instantiate(ramp, new Vector3(distanceBetweenTiles * 5, 0, 0), Quaternion.identity);
        activeTiles[5].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[5].transform.localScale = (new Vector3(100, 100, 100));
        tileCount = 6;
        activeTile = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("Player").transform.position.x >= (tileCount - 2) * distanceBetweenTiles || GameObject.Find("Player2").transform.position.x >= (tileCount - 2) * distanceBetweenTiles)
        {
            DestroyMapTile();
            SpawnMapTile();
        }
    }
    void SpawnMapTile()
    {
        activeTiles[activeTile] = Instantiate(ramp, new Vector3(distanceBetweenTiles * tileCount, 0, 0), Quaternion.identity);
        activeTiles[activeTile].transform.Rotate(new Vector3(-90, 0, 0));
        activeTiles[activeTile].transform.localScale = (new Vector3(100, 100, 100));
        activeTile += 1;
        if (activeTile >= 6)
        {
            activeTile = 0;
        }
        SpawnPickUps(Random.Range(0, 4));
        tileCount += 1;
    }
    void DestroyMapTile()
    {
        Destroy(activeTiles[activeTile]);
    }
    void SpawnPickUps(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int type = Random.Range(0, 2);
            if (type == 0)
            {
                spikes = Instantiate(spike, new Vector3(Random.Range((distanceBetweenTiles * tileCount) + 2, (distanceBetweenTiles * tileCount) -2), 3, Random.Range(-4, 4)), Quaternion.identity);
            }
            else if (type == 1)
            {
                boosts = Instantiate(boost, new Vector3(Random.Range((distanceBetweenTiles * tileCount) + 2, (distanceBetweenTiles * tileCount) - 2), 3, Random.Range(-4, 4)), Quaternion.identity);
            }
        }
    }
    void DestroyPickUps()
    {
        Destroy(spikes);
        Destroy(boosts);
    }
}
