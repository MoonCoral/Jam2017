using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public int Height = 42;
    public int Width = 35;

    public TextAsset level;

    // Primary Fuse
    void Awake()
    {
        string[] map = level.text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                GameObject go = null;
                GameObject en = null;

                switch (map[y][x])
                {
                    case '#': //Wall
                        bool t, b, l, r;

                        if (y == 0)
                        {
                            t = false;
                        }
                        else
                        {
                            t = map[y - 1][x] == '#';
                        }

                        if (y == Height-1)
                        {
                            b = false;
                        }
                        else
                        {
                            b = map[y + 1][x] == '#';
                        }

                        if (x == 0)
                        {
                            l = false;
                        }
                        else
                        {
                           l = map[y][x-1] == '#';
                        }

                        if (x == Width - 1)
                        {
                            r = false;
                        }
                        else
                        {
                            r = map[y][x+1] == '#';
                        }

                        if (t && b && l && r)
                        {
                            go = Resources.Load("Wall_Full") as GameObject;
                        }
                        if (!t && !b && !l && !r)
                        {
                            go = Resources.Load("Wall_Pillar") as GameObject;
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
                        break;
                    case '.': //Floor
                        go = Resources.Load("Floor") as GameObject;
                        break;
                    case 'D': //Door
                        if (level.bytes[x + (y - 1)*Width + (y - 1)] == 0x23)
                        {
                            go = Resources.Load("Door_V") as GameObject;
                        }
                        else
                        {
                            go = Resources.Load("Door_H") as GameObject;
                        }
                        break;
                    case 'P': //Player
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("Player") as GameObject;
                        break;
                    case 'F': //Finish
                        go = Resources.Load("Finish") as GameObject;
                        break;
                    case 'E': //Enemy
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("Enemy") as GameObject;
                        break;
                    case 'A': //Lock A
                        if (level.bytes[x + (y - 1) * Width + (y - 1)] == 0x23)
                        {
                            go = Resources.Load("LockA_V") as GameObject;
                        }
                        else
                        {
                            go = Resources.Load("LockA_H") as GameObject;
                        }
                        break;
                    case 'a': //Key a
                        go = Resources.Load("KeyA") as GameObject;
                        break;
                    case 'B': //Lock B
                        go = Resources.Load("LockB") as GameObject;
                        break;
                    case 'b': //Key b
                        go = Resources.Load("KeyB") as GameObject;
                        break;

                }

                if (go == null)
                {
                    //throw new UnityException("Assets Please!");
                }
                else
                {
                    GameObject gogo = Instantiate(go);

                    gogo.transform.parent = transform;
                    gogo.transform.position = new Vector3(x, -y);
                }

                if (en != null)
                {
                    GameObject engo = Instantiate(en);

                    engo.transform.parent = transform;
                    engo.transform.position = new Vector3(x, -y);
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
