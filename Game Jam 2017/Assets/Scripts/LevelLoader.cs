using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using System.Threading;

public class LevelLoader : MonoBehaviour
{
    public int Height = 42;
    public int Width = 35;


    // Primary Fuse
    void Awake()
    {
        TextAsset level = Resources.Load("Level") as TextAsset;

        GameObject go;

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                switch (level.bytes[x + y * Width + y])
                {
                    case 0x23: //# Wall
                        bool t = (level.bytes[x + (y - 1)*Width + (y - 1)] == 0x23);
                        bool b = (level.bytes[x + (y + 1) * Width + (y + 1)] == 0x23);
                        bool l = (level.bytes[x - 1 + y * Width + y] == 0x23);
                        bool r = (level.bytes[x + 1 + y * Width + y] == 0x23);

                        if (t && b && l && r)
                        {
                            go = Resources.Load("Wall_Full") as GameObject;
                        }
                        else
                        {
                            string id = "Wall_";
                            if (t)
                            {
                                id += "T";
                            }
                            if (b)
                            {
                                id += "B";
                            }
                            if (l)
                            {
                                id += "L";
                            }
                            if (r)
                            {
                                id += "R";
                            }
                            go = Resources.Load(id) as GameObject;
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x2A: //* Border
                        go = Resources.Load("Wall_Full") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x2E: //. Floor
                        go = Resources.Load("Floor") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x44: //D Door
                        if (level.bytes[x + (y - 1)*Width + (y - 1)] == 0x23)
                        {
                            go = Resources.Load("Door_V") as GameObject;
                        }
                        else
                        {
                            go = Resources.Load("Door_H") as GameObject;
                        }
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x50: //P Player
                        go = Resources.Load("Floor") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        go = Resources.Load("Player") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x46: //F Finish
                        go = Resources.Load("Finish") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x45: //E Enemy
                        go = Resources.Load("Floor") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        go = Resources.Load("Enemy") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x41: //A Lock A
                        if (level.bytes[x + (y - 1) * Width + (y - 1)] == 0x23)
                        {
                            go = Resources.Load("LockA_V") as GameObject;
                        }
                        else
                        {
                            go = Resources.Load("LockA_H") as GameObject;
                        }
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x61: //a Key a
                        go = Resources.Load("KeyA") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x42: //B Lock B
                        go = Resources.Load("LockB") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;
                    case 0x62: //b Key b
                        go = Resources.Load("KeyB") as GameObject;
                        if (go == null)
                        {
                            throw new UnityException("Assets Please!");
                        }
                        go.transform.parent = transform;
                        go.transform.localPosition.Set(x, y, 0);
                        break;

                }
            }
        }

    }


    // Secondary Fuse
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
