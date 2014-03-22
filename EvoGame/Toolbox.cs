using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace EvoGame
{
    public static class Toolbox
    {

        [DllImport("user32.dll")]
        static extern IntPtr CreateIconFromResource(byte[] presbits, uint dwResSize, bool fIcon, uint dwVer);

        // modification here is :   byte[] resource in the call       
        public static Cursor CreateCursor(byte[] resource)
        {
            IntPtr myNew_Animated_hCursor;

            //byte[] resource = Properties.Resources.flower_anim;

            myNew_Animated_hCursor = CreateIconFromResource(resource, (uint)resource.Length, false, 0x00030000);

            if (!IntPtr.Zero.Equals(myNew_Animated_hCursor))
            {
                // all is good
                return new Cursor(myNew_Animated_hCursor);
            }
            else
            {  // resource wrong type or memory error occurred
                // normally this resource exists since you had to put  Properties.Resources. and a resource would appear and you selected it
                // the animate cursor desired  is the error generator since this call is not required for simple cursors



                throw new ApplicationException("Could not create cursor from Embedded resource ");
            }
        }
    }
}
