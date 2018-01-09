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
    public class Config
    {
        //Basic
        public int sizeX = 100;
        public int sizeY = 100;
        public int seeds = 1;
        public int[][] orgTable;
        public int[][] pomTable;
        public bool[][] limTable;
        public int nucleation;
        public bool perio = false;
        public int method = 0;
        public ArrayList colors = new ArrayList();
        public List<int> checkedID = new List<int>();
        
        //Inclusion
        public int size;
        public int number;
        //public int circular_size;
        //public int circular_number;
        public bool after_simulation;
        public bool boundaries_after;

        public float probabity;

        //MC
        public int MCstepsno;
        public bool MC;

        //SRXMC
        public int SRX_step;
        public int SRX_nucleonsInDec;
        public int SRX_method;
        public bool SRX_Ganywhere;

        public int SRX_energy;

        public bool HGenous;
        public int SRX_nucleation;

        public bool[][] checkedTable;
        public int[][] energyTable;
        public int limit;

        public int bufX;
        public int bufY;
        public List<Color> energyColos;
    }
    
    
}
