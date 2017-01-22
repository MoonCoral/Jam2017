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
                        else if (!t && !b && !l && !r)
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
                        go = Resources.Load("Floor") as GameObject;
                        if (level.bytes[x + (y - 1)*Width + (y - 1)] == 0x23)
                        {
                            en = Resources.Load("Door_V") as GameObject;
                        }
                        else
                        {
                            en = Resources.Load("Door_H") as GameObject;
                        }
                        break;
                    case 'C': //Closable Door
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("Closable") as GameObject;
                        break;
                    case 'P': //Player
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("Player") as GameObject;
                        break;
                    case 'F': //Finish
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("Finish") as GameObject;
                        break;
                    case 'E': //Enemy
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("Enemy") as GameObject;
                        break;
                    case 'A': //Lock A
                        go = Resources.Load("Floor") as GameObject;
                        if (level.bytes[x + (y - 1) * Width + (y - 1)] == 0x23)
                        {
                            en = Resources.Load("LockA_V") as GameObject;
                        }
                        else
                        {
                            en = Resources.Load("LockA_H") as GameObject;
                        }
                        break;
                    case 'a': //Key a
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("KeyA") as GameObject;
                        break;
                    case 'B': //Lock B
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("LockB") as GameObject;
                        break;
                    case 'b': //Key b
                        go = Resources.Load("Floor") as GameObject;
                        en = Resources.Load("KeyB") as GameObject;
                        break;

                }

                if (go != null)
                {
                    GameObject gogo = Instantiate(go);

                    gogo.transform.parent = transform;
                    gogo.transform.position = new Vector3(x, -y);
                }

                if (en != null)
                {
                    GameObject engo = Instantiate(en);

                    if (map[y][x] == 'P')
                    {
                        engo.transform.parent = FindObjectOfType<GameController>().transform;
                    }
                    else
                    {
                        engo.transform.parent = transform;
                    }
                    engo.transform.position = new Vector3(x, -y);
                }
            }
        }
    }
}
