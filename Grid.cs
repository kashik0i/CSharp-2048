using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace _2048
{
    class Grid
    {
        Random rr = new Random();
        public List<List<NumberedRect>> squire;

        int CountEmptyRects()
        {
            int ct = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (squire[i][j].value != 0)
                        ct++;
                }
            }
            return ct;
        }
        int addnew()
        {
            // need to add flags to end game 0:bad 1:good
            if (CountEmptyRects() == 0)
                return 0;
            int i = rr.Next(4);
            int j = rr.Next(4);
            if (squire[i][j].value == 0)
            {
                squire[i][j].value = 2;
               
            }
            else
            {
                addnew();
            }
            return 1;
        }

        public int MoveLeft(ref int steps)
        {

            bool ChangeDone = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {

                    if (squire[i][j - 1].value == 0 && squire[i][j].value != 0)
                    {
                        ChangeDone = true;
                        squire[i][j - 1].value = squire[i][j].value;
                        squire[i][j].value = 0;
                    }
                    else
                    {
                        if (squire[i][j - 1].value == squire[i][j].value)
                        {
                            squire[i][j - 1].value *= 2;
                            squire[i][j].value = 0;
                        }
                    }
                }
            }
            steps++;
            if (ChangeDone)
                MoveLeft(ref steps);
            else
                return addnew();
            return 1;
        }
        public int MoveRight(ref int steps)
        {

            bool ChangeDone = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (squire[i][j + 1].value == 0 && squire[i][j].value != 0)
                    {
                        ChangeDone = true;
                        squire[i][j + 1].value = squire[i][j].value;
                        squire[i][j].value = 0;
                    }
                    else
                    {
                        if (squire[i][j + 1].value == squire[i][j].value)
                        {
                            squire[i][j + 1].value *= 2;
                            squire[i][j].value = 0;
                        }
                    }
                }

            }
            steps++;
            if (ChangeDone)
                MoveRight(ref steps);
            else
                return addnew();
            return 1;
        }
        public int MoveUp(ref int steps)
        {

            bool ChangeDone = false;
            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (squire[i - 1][j].value == 0 && squire[i][j].value != 0)
                    {
                        ChangeDone = true;
                        squire[i - 1][j].value = squire[i][j].value;
                        squire[i][j].value = 0;
                    }
                    else
                    {
                        if (squire[i-1][j].value == squire[i][j].value)
                        {
                            squire[i-1][j].value *= 2;
                            squire[i][j].value = 0;
                        }
                    }
                }
            }
            steps++;
            if (ChangeDone)
                MoveUp(ref steps);
            else
                return addnew();
            return 1;
        }
        public int MoveDown(ref int steps)
        {

            bool ChangeDone = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (squire[i + 1][j].value == 0 && squire[i][j].value != 0)
                    {
                        ChangeDone = true;
                        squire[i + 1][j].value = squire[i][j].value;
                        squire[i][j].value = 0;
                    }
                    else
                    {
                        if (squire[i+1][j ].value == squire[i][j].value)
                        {
                            squire[i+1][j].value *= 2;
                            squire[i][j].value = 0;
                        }
                    }
                }
            }
            steps++;
            if (ChangeDone)
                MoveDown(ref steps);
            else
                return addnew();
            return 1;
        }
        public Grid()
        {
            squire = new List<List<NumberedRect>>();
            for (int i = 0; i < 4; i++)
            {
                squire.Add(new List<NumberedRect>());
                for (int j = 0; j < 4; j++)
                {
                    squire[i].Add(new NumberedRect(i == j ? 2 : 0, 200, 200, i, j, System.Drawing.Color.Beige));
                }
            }
        }
    }
}
