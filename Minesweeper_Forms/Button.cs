using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Forms
{
    class Button : System.Windows.Forms.Button
    {
        int row = -1;
        int column = -1;
        bool visited = false;
        bool live = false;
        int neighbour = 0;

        public Button(int r, int c)
        {
            row = r;
            column = c;
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(40, 40);
            }
        }

        public bool getVisited()
        {
            return visited;
        }

        public bool getLive()
        {
            return live;
        }

        public int getNeighbours()
        {
            return neighbour;
        }

        public int getRow()
        {
            return row;
        }

        public int getColumn()
        {
            return column;
        }

        public void setVisited(bool v)
        {
            visited = v;
        }

        public void setLive(bool l)
        {
            live = l;
        }

        public void setNeighbour(int n)
        {
            neighbour = n;
        }

        public void setRow(int r)
        {
            row = r;
        }

        public void setColumn(int c)
        {
            column = c;
        }
    }
}
