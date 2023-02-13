﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextRPG
{
    internal class MapGenerator
    {
        // ▓ = wall Grey
        // , = floor Grey
        // █ = door Brown

        private Random rand;

        /*
        MapChunk[] TLCorners = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓','▓','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',',','},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓',',','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ',' ',' ',' ',' ',' '},
                {' ','▓','▓','▓','▓','▓',' '},
                {' ','▓',',',',',',','▓','▓'},
                {' ','▓',',',',',',',',',','},
                {' ','▓',',',',',',','▓','▓'},
                {' ','▓','▓',',','▓','▓',' '},
                {' ',' ','▓',',','▓',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ','▓','▓','▓','▓','▓'},
                {' ',' ','▓',',',',',',',','},
                {' ',' ','▓',',','▓','▓','▓'},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
            })

        };

        MapChunk[] TRCorners = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓','▓','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {',',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓',',','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ',' ',' ',' ',' ',' '},
                {' ','▓','▓','▓','▓','▓',' '},
                {'▓','▓',',',',',',','▓',' '},
                {',',',',',',',',',','▓',' '},
                {'▓','▓',',',',',',','▓',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {' ',' ','▓',',','▓',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
                {'▓','▓','▓','▓','▓',' ',' '},
                {',',',',',',',','▓',' ',' '},
                {'▓','▓','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
            })

        };

        MapChunk[] BLCorners = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓',',','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',',','},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓','▓','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {' ','▓',',',',',',','▓','▓'},
                {' ','▓',',',',',',',',',','},
                {' ','▓',',',',',',','▓','▓'},
                {' ','▓','▓','▓','▓','▓',' '},
                {' ',' ',' ',' ',' ',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓','▓','▓'},
                {' ',' ','▓',',',',',',',','},
                {' ',' ','▓','▓','▓','▓','▓'},
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
            })

        };

        MapChunk[] BRCorners = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓',',','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {',',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓','▓','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {'▓','▓',',',',',',','▓',' '},
                {',',',',',',',',',','▓',' '},
                {'▓','▓',',',',',',','▓',' '},
                {' ','▓','▓','▓','▓','▓',' '},
                {' ',' ',' ',' ',' ',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {'▓','▓','▓',',','▓',' ',' '},
                {',',',',',',',','▓',' ',' '},
                {'▓','▓','▓','▓','▓',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
            })

        };

        MapChunk[] Tops = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓','▓','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {',',',',',',',',',',',',','},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓',',','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ',' ',' ',' ',' ',' '},
                {' ','▓','▓','▓','▓','▓',' '},
                {'▓','▓',',',',',',','▓','▓'},
                {',',',',',',',',',',',',','},
                {'▓','▓',',',',',',','▓','▓'},
                {' ','▓','▓',',','▓','▓',' '},
                {' ',' ','▓',',','▓',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
                {'▓','▓','▓','▓','▓','▓','▓'},
                {',',',',',',',',',',',',','},
                {'▓','▓','▓',',','▓','▓','▓'},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
            })

        };

        MapChunk[] Bottoms = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓',',','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {',',',',',',',',',',',',','},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓','▓','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {'▓','▓',',',',',',','▓','▓'},
                {',',',',',',',',',',',',','},
                {'▓','▓',',',',',',','▓','▓'},
                {' ','▓','▓','▓','▓','▓',' '},
                {' ',' ',' ',' ',' ',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {'▓','▓','▓',',','▓','▓','▓'},
                {',',',',',',',',',',',',','},
                {'▓','▓','▓','▓','▓','▓','▓'},
                {' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ',' '},
            })

        };

        MapChunk[] Lefts = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓',',','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',',','},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓',',','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {' ','▓',',',',',',','▓','▓'},
                {' ','▓',',',',',',',',',','},
                {' ','▓',',',',',',','▓','▓'},
                {' ','▓','▓',',','▓','▓',' '},
                {' ',' ','▓',',','▓',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓','▓','▓'},
                {' ',' ','▓',',',',',',',','},
                {' ',' ','▓',',','▓','▓','▓'},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
            })

        };

        MapChunk[] Rights = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓',',','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {',',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓',',','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {'▓','▓',',',',',',','▓',' '},
                {',',',',',',',',',','▓',' '},
                {'▓','▓',',',',',',','▓',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {' ',' ','▓',',','▓',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {'▓','▓','▓',',','▓',' ',' '},
                {',',',',',',',','▓',' ',' '},
                {'▓','▓','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
            })

        };

        MapChunk[] Centers = new MapChunk[]
        {
            new MapChunk(new char[,]
            {
                {'▓','▓','▓',',','▓','▓','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {',',',',',',',',',',',',','},
                {'▓',',',',',',',',',',','▓'},
                {'▓',',',',',',',',',',','▓'},
                {'▓','▓','▓',',','▓','▓','▓'},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ','▓','▓',',','▓','▓',' '},
                {'▓','▓',',',',',',','▓','▓'},
                {',',',',',',',',',',',',','},
                {'▓','▓',',',',',',','▓','▓'},
                {' ','▓','▓',',','▓','▓',' '},
                {' ',' ','▓',',','▓',' ',' '},
            }),
            new MapChunk(new char[,]
            {
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
                {'▓','▓','▓',',','▓','▓','▓'},
                {',',',',',',',',',',',',','},
                {'▓','▓','▓',',','▓','▓','▓'},
                {' ',' ','▓',',','▓',' ',' '},
                {' ',' ','▓',',','▓',' ',' '},
            })

        };
        */

        private MapChunk[] B = new MapChunk[3];       //0
        private MapChunk[] L = new MapChunk[3];       //1
        private MapChunk[] R = new MapChunk[3];       //2
        private MapChunk[] T = new MapChunk[3];       //3
        private MapChunk[] BL = new MapChunk[3];      //4
        private MapChunk[] BR = new MapChunk[3];      //5
        private MapChunk[] BT = new MapChunk[3];      //6
        private MapChunk[] LR = new MapChunk[3];      //7
        private MapChunk[] LT = new MapChunk[3];      //8
        private MapChunk[] RT = new MapChunk[3];      //9
        private MapChunk[] BLR = new MapChunk[3];     //10
        private MapChunk[] BLT = new MapChunk[3];     //11
        private MapChunk[] BRT = new MapChunk[3];     //12
        private MapChunk[] LRT = new MapChunk[3];     //13
        private MapChunk[] BLRT = new MapChunk[3];    //14
        private MapChunk Empty = new MapChunk(new char[7, 7]
        {
            {' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' '}
        });

        private MapChunk[,] TempMap = new MapChunk[5, 5];


        private void GetFiles()
        {
            string[] tempB = File.ReadAllLines("TextRPG/MapChunkCategories/B");
            for (int i = 0; i < 3; i++)
            {
                B[i] = new MapChunk(new char[7,7]);
                B[i].BOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        B[i].tile[j, k] = tempB[j][k];
                    }   
                }
            }

            string[] tempL = File.ReadAllLines("TextRPG/MapChunkCategories/L");
            for (int i = 0; i < 3; i++)
            {
                L[i] = new MapChunk(new char[7, 7]);
                L[i].LOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        L[i].tile[j, k] = tempL[j][k];
                    }
                }
            }

            string[] tempR = File.ReadAllLines("TextRPG/MapChunkCategories/R");
            for (int i = 0; i < 3; i++)
            {
                R[i] = new MapChunk(new char[7, 7]);
                R[i].ROpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        R[i].tile[j, k] = tempR[j][k];
                    }
                }
            }

            string[] tempT = File.ReadAllLines("TextRPG/MapChunkCategories/T");
            for (int i = 0; i < 3; i++)
            {
                T[i] = new MapChunk(new char[7, 7]);
                T[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        T[i].tile[j, k] = tempT[j][k];
                    }
                }
            }

            string[] tempBL = File.ReadAllLines("TextRPG/MapChunkCategories/BL");
            for (int i = 0; i < 3; i++)
            {
                BL[i] = new MapChunk(new char[7, 7]);
                BL[i].BOpen = true;
                BL[i].LOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BL[i].tile[j, k] = tempBL[j][k];
                    }
                }
            }

            string[] tempBR = File.ReadAllLines("TextRPG/MapChunkCategories/BR");
            for (int i = 0; i < 3; i++)
            {
                BR[i] = new MapChunk(new char[7, 7]);
                BR[i].BOpen = true;
                BR[i].ROpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BR[i].tile[j, k] = tempBR[j][k];
                    }
                }
            }

            string[] tempBT = File.ReadAllLines("TextRPG/MapChunkCategories/BT");
            for (int i = 0; i < 3; i++)
            {
                BT[i] = new MapChunk(new char[7, 7]);
                BT[i].BOpen = true;
                BT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BT[i].tile[j, k] = tempBT[j][k];
                    }
                }
            }

            string[] tempLR = File.ReadAllLines("TextRPG/MapChunkCategories/LR");
            for (int i = 0; i < 3; i++)
            {
                LR[i] = new MapChunk(new char[7, 7]);
                LR[i].LOpen = true;
                LR[i].ROpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        LR[i].tile[j, k] = tempLR[j][k];
                    }
                }
            }

            string[] tempLT = File.ReadAllLines("TextRPG/MapChunkCategories/LT");
            for (int i = 0; i < 3; i++)
            {
                LT[i] = new MapChunk(new char[7, 7]);
                LT[i].LOpen = true;
                LT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        LT[i].tile[j, k] = tempLT[j][k];
                    }
                }
            }

            string[] tempRT = File.ReadAllLines("TextRPG/MapChunkCategories/RT");
            for (int i = 0; i < 3; i++)
            {
                RT[i] = new MapChunk(new char[7, 7]);
                RT[i].ROpen = true;
                RT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        RT[i].tile[j, k] = tempRT[j][k];
                    }
                }
            }

            string[] tempBLR = File.ReadAllLines("TextRPG/MapChunkCategories/BLR");
            for (int i = 0; i < 3; i++)
            {
                BLR[i] = new MapChunk(new char[7, 7]);
                BLR[i].BOpen = true;
                BLR[i].LOpen = true;
                BLR[i].ROpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BLR[i].tile[j, k] = tempBLR[j][k];
                    }
                }
            }

            string[] tempBLT = File.ReadAllLines("TextRPG/MapChunkCategories/BLT");
            for (int i = 0; i < 3; i++)
            {
                BLT[i] = new MapChunk(new char[7, 7]);
                BLT[i].BOpen = true;
                BLT[i].LOpen = true;
                BLT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BLT[i].tile[j, k] = tempBLT[j][k];
                    }
                }
            }

            string[] tempBRT = File.ReadAllLines("TextRPG/MapChunkCategories/BRT");
            for (int i = 0; i < 3; i++)
            {
                BRT[i] = new MapChunk(new char[7, 7]);
                BRT[i].BOpen = true;
                BRT[i].ROpen = true;
                BRT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BRT[i].tile[j, k] = tempBRT[j][k];
                    }
                }
            }

            string[] tempLRT = File.ReadAllLines("TextRPG/MapChunkCategories/LRT");
            for (int i = 0; i < 3; i++)
            {
                LRT[i] = new MapChunk(new char[7, 7]);
                LRT[i].LOpen = true;
                LRT[i].ROpen = true;
                LRT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        LRT[i].tile[j, k] = tempLRT[j][k];
                    }
                }
            }

            string[] tempBLRT = File.ReadAllLines("TextRPG/MapChunkCategories/BLRT");
            for (int i = 0; i < 3; i++)
            {
                BLRT[i] = new MapChunk(new char[7, 7]);
                BLRT[i].BOpen = true;
                BLRT[i].LOpen = true;
                BLRT[i].ROpen = true;
                BLRT[i].TOpen = true;
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        BLRT[i].tile[j, k] = tempBLRT[j][k];
                    }
                }
            }
        }


        private MapChunk RandomizeTile(MapChunk[] chunkOptions)
        {
            MapChunk chunk = chunkOptions[rand.Next(0, chunkOptions.Length)];
            return chunk;
        }

        private MapChunk FillTile(int x, int y)
        {
            if (x == 0) // Left Side of map
            {
                if(y == 0) // Top of Map
                {
                    if (TempMap[x+1, y].LOpen && TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(BR);
                    }else if (TempMap[x + 1, y].LOpen)
                    {
                        return RandomizeTile(R);
                    }else if (TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(B);
                    }
                }else if (y == TempMap.GetLength(1)) //Bottom of map
                {
                    if (TempMap[x + 1, y].LOpen && TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(RT);
                    }
                    else if (TempMap[x + 1, y].LOpen)
                    {
                        return RandomizeTile(R);
                    }
                    else if (TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(T);
                    }
                }
                else //left side of map not top or bottom
                {
                    if (TempMap[x + 1, y].LOpen && TempMap[x, y + 1].TOpen && TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(BRT);
                    } else if (TempMap[x + 1, y].LOpen && TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(BR);
                    } else if (TempMap[x, y - 1].BOpen && TempMap[x + 1, y].LOpen)
                    {
                        return RandomizeTile(RT);
                    } else if (TempMap[x, y - 1].BOpen && TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(BT);
                    } else if (TempMap[x + 1, y].LOpen)
                    {
                        return RandomizeTile(R);
                    } else if (TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(T);
                    } else if (TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(B);
                    }
                }
            } else if(x == TempMap.GetLength(0))    //right side of map
            {
                if (y == 0) //top of map
                {
                    if (TempMap[x - 1, y].ROpen && TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(BL);
                    }
                    else if (TempMap[x - 1, y].ROpen)
                    {
                        return RandomizeTile(L);
                    }
                    else if (TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(B);
                    }
                }
                else if (y == TempMap.GetLength(1)) // bottom of map
                {
                    if (TempMap[x - 1, y].ROpen && TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(LT);
                    }
                    else if (TempMap[x- 1, y].ROpen)
                    {
                        return RandomizeTile(L);
                    }
                    else if (TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(T);
                    }
                }
                else    // right side of map not top or bottom
                {
                    if (TempMap[x - 1, y].ROpen && TempMap[x, y + 1].TOpen && TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(BLT);
                    }
                    else if (TempMap[x - 1, y].ROpen && TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(BL);
                    }
                    else if (TempMap[x, y - 1].BOpen && TempMap[x + 1, y].ROpen)
                    {
                        return RandomizeTile(LT);
                    }
                    else if (TempMap[x, y - 1].BOpen && TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(BT);
                    }
                    else if (TempMap[x - 1, y].ROpen)
                    {
                        return RandomizeTile(L);
                    }
                    else if (TempMap[x, y - 1].BOpen)
                    {
                        return RandomizeTile(T);
                    }
                    else if (TempMap[x, y + 1].TOpen)
                    {
                        return RandomizeTile(B);
                    }
                }
            }else if (y == 0)   //Top of Map not left or right
            {
                if (TempMap[x+1, y].LOpen && TempMap[x-1, y].ROpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BLR);
                }else if (TempMap[x + 1, y].LOpen && TempMap[x - 1, y].ROpen)
                {
                    return RandomizeTile(LR);
                }else if (TempMap[x+1, y].LOpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BR);
                }else if (TempMap[x-1, y].ROpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BL);
                }else if (TempMap[x + 1, y].LOpen)
                {
                    return RandomizeTile(R);
                }else if (TempMap[x-1, y].ROpen)
                {
                    return RandomizeTile(L);
                }else if (TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(B);
                }
            }else if(y == TempMap.GetLength(1)) //bottom of map not left or right
            {
                if (TempMap[x + 1, y].LOpen && TempMap[x - 1, y].ROpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(LRT);
                }
                else if (TempMap[x + 1, y].LOpen && TempMap[x - 1, y].ROpen)
                {
                    return RandomizeTile(LR);
                }
                else if (TempMap[x + 1, y].LOpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(RT);
                }
                else if (TempMap[x - 1, y].ROpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(LT);
                }
                else if (TempMap[x + 1, y].LOpen)
                {
                    return RandomizeTile(R);
                }
                else if (TempMap[x - 1, y].ROpen)
                {
                    return RandomizeTile(L);
                }
                else if (TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(T);
                }
            }
            else    //not on the edge of the map
            {
                if (TempMap[x, y - 1].BOpen && TempMap[x - 1, y].ROpen && TempMap[x + 1, y].LOpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BLRT);
                }
                else if (TempMap[x + 1, y].LOpen && TempMap[x - 1, y].ROpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BLR);
                }
                else if (TempMap[x + 1, y].LOpen && TempMap[x - 1, y].ROpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(LRT);
                }else if (TempMap[x - 1, y].ROpen && TempMap[x, y + 1].TOpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(BLT);
                }else if (TempMap[x + 1, y].LOpen && TempMap[x, y + 1].TOpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(BRT);
                } else if (TempMap[x + 1, y].LOpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(RT);
                } else if (TempMap[x - 1, y].ROpen && TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(LT);
                }
                else if (TempMap[x, y - 1].BOpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BT);
                }
                else if (TempMap[x + 1, y].LOpen && TempMap[x - 1, y].ROpen)
                {
                    return RandomizeTile(LR);
                }
                else if (TempMap[x + 1, y].LOpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BR);
                }
                else if (TempMap[x - 1, y].ROpen && TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(BL);
                }
                else if (TempMap[x, y - 1].BOpen)
                {
                    return RandomizeTile(T);
                }
                else if (TempMap[x + 1, y].LOpen)
                {
                    return RandomizeTile(R);
                }
                else if (TempMap[x - 1, y].ROpen)
                {
                    return RandomizeTile(L);
                }
                else if (TempMap[x, y + 1].TOpen)
                {
                    return RandomizeTile(B);
                }
            }
            return Empty;
        }

        /*
        public char[,] RandomizeMap()
        {
            char[,] grid = new char[35, 35];
            Random r = new Random();
            MapChunk[,] tempMapChunks = new MapChunk[5, 5]
            {
                {TLCorners[r.Next(0,3)], Tops[r.Next(0,3)], Tops[r.Next(0,3)], Tops[r.Next(0,3)], TRCorners[r.Next(0,3)]},
                {Lefts[r.Next(0,3)], Centers[r.Next(0,3)], Centers[r.Next(0,3)], Centers[r.Next(0,3)], Rights[r.Next(0,3)]},
                {Lefts[r.Next(0,3)], Centers[r.Next(0,3)], Centers[r.Next(0,3)], Centers[r.Next(0,3)], Rights[r.Next(0,3)]},
                {Lefts[r.Next(0,3)], Centers[r.Next(0,3)], Centers[r.Next(0,3)], Centers[r.Next(0,3)], Rights[r.Next(0,3)]},
                {BLCorners[r.Next(0,3)], Bottoms[r.Next(0,3)], Bottoms[r.Next(0,3)], Bottoms[r.Next(0,3)], BRCorners[r.Next(0,3)]}
            };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            grid[i * 7 + k, j * 7 + l] = tempMapChunks[i, j].tile[k, l];
                        }
                    }
                }
            }
            return grid;
        }
        */

        public char[,] RandomizeMap()
        {
            GetFiles();


            char[,] grid = new char[35, 35];
            TempMap[2,2] = RandomizeTile(BLRT);
            switch (rand.Next(0, 5))
            {
                case 0:
                    TempMap[1, 1] = RandomizeTile(BLR);
                    break;
                case 1:
                    TempMap[1, 1] = RandomizeTile(BLT);
                    break;
                case 2:
                    TempMap[1, 1] = RandomizeTile(BRT);
                    break;
                case 3:
                    TempMap[1, 1] = RandomizeTile(LRT);
                    break;
                case 4:
                    TempMap[1, 1] = RandomizeTile(BLRT);
                    break;
            }
            switch (rand.Next(0, 5))
            {
                case 0:
                    TempMap[1, 3] = RandomizeTile(BLR);
                    break;
                case 1:
                    TempMap[1, 3] = RandomizeTile(BLT);
                    break;
                case 2:
                    TempMap[1, 3] = RandomizeTile(BRT);
                    break;
                case 3:
                    TempMap[1, 3] = RandomizeTile(LRT);
                    break;
                case 4:
                    TempMap[1, 3] = RandomizeTile(BLRT);
                    break;
            }
            switch (rand.Next(0, 5))
            {
                case 0:
                    TempMap[3, 1] = RandomizeTile(BLR);
                    break;
                case 1:
                    TempMap[3, 1] = RandomizeTile(BLT);
                    break;
                case 2:
                    TempMap[3, 1] = RandomizeTile(BRT);
                    break;
                case 3:
                    TempMap[3, 1] = RandomizeTile(LRT);
                    break;
                case 4:
                    TempMap[3, 1] = RandomizeTile(BLRT);
                    break;
            }
            switch (rand.Next(0, 5))
            {
                case 0:
                    TempMap[3, 3] = RandomizeTile(BLR);
                    break;
                case 1:
                    TempMap[3, 3] = RandomizeTile(BLT);
                    break;
                case 2:
                    TempMap[3, 3] = RandomizeTile(BRT);
                    break;
                case 3:
                    TempMap[3, 3] = RandomizeTile(LRT);
                    break;
                case 4:
                    TempMap[3, 3] = RandomizeTile(BLRT);
                    break;
            }
            switch (rand.Next(0, 4))
            {
                case 0:
                    TempMap[0, 2] = RandomizeTile(LR);
                    break;
                case 1:
                    TempMap[0, 2] = RandomizeTile(BL);
                    break;
                case 2:
                    TempMap[0, 2] = RandomizeTile(BR);
                    break;
                case 3:
                    TempMap[0, 2] = RandomizeTile(BLR);
                    break;
            }
            switch (rand.Next(0, 4))
            {
                case 0:
                    TempMap[2, 0] = RandomizeTile(BR);
                    break;
                case 1:
                    TempMap[2, 0] = RandomizeTile(BT);
                    break;
                case 2:
                    TempMap[2, 0] = RandomizeTile(RT);
                    break;
                case 3:
                    TempMap[2, 0] = RandomizeTile(BRT);
                    break;
            }
            switch (rand.Next(0, 4))
            {
                case 0:
                    TempMap[2, 4] = RandomizeTile(BL);
                    break;
                case 1:
                    TempMap[2, 4] = RandomizeTile(BT);
                    break;
                case 2:
                    TempMap[2, 4] = RandomizeTile(LT);
                    break;
                case 3:
                    TempMap[2, 4] = RandomizeTile(BLT);
                    break;
            }
            switch (rand.Next(0, 4))
            {
                case 0:
                    TempMap[4, 2] = RandomizeTile(LR);
                    break;
                case 1:
                    TempMap[4, 2] = RandomizeTile(LT);
                    break;
                case 2:
                    TempMap[4, 2] = RandomizeTile(RT);
                    break;
                case 3:
                    TempMap[4, 2] = RandomizeTile(LRT);
                    break;
            }
            switch (rand.Next(0, 3))
            {
                case 0:
                    TempMap[0, 0] = RandomizeTile(BR);
                    break;
                case 1:
                    TempMap[0, 0] = RandomizeTile(B);
                    break;
                case 2:
                    TempMap[0, 0] = RandomizeTile(R);
                    break;
            }
            switch (rand.Next(0, 3))
            {
                case 0:
                    TempMap[0, 4] = RandomizeTile(BL);
                    break;
                case 1:
                    TempMap[0, 4] = RandomizeTile(B);
                    break;
                case 2:
                    TempMap[0, 4] = RandomizeTile(L);
                    break;
            }
            switch (rand.Next(0, 3))
            {
                case 0:
                    TempMap[4, 0] = RandomizeTile(RT);
                    break;
                case 1:
                    TempMap[4, 0] = RandomizeTile(R);
                    break;
                case 2:
                    TempMap[4, 0] = RandomizeTile(T);
                    break;
            }
            switch (rand.Next(0, 3))
            {
                case 0:
                    TempMap[4, 4] = RandomizeTile(LT);
                    break;
                case 1:
                    TempMap[4, 4] = RandomizeTile(L);
                    break;
                case 2:
                    TempMap[4, 4] = RandomizeTile(T);
                    break;
            }
            FillTile(0, 1);
            FillTile(0, 3);
            FillTile(1, 0);
            FillTile(1, 2);
            FillTile(1, 4);
            FillTile(2, 1);
            FillTile(2, 3);
            FillTile(3, 0);
            FillTile(3, 2);
            FillTile(3, 4);
            FillTile(4, 1);
            FillTile(4, 3);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            grid[i * 7 + k, j * 7 + l] = TempMap[i, j].tile[k, l];
                        }
                    }
                }
            }

            return grid;
        }
    }
}
