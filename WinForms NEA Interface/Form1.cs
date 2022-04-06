using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinForms_NEA_Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox4.Visible = true;
            label1.Visible = true;
            label4.Visible = true;
            comboBox2.Visible = false;
            comboBox5.Visible = false;
            comboBox3.Visible = false;
            comboBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            comboBox4.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            comboBox2.Visible = true;
            comboBox5.Visible = true;
            comboBox3.Visible = false;
            comboBox6.Visible = false;
            label2.Visible = true;
            label3.Visible = false;
            label5.Visible = true;
            label6.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            comboBox4.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            comboBox2.Visible = false;
            comboBox5.Visible = false;
            comboBox3.Visible = true;
            comboBox6.Visible = true;
            label2.Visible = false;
            label3.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            textBox1.Text = " ";
            if (radioButton1.Checked == true)
            {
                int[,] Graph = new int[5, 5]
                {
                {0,2,4,0,0 },
                {2,0,1,5,0 },
                {4,1,0,3,1 },
                {0,5,3,0,0 },
                {0,0,1,0,0 } };
                int GraphVertices = 5;
                int StartingNode = Convert.ToInt32(comboBox1.SelectedValue)-1;
                int DesinationNode = Convert.ToInt32(comboBox4.SelectedValue);
                ShortestPathAnalysis s = new ShortestPathAnalysis();

                List<RouteNode> Route = s.DijkstraAlgorithm(GraphVertices,Graph,StartingNode,DesinationNode);
                textBox1.Text += ("The route is ");
                foreach (var RouteNode in Route) 
                {

                    textBox1.Text += (RouteNode.NodeIndex + ", ");
                }
                    textBox1.Text+=("The route's total distance is " + Route.Last().Distance);
                button1.Visible = true;
                }
            
            else if (radioButton2.Checked == true)
            {
                int[,] Graph = new int[8, 8]
                    {
                {0,2,0,2,0,0,8,0 },
                {2,0,1,0,0,3,0,5 },
                {0,1,0,1,0,0,0,0 },
                {2,0,1,0,2,0,0,0 },
                {0,0,0,2,0,1,0,0 },
                {0,3,0,0,1,0,3,0 },
                {8,0,0,0,0,3,0,1 },
                {0,5,0,0,0,0,1,0 } };
                int GraphVertices = 8;
                int StartingNode = Convert.ToInt32(comboBox2.SelectedValue)-1;
                int DesinationNode = Convert.ToInt32(comboBox5.SelectedValue);
                ShortestPathAnalysis s = new ShortestPathAnalysis();

                List<RouteNode> Route = s.DijkstraAlgorithm(GraphVertices, Graph, StartingNode, DesinationNode);
                textBox1.Text += ("The route is ");
                foreach (var RouteNode in Route)
                {
                    textBox1.Text += (RouteNode.NodeIndex + ", ");
                }
                textBox1.Text += ("The route's total distance is " + Route.Last().Distance);
                button1.Visible = true;
            }
            else if (radioButton3.Checked == true)
            {
                int[,] Graph = new int[10, 10]
                 {
                {0,0,1,4,5,0,0,0,0,15 },
                {0,0,0,0,0,3,0,0,5,0 },
                {1,0,0,2,0,0,0,0,0,0 },
                {4,0,2,0,1,0,1,0,0,0 },
                {5,0,0,1,0,0,0,0,0,0 },
                {0,3,0,0,0,0,3,2,4,0 },
                {0,0,0,1,0,3,0,6,0,0 },
                {0,0,0,0,0,2,6,0,5,0 },
                {0,5,0,0,0,4,0,5,0,3 },
                {15,0,0,0,0,0,0,0,3,0 } };
                int GraphVertices = 10;
                int StartingNode = Convert.ToInt32(comboBox3.SelectedValue)-1;
                int DesinationNode = Convert.ToInt32(comboBox6.SelectedValue);
                ShortestPathAnalysis s = new ShortestPathAnalysis();

                List<RouteNode> Route = s.DijkstraAlgorithm(GraphVertices, Graph, StartingNode, DesinationNode);
                textBox1.Text += ("The route is ");
                foreach (var RouteNode in Route)
                {
                    textBox1.Text += (RouteNode.NodeIndex + ", ");
                }
                textBox1.Text += ("The route's total distance is " + Route.Last().Distance);
                button1.Visible = true;
            }
        }
    }
}
