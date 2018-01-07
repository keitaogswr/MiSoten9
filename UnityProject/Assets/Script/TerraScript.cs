using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TerraScript : MonoBehaviour
{

    private GameObject terrain;
    private Terrain terrainComponent;
    private TerrainCollider terrainCollider;
    private TerrainData terrainData;

    private static int mapSize_W, mapSize_H;
    private static int mapAlphaSize_W, mapAlphaSize_H;

    private float Alpha = 0;

    private float[,,] AlphaMap;
    private float[,,] AlphaMapOrg;
    
    //public float AriaSize = 5;

    public GameObject DominateBarObj;
    public GameObject DominateBarObj_2P;
    private DominateBar DominateScript;
    private DominateBar DominateScript_2P;

    private const float UpdateDeray = 0.1f;
    private float UpdateTimer = 0;

    private const float TeraCheckDeray = 0.5f;
    private float TeraCheckTimer = 0;

    [SerializeField]
    private int DominateCnt;
    [SerializeField]
    private int DominateCntMax;

    Thread thread;

    Object sync = new Object();

    void Start()
    {
        terrainComponent = this.GetComponent<Terrain>();
        terrainCollider = this.GetComponent<TerrainCollider>();

        //terrainComponent.terrainData.alphamapResolution = 256;

        //マップの高さ用２次元配列「W、H」
        mapSize_W = terrainComponent.terrainData.heightmapWidth;
        mapSize_H = terrainComponent.terrainData.heightmapHeight;

        //マップの染色用２次元配列「同上」
        mapAlphaSize_W = terrainComponent.terrainData.alphamapWidth;
        mapAlphaSize_H = terrainComponent.terrainData.alphamapHeight;

        //マップの塗られている比率カウント用変数の初期化
        DominateCnt = 0;
        DominateCntMax = mapAlphaSize_H * mapAlphaSize_W;

        Debug.Log("Width:" + mapSize_W);
        Debug.Log("Height:" + mapSize_H);

        Debug.Log("AlphaWidth:" + mapAlphaSize_W);
        Debug.Log("AlphaHeight:" + mapAlphaSize_H);

        Debug.Log("AlphaResolution:" + terrainComponent.terrainData.alphamapResolution);

        //マップの染色用データの配列「W、H、色の種類」
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

        thread = new Thread(CheckTeraDominate);
        thread.Start();

        DominateScript = DominateBarObj.GetComponent<DominateBar>();
        DominateScript_2P = DominateBarObj_2P.GetComponent<DominateBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //AlphaMap[150, 150, 1] = Alpha;
        //AlphaMap[150, 150, 0] = 1 - Alpha;


        Alpha += 0.01f;

        UpdateTimer += Time.deltaTime;
        TeraCheckTimer += Time.deltaTime;

        if (UpdateTimer > UpdateDeray)
        {
            terrainComponent.terrainData.SetAlphamaps(0, 0, AlphaMap);
            UpdateTimer = 0;
        }

        if(TeraCheckTimer > TeraCheckDeray)
        {
            //CheckTeraDominate();

            //Debug.Log("塗られた数:" + DominateCnt);

            

            //TeraCheckTimer = 0;
        }

        //DominateCnt = 0;

        //terrainComponent.terrainData.SetAlphamaps();

        //if (AriaSize > 5)
        //{
        //    AriaSize -= 0.5f;
        //}
    }

    private void OnApplicationQuit()
    {
        if(thread != null)
        {
            thread.Abort();
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
        var mapR = collision.transform.localScale.x * mapSize_W / terrainComponent.terrainData.size.z;

        int z1 = (int)Mathf.Max(-mapR, -mapZ);
        int z2 = (int)Mathf.Min(mapR, -mapZ + mapSize_H - 1);

        int mapW;
        int x1;
        int x2;
        float TestSin;

        var Tag = collision.gameObject.tag;

        if(Tag != "Player")
        {
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, this.transform.localPosition.y + terrainComponent.terrainData.GetHeight((int)mapZ, (int)mapX), collision.gameObject.transform.position.z);
        }
        else
        {
            if(collision.gameObject.transform.position.y <= terrainComponent.terrainData.GetHeight((int)mapZ, (int)mapX))
            {
                collision.gameObject.transform.position -= collision.gameObject.transform.forward;
            }
        }

        for (var z = z1; z <= z2; z++)
        {
            mapW = (int)Mathf.Sqrt(mapR * mapR - z * z);
            x1 = (int)Mathf.Max(-mapW, -mapX);
            x2 = (int)Mathf.Min(mapW, -mapX + mapSize_W - 1);
            TestSin = (x2 - x1) / 2;
            for (var x = x1; x <= x2; x++)
            {
                if ((x + mapX) > 0 && (x + mapX) < mapAlphaSize_W && (z + mapZ) > 0 && (z + mapZ) < mapAlphaSize_H)
                {
                    if (!(Tag == "Tornado") && Tag != "Fire")
                    {
                        //Random.Range(0.1f, 0.5f);
                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] += Random.Range(0.05f, 0.1f);

                        if (AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] > 1)
                        {
                            AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] = 1;
                        }

                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] = 1 - AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1];
                    }
                    else
                    {
                        //Random.Range(0.1f, 0.5f);
                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] = 1;

                        if (AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] > 1)
                        {
                            AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0] = 1;
                        }

                        AlphaMap[(int)(x + mapX), (int)(z + mapZ), 1] = 1 - AlphaMap[(int)(x + mapX), (int)(z + mapZ), 0];
                    }
                }
            }
        }

        //terrainComponent.terrainData.SetAlphamaps(0, 0, AlphaMap);
    }

    private void CheckTeraDominate()
    {

        int x, y;

        while (true)
        {
            Thread.Sleep(100);
            ClearDominateCnt();
            lock (sync)
            {
                for (y = 0; y < mapAlphaSize_H; y++)
                {
                    for (x = 0; x < mapAlphaSize_W; x++)
                    {
                        if (AlphaMap[x, y, 1] == 1)
                        {
                            DominateCnt += 1;
                        }
                    }
                }

                DominateScript.Bar = ((float)DominateCnt / (float)DominateCntMax);
                DominateScript_2P.Bar = ((float)DominateCnt / (float)DominateCntMax);
                //Debug.Log(((float)DominateCnt / (float)DominateCntMax));
            }
        }
    }

    public int GetDominateCnt()
    {
       {
            lock (sync)
            {
                return DominateCnt;
            }
       }
    }

    public void ClearDominateCnt()
    {
        lock(sync)
        {
            DominateCnt = 0;
        }
    }
}