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
    public partial class SRXMC
    {
        Neighbourhood n = new Neighbourhood();
        Random rand;

        public SRXMC()
        {
            rand = new Random();
        }

        public bool anyUnchecked()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (!Core.Config.checkedTable[i][j])
                        return true;
                }
            }
            return false;
        }

        public bool anyUnderLimit()
        {
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    if (Core.Config.orgTable[i][j] < Core.Config.limit)
                        return true;
                }
            }
            return false;
        }

        public void seedNucleons(int nucleons)
        {
            if (Core.Config.SRX_Ganywhere)
            {
                int nMax = 100;
                while (nucleons > 0)
                {
                    int x = rand.Next(Core.Config.sizeX);
                    int y = rand.Next(Core.Config.sizeY);
                    if (Core.Config.limTable[x][y] && Core.Config.orgTable[x][y] < Core.Config.limit)
                    {
                        Core.Config.orgTable[x][y] = Core.Config.seeds;
                        Color newColor = Color.FromArgb(rand.Next(256), 0, 0);
                        Core.Config.colors.Add(newColor);
                        Core.Config.seeds++;
                        Core.Config.energyTable[x][y] = 0;
                        nucleons--;
                        nMax = 100;
                    }
                    if (nMax == 0)
                        break;
                    nMax--;
                }
            }
            else
            {
                n.Random_nucleation_srxmc(nucleons);
            }
        }

        public void DistributeEnergy()
        {
            energyColorsAndTabInit();
            int energy = Core.Config.SRX_energy;
            if (Core.Config.HGenous)
            {
                for (int i = 0; i < Core.Config.sizeX; i++)
                {
                    for (int j = 0; j < Core.Config.sizeY; j++)
                    {
                        Core.Config.energyTable[i][j] = energy; 
                    }
                }
            }
            else
            {
                n.newLimTab();
                for (int i = 0; i < Core.Config.sizeX; i++)
                {
                    for (int j = 0; j < Core.Config.sizeY; j++)
                    {
                        if (Core.Config.limTable[i][j])
                            Core.Config.energyTable[i][j] = energy;
                        else
                            Core.Config.energyTable[i][j] = 1;
                    }
                }
            }
        }

        public void energyColorsAndTabInit()
        {
            Core.Config.energyColos = new List<Color>();

            int maxEnergy = Core.Config.SRX_energy;
            int changeColor = 255 / (maxEnergy + 1);
            int green = 0;
            int blue = 255;

            for (int i = 0; i <= maxEnergy; i++)
            {
                Core.Config.energyColos.Add(Color.FromArgb(0, green, blue));
                green += changeColor;
                blue -= changeColor;
            }

            newEnergyTab();
        }

        private void newEnergyTab()
        {
            Core.Config.energyTable = new int[Core.Config.sizeX][];

            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                Core.Config.energyTable[i] = new int[Core.Config.sizeY];
            }
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    Core.Config.energyTable[i][j] = 0;
                }
            }
        }

    }
}