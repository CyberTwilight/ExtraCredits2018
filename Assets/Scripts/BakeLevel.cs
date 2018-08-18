using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//creates from a given png file(texture2D) a GameObject with colliders2D corresponding to the level layout
public class BakeLevel : MonoBehaviour
{

    public Texture2D texture;
    public List<Vector3> collisionColors;

    private List<Vector3> temp_list;

    public GameObject GenerateColliders(Texture2D tex)
    {
        //the 4th coordinate of the pixels is all over the place, so I'll just cut it out
        var go = new GameObject();
        temp_list = new List<Vector3>();

        for (int i = 0; i < tex.width; i++)
        {
            for (int j = 0; j < tex.height; j++)
            {
                Color pix = tex.GetPixel(i, j);
                Vector3 v3 = new Vector3(pix.r, pix.g, pix.b);
                if (collisionColors.Contains(v3))
                {
                    //create a collider for this pixel
                    var new_col = new GameObject();
                    new_col.AddComponent<BoxCollider2D>();
                    new_col.transform.parent = go.transform;
                    new_col.transform.localPosition = new Vector3(i, j, 0);

                }
            }
        }
        Debug.Log(go);
        return go;
    }

    // Use this for initialization
    public void Bake()
    {
        var level = GenerateColliders(texture);
        string localPath = "Assets/" + "levelLayout" + ".prefab";
        PrefabUtility.CreatePrefab(localPath, level);
        Debug.Log("saved");


    }
}
