using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace MultiscaleModelling1
{
    public partial class Neighbourhood
    {
        Random rand;

        public Neighbourhood()
        {
            rand = new Random();
        }

        private bool CheckTab()
        {
            int changedFields = 0;
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.orgTable[i][j] != Core.Config.pomTable[i][j])
                        changedFields++;
                }
            }
            return changedFields > 0;
        }

        public bool CheckAndCopyTab()
        {
            if (CheckTab())
            {
                for (int i = 0; i < Core.Config.sizeX; i++)
                {
                    for (int j = 0; j < Core.Config.sizeY; j++)
                    {
                        Core.Config.orgTable[i][j] = Core.Config.pomTable[i][j];
                    }
                }
                return true;
            }
            else
                return false;
        }

        public void Random_nucleation(int howmuch = -1)
        {
            int howMuch = howmuch > -1 ? howmuch : Core.Config.nucleation;
            for (int i = 0; i < howMuch; i++)
            {
                int x = rand.Next(0, Core.Config.sizeX);
                int y = rand.Next(0, Core.Config.sizeY);
                if (Core.Config.orgTable[x][y] == 0 || Core.Config.orgTable[x][y] < Core.Config.limit)
                {
                    Core.Config.orgTable[x][y] = Core.Config.seeds;
                    Color newColor = Color.FromArgb(20, rand.Next(256), rand.Next(256));
                    Core.Config.colors.Add(newColor);
                    Core.Config.seeds++;
                    if (howmuch > -1) Core.Config.energyTable[x][y] = 0;
                }
            }
        }

        public void Random_nucleation_srxmc(int howmuch = -1)
        {
            int howMuch = howmuch > -1 ? howmuch : Core.Config.SRX_nucleation;
            for (int i = 0; i < howMuch; i++)
            {
                int x = rand.Next(0, Core.Config.sizeX);
                int y = rand.Next(0, Core.Config.sizeY);
                if (Core.Config.orgTable[x][y] == 0 || Core.Config.orgTable[x][y] < Core.Config.limit)
                {
                    Core.Config.orgTable[x][y] = Core.Config.seeds;
                    Color newColor = Color.FromArgb(rand.Next(256), 0, 0);
                    Core.Config.colors.Add(newColor);
                    Core.Config.seeds++;
                    if (howmuch > -1) Core.Config.energyTable[x][y] = 0;
                }
            }
        }

        public bool anyEmpty()
        {
            int howMany = 0;
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    howMany += Core.Config.orgTable[i][j] == 0 ? 1 : 0;
                }
            }
            return howMany > 0 ? true : false;
        }

        public void InclusionAfter(int Type)
        {

            int howMuch = Type == 0 ? Core.Config.number : Core.Config.number;
            int licznik = 0;
            List<int> neighbourhoods;
            do
            {
                neighbourhoods = new List<int>();
                licznik++;
                int x = rand.Next(0, Core.Config.sizeX);
                int y = rand.Next(0, Core.Config.sizeY);
                if (Core.Config.orgTable[x][y] != -1)
                {
                    neighbourhoods.Add(Core.Config.orgTable[modX(x - 1)][modY(y)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x + 1)][modY(y)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x)][modY(y - 1)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x)][modY(y + 1)]);

                    neighbourhoods.Add(Core.Config.orgTable[modX(x - 1)][modY(y - 1)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x + 1)][modY(y + 1)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x + 1)][modY(y - 1)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x - 1)][modY(y + 1)]);

                    if (CheckForInclusion(neighbourhoods))
                    {
                        if (Type == 0)
                            Square(x, y);
                        else if (Type == 1)
                            Circle(x, y);
                        howMuch--;
                        licznik = 0;
                    }
                }
            } while (howMuch > 0 && licznik < 1000);
        }

        private bool CheckForInclusion(List<int> neighbourhoods)
        {
            Dictionary<int, int> numerous = new Dictionary<int, int>();
            foreach (int neighbourhood in neighbourhoods)
            {
                if (neighbourhood <= 0)
                    continue;
                if (numerous.Keys.Contains(neighbourhood))
                    numerous[neighbourhood]++;
                else
                    numerous.Add(neighbourhood, 1);
            }
            return numerous.Count > 1;
        }

        private int MostNumerousExt(List<int> neighbourhoods, int howMuch)
        {
            Dictionary<int, int> numerous = new Dictionary<int, int>();
            foreach (int neighbourhood in neighbourhoods)
            {
                if (numerous.Keys.Contains(neighbourhood))
                    numerous[neighbourhood]++;
                else
                    numerous.Add(neighbourhood, 1);
            }

            int mostCommonValue = 0;
            int highestCount = 0;
            foreach (KeyValuePair<int, int> numer in numerous)
            {
                if (!Core.Config.checkedID.Contains(numer.Key) && numer.Key > 0 && numer.Value > highestCount)
                {
                    mostCommonValue = numer.Key;
                    highestCount = numer.Value;
                }
            }
            if (highestCount > howMuch)
                return mostCommonValue;
            else
                return 0;
        }



        private int MostNumerous(List<int> neighbourhoods)
        {
            Dictionary<int, int> numerous = new Dictionary<int, int>();
            foreach (int neighbourhood in neighbourhoods)
            {
                if (numerous.Keys.Contains(neighbourhood))
                    numerous[neighbourhood]++;
                else
                    numerous.Add(neighbourhood, 1);
            }

            int mostCommonValue = 0;
            int highestCount = 0;
            foreach (KeyValuePair<int, int> numer in numerous)
            {
                if (!Core.Config.checkedID.Contains(numer.Key) && numer.Key > 0 && numer.Value > highestCount)
                {
                    mostCommonValue = numer.Key;
                    highestCount = numer.Value;
                }
            }

            return mostCommonValue;
        }

        public void vonNeuman()
        {
            List<int> neighbourhoods;
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.orgTable[i][j] == 0)
                    {
                        neighbourhoods = new List<int>();

                        neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);
                        Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
                    }
                    else
                        Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
                }
            }
        }

        public void moore()
        {
            List<int> neighbourhoods;
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.orgTable[i][j] == 0)
                    {
                        neighbourhoods = new List<int>();

                        neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

                        neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
                        neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);
                        Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
                    }
                    else
                        Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
                }
            }
        }

        public void mooreExt()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.orgTable[i][j] == 0)
                    {
                        int res = Rule1(i, j);
                        if (res == 0)
                            res = Rule2(i, j);
                        if (res == 0)
                            res = Rule3(i, j);
                        if (res == 0)
                            res = Rule4(i, j);
                        Core.Config.pomTable[i][j] = res;
                    }
                    else
                        Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
                }
            }
        }

        public void calcmMoreExt()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.orgTable[i][j] == 0)
                    {
                        int res = Rule1(i, j);
                        if (res >= 5 && res <= 8)
                            res = Rule1(i, j);
                        if (res >= 3 && res <= 4)
                            res = Rule2(i, j);
                        if (res >= 3 && res <= 4)
                            res = Rule3(i, j);
                        else 
                            res = Rule4(i, j);
                        Core.Config.pomTable[i][j] = res;
                    }
                    else
                        Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
                }
            }
        }

        private int modX(int x)
        {
            if (Core.Config.perio)
            {
                return (x + Core.Config.sizeX) % Core.Config.sizeX;
            }
            else
            {
                int ret = x % Core.Config.sizeX;
                if (ret < 0)
                    return 0;
                else if (x >= Core.Config.sizeX)
                    return Core.Config.sizeX - 1;
                else
                    return ret;

            }
        }

        private int modY(int y)
        {
            if (Core.Config.perio)
            {
                return (y + Core.Config.sizeY) % Core.Config.sizeY;
            }
            else
            {
                int ret = y % Core.Config.sizeY;
                if (ret < 0)
                    return 0;
                else if (y >= Core.Config.sizeY)
                    return Core.Config.sizeY - 1;
                else
                    return ret;

            }
        }

        //more
        private int Rule1(int i, int j)
        {
            List<int> neighbourhoods = new List<int>();

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);

            return MostNumerousExt(neighbourhoods, 5);
        }

        //von nneuman
        private int Rule2(int i, int j)
        {
            List<int> neighbourhoods = new List<int>();

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

            return MostNumerousExt(neighbourhoods, 3);
        }

        // not moore, not neuman
        private int Rule3(int i, int j)
        {
            List<int> neighbourhoods = new List<int>();

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);

            return MostNumerousExt(neighbourhoods, 5);
        }

        //probability
        private int Rule4(int i, int j)
        {
            List<int> neighbourhoods = new List<int>();

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);

            int res = MostNumerous(neighbourhoods);
            int n = rand.Next(0, 100);
            if (n > Convert.ToInt32(Core.Config.probabity))
                return 0;
            return res;
        }



        private void hexLeft(int i, int j)
        {
            List<int> neighbourhoods;
            if (Core.Config.orgTable[i][j] == 0)
            {
                neighbourhoods = new List<int>();

                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
            }
            else
                Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
        }

        private void hexRight(int i, int j)
        {
            List<int> neighbourhoods;
            if (Core.Config.orgTable[i][j] == 0)
            {
                neighbourhoods = new List<int>();

                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
            }
            else
                Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
        }

        public void hexagonalRandom()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    switch (rand.Next(0, 2))
                    {
                        case 0:
                            hexLeft(i, j);
                            break;
                        case 1:
                            hexRight(i, j);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void pentagonal1(int i, int j)
        {
            List<int> neighbourhoods;
            if (Core.Config.orgTable[i][j] == 0)
            {
                neighbourhoods = new List<int>();

                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
            }
            else
                Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
        }

        private void pentagonal2(int i, int j)
        {
            List<int> neighbourhoods;
            if (Core.Config.orgTable[i][j] == 0)
            {
                neighbourhoods = new List<int>();

                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
            }
            else
                Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
        }

        private void pentagonal3(int i, int j)
        {
            List<int> neighbourhoods;
            if (Core.Config.orgTable[i][j] == 0)
            {
                neighbourhoods = new List<int>();

                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);
                Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
            }
            else
                Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
        }

        private void pentagonal4(int i, int j)
        {
            List<int> neighbourhoods;
            if (Core.Config.orgTable[i][j] == 0)
            {
                neighbourhoods = new List<int>();

                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
                neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);
                Core.Config.pomTable[i][j] = MostNumerous(neighbourhoods);
            }
            else
                Core.Config.pomTable[i][j] = Core.Config.orgTable[i][j];
        }

        private List<int> MCmoore(int i, int j)
        {
            List<int> neighbourhoods = new List<int>();

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i)][modY(j + 1)]);

            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j + 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i + 1)][modY(j - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(i - 1)][modY(j + 1)]);
            return neighbourhoods;
        }

        private List<int> MCvonNeuman(int x, int y)
        {
            List<int> neighbourhoods = new List<int>();

            neighbourhoods.Add(Core.Config.orgTable[modX(x - 1)][modY(y)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(x + 1)][modY(y)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(x)][modY(y - 1)]);
            neighbourhoods.Add(Core.Config.orgTable[modX(x)][modY(y + 1)]);

            return neighbourhoods;
        }

        public void PentagonalRandom()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    switch (rand.Next(0, 4))
                    {
                        case 0:
                            pentagonal1(i, j);
                            break;
                        case 1:
                            pentagonal2(i, j);
                            break;
                        case 2:
                            pentagonal3(i, j);
                            break;
                        case 3:
                            pentagonal4(i, j);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void SquareInclusionBefore()
        {
            int howMuch = Core.Config.number;
            for (int k = 0; k < howMuch; k++)
            {
                int x = rand.Next(0, Core.Config.sizeX);
                int y = rand.Next(0, Core.Config.sizeY);
                Square(x, y);
            }
        }

        void Square(int x, int y)
        {
            int diameter = Core.Config.size;
            int X = modX(x - diameter / 2);
            int Y = modY(y - diameter / 2);
            {
                for (int i = 0; i < diameter; i++)
                {
                    for (int j = 0; j < diameter; j++)
                    {
                        Core.Config.orgTable[modX(X + i)][modY(Y + j)] = -1;
                    }
                }
            }
        }

        public void CircularInclusionBefore()
        {
            int howMuch = Core.Config.number;
            for (int k = 0; k < howMuch; k++)
            {
                int x = rand.Next(0, Core.Config.sizeX);
                int y = rand.Next(0, Core.Config.sizeY);
                Circle(x, y);
            }
        }



        void Circle(int x, int y)
        {
            int radius = Core.Config.size - 1;

            for (int i = x - radius; i <= x + radius; i++)
            {
                for (int j = y - radius; j <= y + radius; j++)
                {
                    double xp = (Math.Pow(modY(j) - y, 2.0));
                    double yp = (Math.Pow(modX(i) - x, 2.0));
                    if (((xp + yp) <= Math.Pow(radius, 2.0)) || Math.Sqrt(xp + yp) <= (radius + 0.5))
                        Core.Config.orgTable[modX(i)][modY(j)] = -1;
                }
            }
        }

        public void newTab()
        {
            Core.Config.orgTable = new int[Core.Config.sizeX][];
            Core.Config.pomTable = new int[Core.Config.sizeX][];
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                Core.Config.orgTable[i] = new int[Core.Config.sizeY];
                Core.Config.pomTable[i] = new int[Core.Config.sizeY];
            }
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    Core.Config.orgTable[i][j] = 0;
                    Core.Config.pomTable[i][j] = 0;
                }
            }
        }

        public void newLimTab()
        {
            Core.Config.limTable = new bool[Core.Config.sizeX][];
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                Core.Config.limTable[i] = new bool[Core.Config.sizeY];
            }

            for (int x = 0; x < Core.Config.sizeX; x++)
            {
                for (int y = 0; y < Core.Config.sizeY; y++)
                {
                    if (Core.Config.checkedID.Contains(Core.Config.orgTable[x][y]))
                        Core.Config.limTable[x][y] = false;
                    else
                    {
                        List<int> neighbours = MCmoore(x, y);
                        if (!neighbours.All(a => a == neighbours[0]))
                        {
                            Core.Config.limTable[x][y] = true;
                        }
                        else
                            Core.Config.limTable[x][y] = false;
                    }
                }
            }
        }

        public void newCheckedTab()
        {
            Core.Config.checkedTable = new bool[Core.Config.sizeX][];

            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                Core.Config.checkedTable[i] = new bool[Core.Config.sizeY];
            }
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    Core.Config.checkedTable[i][j] = false;
                }
            }
        }

        public void ClearTable()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (!Core.Config.checkedID.Contains(Core.Config.orgTable[i][j]))
                        Core.Config.orgTable[i][j] = 0;
                }
            }
        }

        public void ChangeTableColor()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (!Core.Config.checkedID.Contains(Core.Config.orgTable[i][j]))
                        Core.Config.orgTable[i][j] = 0;
                    else
                        Core.Config.orgTable[i][j] = Core.Config.checkedID[0];
                }
            }
        }

        public List<int> GetNeighbours(int x, int y)
        {
            switch (Core.Config.method)
            {
                case 0:
                    return MCvonNeuman(x, y);
                case 1:
                    return MCmoore(x, y);
                default:
                    return new List<int>();
            }
        }

        private bool CheckForBoundaries(List<int> neighbourhoods)
        {
            Dictionary<int, int> numerous = new Dictionary<int, int>();
            foreach (int neighbourhood in neighbourhoods)
            {
                if (neighbourhood <= 0)
                    continue;
                if (numerous.Keys.Contains(neighbourhood))
                    numerous[neighbourhood]++;
                else
                    numerous.Add(neighbourhood, 1);
            }
            return numerous.Count > 1;
        }

        public void BoundariesCheck(int Type)
        {
            int howMuch = 10000;
            int licznik = 0;
            List<int> neighbourhoods;
            do
            {
                neighbourhoods = new List<int>();
                licznik++;
                int x = rand.Next(0, Core.Config.sizeX);
                int y = rand.Next(0, Core.Config.sizeY);
                if (Core.Config.orgTable[x][y] != -1)
                {
                    neighbourhoods.Add(Core.Config.orgTable[modX(x - 1)][modY(y)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x + 1)][modY(y)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x)][modY(y - 1)]);
                    neighbourhoods.Add(Core.Config.orgTable[modX(x)][modY(y + 1)]);

                    Core.Config.checkedID.Add(Core.Config.orgTable[x][y]);
                    if (CheckForBoundaries(neighbourhoods))
                    {
                        if (Type == 0)
                            Square(x, y);
                        else if (Type == 1)
                            Circle(x, y);

                        howMuch--;
                        licznik = 0;
                    }
                }

            } while (howMuch > 0 && licznik < 3000);
        }
    }
}
