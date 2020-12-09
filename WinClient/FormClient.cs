using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AReport.Client
{
    public enum FormClientMode { Grupo, Supervisor, Administrador}

    public partial class FormClient : Form
    {
        public FormClientMode EditMode
        {
            set
            {
                string text;
                switch (value)
                {
                    case FormClientMode.Grupo:
                        text = "Modo Jefe Grupo";
                        break;
                    case FormClientMode.Supervisor:
                        text = "Modo Supervisor RR HH";
                        break;

                    case FormClientMode.Administrador:
                    default:
                        text = "Modo Administrador";
                        break;
                }
                label1.Text = text;

            }
        }

        public FormClient()
        {
            InitializeComponent();
        }
    }
}
