using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

// Modified from c-sharpcorner.com, Kirtan Patel,
// Make form stay always on top of every window.
// http://bit.ly/zKnXT2

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos (IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public Form1 () {
            InitializeComponent ();
        }

        private void pictureBox1_Click (object sender, EventArgs e) {
        }

        private void Form1_Load (object sender, EventArgs e) {

            Int32 screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            Int32 form1Heigth = Form1.ActiveForm.Height;

            // API doc for SetWindowPos: http://bit.ly/zf2LBy
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, screenHeight - form1Heigth, 0, 0, TOPMOST_FLAGS);
        }

    }
}
