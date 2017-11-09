using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraScript : MonoBehaviour {

    private GameObject terrain;
    private Terrain terrainComponent;
    private TerrainCollider terrainCollider;
    private TerrainData terrainData;

    private static int mapSize_W,mapSize_H;
    private static int mapAlphaSize_W, mapAlphaSize_H;

    private float Alpha = 0;

    private float[,,] AlphaMap;
    private float[,,] AlphaMapOrg;

    public float AriaSize = 5;

    public GameObject GrowEfe;
    private ParticleSystem GrowParm;
    private ParticleSystem.ShapeModule Shape;
    private ParticleSystem.ShapeModule ShapeChild;

    void Start()
    {
        terrainComponent = this.GetComponent<Terrain>();
        terrainCollider = this.GetComponent<TerrainCollider>();

        mapSize_W = terrainComponent.terrainData.heightmapWidth;
        mapSize_H = terrainComponent.terrainData.heightmapHeight;

        mapAlphaSize_W = terrainComponent.terrainData.alphamapWidth;
        mapAlphaSize_H = terrainComponent.terrainData.alphamapHeight;


        Debug.Log("Width:" + mapSize_W);
        Debug.Log("Height:" + mapSize_H);

        Debug.Log("AlphaWidth:" + mapAlphaSize_W);
        Debug.Log("AlphaHeight:" + mapAlphaSize_H);

        AlphaMap = new float[mapAlphaSize_W, mapAlphaSize_W, 2];
        AlphaMapOrg = new float[mapAlphaSize_W, mapAlphaSize_W, 2];

        for (var y = 0; y < mapAlphaSize_H; y++)
        {
            for (var x = 0; x < mapAlphaSize_W; x++)
            {
                var norX = x * 1.0f / (terrainComponent.terrainData.alphamapWidth - 1);
                var norY = y * 1.0f / (terrainComponent.terrainData.alphamapHeight - 1);

                //var angle = terrainComponent.terrainData.GetSteepness(norX, norY);

                
                AlphaMapOrg[x, y, 0] = 1;
                
            }
        }

        terrainComponent.terrainData.SetAlphamaps(0, 0, AlphaMapOrg);
        //var terrainToPopulate = transform.gameObject.GetComponent<Terrain>();
        //terrainToPopulate.terrainData.SetDetailResolution(mapSize, mapSize);
        //
        //int[,] newMap = new int[mapSize, mapSize];
        //
        //for (int i = 0; i < mapSize; i++)
        //{
        //    for (int j = 0; j < mapSize; j++)
        //    {
        //        // Sample the height at this location (note GetHeight expects int coordinates corresponding to locations in the heightmap array)
        //        float height = terrainToPopulate.terrainData.GetHeight(i, j);
        //        if (height < 10.0f)
        //        {
        //            newMap[i, j] = 6;
        //        }
        //        else
        //        {
        //            newMap[i, j] = 0;
        //        }
        //    }
        //}
        //terrainToPopulate.terrainData.SetDetailLayer(0, 0, 0, newMap);

        AlphaMap = AlphaMapOrg;
    }

    // Update is called once per frame
    void Update ()
    {
        AlphaMap[150, 150, 1] = Alpha;
        AlphaMap[150, 150, 0] = 1 - Alpha;


        Alpha += 0.01f;

        terrainComponent.terrainData.SetAlphamaps(0, 0, AlphaMap);

        //terrainComponent.terrainData.SetAlphamaps();

        if (AriaSize > 5)
        {
            AriaSize -= 0.5f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //var mapX = collision.contacts[0].point.z * mapSize_W / terrainComponent.terrainData.size.x;
        //var mapZ = collision.contacts[0].point.x * mapSize_H / terrainComponent.terrainData.size.z;
        //
        //AlphaMap[(int)(mapX), (int)(mapZ), 1] = 0.8f;
        //AlphaMap[(int)(mapX), (int)(mapZ), 0] = 0.2f;

        //float[,,] AlphaMap = new float[mapAlphaSize_W, mapAlphaSize_W, 2];
        //AlphaMap = AlphaMapOrg;

        var mapX = collision.contacts[0].point.z * mapSize_W / terrainComponent.terrainData.size.x;
        var mapZ = collision.contacts[0].point.x * mapSize_H / terrainComponent.terrainData.size.z;
        var mapR = AriaSize * mapSize_W / terrainComponent.terrainData.size.z;

        int z1 = (int)Mathf.Max(-mapR, -mapZ);
        int z2 = (int)Mathf.Min(mapR, -mapZ + mapSize_H - 1);

        for (var z = z1; z <= z2; z++)
        {
            int mapW = (int)Mathf.Sqrt(mapR * mapR - z * z);
            int x1 = (int)Mathf.Max(-mapW, -mapX);
            int x2 = (int)Mathf.Min(mapW, -mapX + mapSize_W - 1);
            for (var x = x1; x <= x2; x++)
            {
                if ((x + mapX) > 0 && (x + mapX) < mapAlphaSize_W && (z + mapZ) > 0 && (z + mapZ) < mapAlphaSize_H)
                {
                    if (!(collision.gameObject.tag == "Tornado")) {
                        //Random.Range(0.1f, 0.5f);
                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] += Random.Range(0.001f, 0.01f);

                        if (AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] > 1) {
                            AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] = 1;
                        }

                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] = 1 - AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1];
                    }
                    else {
                        //Random.Range(0.1f, 0.5f);
                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] += Random.Range(0.001f, 0.01f);

                        if (AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] > 1) {
                            AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] = 1;
                        }

                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] = 1 - AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0];
                    }
                }
            }
        }

        //terrainComponent.terrainData.SetAlphamaps(0, 0, AlphaMap);
    }
}
