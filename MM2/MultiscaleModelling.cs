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
using System.IO;

namespace MultiscaleModelling1
{
    public partial class MultiscaleModelling : Form
    {
        Neighbourhood n = new Neighbourhood();
        MonteCarlo mc = new MonteCarlo();
        SRXMC srx = new SRXMC();

        Graphics g;
        Random rand;

        public MultiscaleModelling()
        {
            InitializeComponent();
            Change_Properties();
            n.newTab();
            rand = new Random();

            g = VisualizationPictureBox.CreateGraphics();
            g.Clear(Color.White);
            VisualizationPictureBox.MouseClick += pictureBox1_MouseClick;
            Core.Config.colors.Add(Color.White);
            
            cb_Neighbourhood.SelectedIndex = 0;
            cb_SRX_method.SelectedIndex = 0;
            srx.energyColorsAndTabInit();
        }

        public void run()
        {
            bool mapChanged = true;
            //bool first = false;
            while (n.anyEmpty() && mapChanged)
            {
                switch (Core.Config.method)
                {
                    case 0:
                        n.vonNeuman();
                        break;
                    case 1:
                        n.moore();
                        break;
                    case 2:
                        n.hexagonalRandom();
                        break;
                    case 3:
                        n.PentagonalRandom();
                        break;
                    case 4:
                        n.mooreExt();
                        break;
                    default:
                        break;
                }
                mapChanged = n.CheckAndCopyTab();
                //if (first)
                //{
                //    draw();
                //    first = false;
                //    Thread.Sleep(3000);
                //}
            }
            if (Core.Config.after_simulation)
            {
                n.InclusionAfter(0);
                n.InclusionAfter(1);
            }
            if (Core.Config.boundaries_after)
            {
                n.BoundariesCheck(0);
                n.BoundariesCheck(1);
            }
            draw();
            Core.Config.limit = Core.Config.seeds;
        }

        public void Change_Properties()
        {
            //Basic
            Core.Config.perio = cb_Periodic.Checked;
            Core.Config.method = cb_Neighbourhood.SelectedIndex;
            //Core.Config.sizeX = Convert.ToInt32(tb_DimensionX.Text);
            //Core.Config.sizeY = Convert.ToInt32(tb_DimensionY.Text);
            Core.Config.nucleation = Convert.ToInt32(tb_Nucleation.Text);
            Core.Config.SRX_nucleation = Convert.ToInt32(tb_SRXnucleation.Text);

            //Inclusion
            Core.Config.size = Convert.ToInt32(tb_SquareDiameter.Text);
            Core.Config.number = Convert.ToInt32(tb_CountSquare.Text);
            //Core.Config.circular_size = Convert.ToInt32(tb_CircularRadius.Text);
            //Core.Config.circular_number = Convert.ToInt32(tb_CountCircular.Text);
            Core.Config.after_simulation = cb_After_simulation.Checked ? true: false;
            Core.Config.boundaries_after = Boundariess.Checked ? true : false;

            Core.Config.probabity = Convert.ToInt32(tb_probability.Text);

            //MC
            Core.Config.MCstepsno = Convert.ToInt32(tb_MC_steps.Text);

            //SRXMC
            Core.Config.SRX_step = Convert.ToInt32(tb_SRX_steps.Text);
            Core.Config.SRX_nucleonsInDec = Convert.ToInt32(tb_Inc_nucleation.Text);
            Core.Config.SRX_method = cb_SRX_method.SelectedIndex;
            Core.Config.SRX_Ganywhere = cb_Ganywhere.Checked ? true : false;
            Core.Config.SRX_energy = Convert.ToInt32(tb_SRX_energy.Text);
            Core.Config.HGenous = cb_HGenous.Checked ? true : false;
        }
       

        void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int size =Core.Config.sizeX >Core.Config.sizeY ?Core.Config.sizeX :Core.Config.sizeY;
            int x = e.X / (VisualizationPictureBox.Width / size);
            int y = e.Y / (VisualizationPictureBox.Height / size);

            Core.Config.bufX = x;
            Core.Config.bufY = y;

            if (x >=Core.Config.sizeX || y >=Core.Config.sizeY)
                return;
            if (Core.Config.orgTable[x][y] == 0)
            {
                Core.Config.orgTable[x][y] = Core.Config.seeds;
                Color newColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                Core.Config.colors.Add(newColor);
                draw();
                Core.Config.seeds++;
            }
            else if(substructureCheck ||dualphaseCheck || boundariesCheck)
            {
                Core.Config.checkedID.Add(Core.Config.orgTable[x][y]);
            }
        }

        private void draw()
        {
            int size = Core.Config.sizeX > Core.Config.sizeY ? Core.Config.sizeX : Core.Config.sizeY;
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    SolidBrush brush = new SolidBrush(Core.Config.orgTable[i][j] == 0 ? Color.White : Core.Config.orgTable[i][j] == -1 ? Color.Black : (Color)Core.Config.colors[Core.Config.orgTable[i][j]]);
                    Rectangle rect = new Rectangle(i * VisualizationPictureBox.Width / size, j * VisualizationPictureBox.Height / size, VisualizationPictureBox.Width / size, VisualizationPictureBox.Height / size);
                    g.FillRectangle(brush, rect);
                }
            }
        }

        private void DrawEnergy()
        {
            int size = Core.Config.sizeX > Core.Config.sizeY ? Core.Config.sizeX : Core.Config.sizeY;
            for (int i = 0; i < Core.Config.sizeX; i++)
            {
                for (int j = 0; j < Core.Config.sizeY; j++)
                {
                    SolidBrush brush = new SolidBrush(Core.Config.energyColos[Core.Config.energyTable[i][j]]);
                    Rectangle rect = new Rectangle(i * VisualizationPictureBox.Width / size, j * VisualizationPictureBox.Height / size, VisualizationPictureBox.Width / size, VisualizationPictureBox.Height / size);
                    g.FillRectangle(brush, rect);
                }
            }
        }

        private void SRXMCStep(int nucleons)
        {
            n.newCheckedTab();
            srx.seedNucleons(nucleons);
            while (srx.anyUnchecked() && srx.anyUnderLimit())
            {
                int x = rand.Next(Core.Config.sizeX);
                int y = rand.Next(Core.Config.sizeY);
                if (Core.Config.bufX == x && Core.Config.bufY == y)
                    x = x;
                if (Core.Config.checkedTable[x][y])
                    continue;
                List<int> neighbours = n.GetNeighbours(x, y);
                List<int> neighboursToCheck = new List<int>(neighbours);
                neighboursToCheck.Add(Core.Config.orgTable[x][y]);
                if (neighboursToCheck.Any(a => a != neighboursToCheck[0]))
                {
                    int newID = Core.Config.orgTable[x][y];
                    while (newID == Core.Config.orgTable[x][y])
                        newID = neighbours[rand.Next(neighbours.Count)];
                    if (newID >= Core.Config.limit && Core.Config.orgTable[x][y] < Core.Config.limit)
                    {
                        //calculate energy 
                        int energyBefore = mc.GetEnergy(neighbours, Core.Config.orgTable[x][y]) + Core.Config.energyTable[x][y];
                        int energyAfter = mc.GetEnergy(neighbours, newID);
                        if (energyAfter <= energyBefore)
                        {
                            Core.Config.orgTable[x][y] = newID;
                            Core.Config.energyTable[x][y] = 0;
                        }
                    }
                }
                Core.Config.checkedTable[x][y] = true;
            }
            draw();
            Thread.Sleep(500);
        }

        private void Click_Start(object sender, EventArgs e) 
        {
            Change_Properties();
            run();
        }

        private void Click_Clear(object sender, EventArgs e) 
        {
            Change_Properties();
            n.newTab();
            g.Clear(Color.White);
        }

        private void Click_Random(object sender, EventArgs e) 
        {
            Change_Properties();
            n.Random_nucleation();
            draw();
        }

        private void Click_Square(object sender, EventArgs e) 
        {
            Change_Properties();
            n.SquareInclusionBefore();
            draw();
        }

        private void Click_Circular(object sender, EventArgs e) 
        {
            Change_Properties();
            n.CircularInclusionBefore();
            draw();
        }

        bool substructureCheck = false;
        private void Click_Substructure(object sender, EventArgs e) 
        {
            if (substructureCheck)
            {
                substructureCheck = false;
                n.ClearTable();
                draw();
            }
            else
            {
                substructureCheck = true;
                Core.Config.checkedID.Clear();
            }
        }

        bool dualphaseCheck = false;
        //internal static object Value;

        private void Click_Dualphase(object sender, EventArgs e)  
        {
            if (dualphaseCheck)
            {
                dualphaseCheck = false;
                n.ChangeTableColor();
                draw();
            }
            else
            {
                dualphaseCheck = true;
                Core.Config.checkedID.Clear();
            }
        }

        private void Click_MonteCarlo(object sender, EventArgs e) 
        { 
            Change_Properties();
            mc.Monte_Carlo_Start();
            draw();
            if (Core.Config.MC && Core.Config.MCstepsno == 1)
                return;
            mc.Monte_Carlo_Start2();
            draw();
        }

        private void Click_SRXMC(object sender, EventArgs e)
        {
            Change_Properties();
            n.newLimTab();
            for (int i = 0; i < Core.Config.SRX_step; i++)
            {
                SRXMCStep(Core.Config.SRX_nucleation);
                switch (Core.Config.SRX_method)
                {
                    case 0:
                        break;
                    case 1:
                        Core.Config.SRX_nucleation += Core.Config.SRX_nucleonsInDec;
                        break;
                    case 2:
                        Core.Config.SRX_nucleation = Math.Max(0, Core.Config.SRX_nucleation - Core.Config.SRX_nucleonsInDec);
                        break;
                    case 3:
                        Core.Config.SRX_nucleation = 0;
                        break;
                }
            }
            draw();

        }

        private void Click_Energy(object sender, EventArgs e) 
        {
            srx.DistributeEnergy();
        }

        private void cb_toggle_energy_CheckedChanged(object sender, EventArgs e) 
        {
            if (cb_toggle_energy.Checked)
            {
                DrawEnergy();
            }
            else
            {
                draw();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tb_SRX_steps_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_SquareDiameter_TextChanged(object sender, EventArgs e)
        {

        }

        private void toBMP_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Obrazki (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(500, 500);

                VisualizationPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0,
                    500, 500));

                var fileName = saveFileDialog1.FileName;
                bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void fromBMP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Obrazki (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap image1 = (Bitmap)Image.FromFile(openFileDialog1.FileName, true);
                VisualizationPictureBox.Image = image1;
            }
        }

        private void exportToTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter sr = new StreamWriter("file.txt"))
            {
                sr.WriteLine(VisualizationPictureBox.Width);
                sr.WriteLine(VisualizationPictureBox.Height);
            }
        }


        private void tb_probability_TextChanged(object sender, EventArgs e)
        {

        }

        private void MultiscaleModelling_Load(object sender, EventArgs e)
        {

        }

        bool boundariesCheck = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (boundariesCheck)
            {
                boundariesCheck = false;
                n.ClearTable();
                draw();
            }
            else
            {
                boundariesCheck = true;
                Core.Config.checkedID.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change_Properties();
            mc.Monte_Carlo_Start2();
            draw();
        }
    }
}
