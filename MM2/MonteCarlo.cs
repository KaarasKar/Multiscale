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
    public partial class MonteCarlo
    {
        Neighbourhood n = new Neighbourhood();
        Random rand;

        public MonteCarlo()
        {
            rand = new Random();
        }

        public void Monte_Carlo_Start()
        {
            Core.Config.MC = false;
            while (n.anyEmpty())
            {
                Core.Config.MC = true;
                for (int x = 0; x < Core.Config.sizeX; x++)
                {
                    for (int y = 0; y < Core.Config.sizeY; y++)
                    {
                        if (Core.Config.orgTable[x][y] == 0)
                        {
                            int v = rand.Next(Core.Config.nucleation) + 1;
                            Core.Config.orgTable[x][y] = v;
                            Color newColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                            if (Core.Config.colors.Count <= Core.Config.nucleation)
                            {
                                Core.Config.colors.Add(newColor);
                                Core.Config.seeds++;
                            }
                        }
                    }
                }
            }
        }

        public void Monte_Carlo_Start2()
        {
            for (int i = 0; i < Core.Config.MCstepsno; i++)
            {
                newLimTab();
                MonteCarloStep();
            }

        }
        
        private void MonteCarloStep()
        {
            while (anyLim())
            {
                int i = rand.Next(Core.Config.sizeX);
                int j = rand.Next(Core.Config.sizeY);
                if (Core.Config.limTable[i][j])
                {
                    List<int> neighbours = GetNeighbours(i, j);
                    List<int> limNeighbour = new List<int>(neighbours);
                    limNeighbour.Add(Core.Config.orgTable[i][j]);
                    if (CheckForMC(limNeighbour))
                    {
                        int energy = GetEnergy(neighbours, Core.Config.orgTable[i][j]);
                        int newId = Core.Config.orgTable[i][j];
                        while (newId == Core.Config.orgTable[i][j] || Core.Config.checkedID.Contains(newId))
                            newId = neighbours[rand.Next(neighbours.Count)];
                        int newEnergy = GetEnergy(neighbours, newId);
                        if (newEnergy <= energy)
                            Core.Config.orgTable[i][j] = newId;
                    }
                    Core.Config.limTable[i][j] = false;
                }
            }
        }

        private void newLimTab()
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
                        Core.Config.limTable[x][y] = true;
                }
            }
        }

        private bool anyLim()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.limTable[i][j])
                        return true;
                }
            }
            return false;
        }

        public int GetEnergy(List<int> neighbours, int id)
        {
            int energy = 0;
            foreach (int nid in neighbours)
            {
                if (nid != id && nid > 0 && !(Core.Config.checkedID.Contains(nid) || Core.Config.checkedID.Contains(id)))
                    energy++;
            }
            return energy;
        }

        private bool CheckForMC(List<int> neighbourhoods)
        {
            Dictionary<int, int> numerous = new Dictionary<int, int>();
            foreach (int neighbourhood in neighbourhoods)
            {
                if (neighbourhood < 0 || Core.Config.checkedID.Contains(neighbourhood))
                    continue;
                if (numerous.Keys.Contains(neighbourhood))
                    numerous[neighbourhood]++;
                else
                    numerous.Add(neighbourhood, 1);
            }
            return numerous.Count > 1;
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

        private List<int> MCmoore(int x, int y)
        {
            List<int> neighbourhoods = new List<int>();
            int i = x;
            int j = y;
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

        private List<int> GetNeighbours(int x, int y)
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
    }
}
