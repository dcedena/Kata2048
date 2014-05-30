using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kata2048_Design
{
    public partial class ucCell : UserControl
    {
        private List<int> _values = new List<int>() { 0, 2, 4, 8, 16, 
                                                      32, 64, 128, 256, 512, 
                                                      1024, 2048, 4096, 8192 };

        private List<Color> _colors = new List<Color>() { Color.Silver, Color.White, Color.Wheat, Color.SandyBrown, Color.Orange,
                                                          Color.Salmon, Color.Red, Color.Khaki, Color.Yellow, Color.RoyalBlue,
                                                          Color.SaddleBrown, Color.DarkGreen, Color.SkyBlue, Color.SpringGreen};

        public string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value == "0")
                    button1.Text = "";
                else
                    button1.Text = _value;

                button1.BackColor = GetBG(_value);
            }
        }

        private Color GetBG(string _value)
        {
            if (!String.IsNullOrEmpty(_value))
            {
                for (int i = 0; i < _values.Count; i++)
                {
                    if (_values[i].ToString() == _value)
                        return _colors[i];
                }
            }
            return Color.Empty;
        }


        public ucCell()
        {
            InitializeComponent();
        }

        public ucCell(int val) : this()
        {
            Value = val.ToString();
        }

    }
}
