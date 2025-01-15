using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class GameScript : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject BlocksStorage;
    int VerticalBlocks;
    int HorizontalBlocks;

    enum BlockType {
        Gray,
        Red,
        Green,
        Blue,
        BluePlank
    }

    // Start is called before the first frame update
    void Start()
    {
        // read in the ASCII
        // 
        string[] sz = File.ReadAllLines("GameData.txt");
        if( sz == null )
        {
            Console.WriteLine("Cannot read in GameData.txt");
        }

        VerticalBlocks = sz.Length;
        HorizontalBlocks = (int)(VerticalBlocks * Camera.main.aspect + 0.5f);


        // resize the camera's position based on the height of the blocks and the FOV of the camera
        // becomes a trig problem:
        /*
         *                   |
         *                   |
         * Cam ------------->|
         *                   |
         *                   |
         *                   
         * */

        int yindex = 0;
        foreach (string s in sz)
        {
            for (int xindex = 0; xindex < s.Length / 2; xindex++)
            {
                string sub = s.Substring(xindex * 2, 2);
                if (sub == "##")
                {
                    // boundary block!
                    GameObject grayBlockPrefab = CreateBlockOfType(BlockType.Gray); // CreatePrefabByName("Gray_block");
                    grayBlockPrefab.transform.parent = BlocksStorage.transform;
                    grayBlockPrefab.transform.position = new Vector3(xindex - HorizontalBlocks / 2 , yindex - VerticalBlocks / 2, 0);
                }
                if (sub == "XX")
                {
                    GameObject grayBlockPrefab = CreateBlockOfType(BlockType.Blue);
                    grayBlockPrefab.transform.parent = BlocksStorage.transform;
                    grayBlockPrefab.transform.position = new Vector3(xindex - HorizontalBlocks / 2, yindex - VerticalBlocks / 2, 0);
                }
                if (sub == "BP")
                {
                    GameObject bluePlankPrefab = CreateBlockOfType(BlockType.BluePlank);
                    bluePlankPrefab.transform.parent = BlocksStorage.transform;
                    bluePlankPrefab.transform.position = new Vector3(xindex - HorizontalBlocks / 2, yindex - VerticalBlocks / 2, 0);
                }
            }

            yindex++;
        }
    }

    GameObject CreatePrefabByName(string sz)
    {
        var prefabInstance = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + sz, typeof(GameObject));
        return prefabInstance as GameObject;
    }

    GameObject CreateBlockOfType( BlockType bt )
    {
        return Instantiate(Blocks[(int)bt]);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
