using System.Drawing;
using System.Runtime.InteropServices;

namespace IconLibrary
{
    /// <summary>
    /// IconLibrary
    /// </summary>
    public class Iconlib
    {

        /// <summary>
        /// Get Icon Handle
        /// </summary>
        /// <param name="file"> dll file name</param>
        /// <param name="index">icon index</param>
        /// <param name="largeIconHandle">largeicon Handle</param>
        /// <param name="smallIconHandle">smallicon Handle</param>
        /// <param name="icons">I don't know that.</param>
        /// <returns>Error Code?</returns>
        [DllImport("shell32.dll", EntryPoint = "ExtractIconEx", CharSet = CharSet.Unicode)]
        public static extern int ExtractIconEx([MarshalAs(UnmanagedType.LPTStr)] string file, int index, out IntPtr largeIconHandle, out IntPtr smallIconHandle, int icons);
        /// <summary>
        /// Icon destroy
        /// </summary>
        /// <param name="hIcon">Icon Handle</param>
        /// <returns> err code?</returns>
        [DllImport("User32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);
        /// <summary>
        /// Get Icon From dll
        /// </summary>
        /// <param name="path">dll file path</param>
        /// <param name="index">icon index</param>
        /// <returns>Icon</returns>
        private static Icon[] getIcon(string path, int index)
        {
            try
            {
                Icon[] icons = new Icon[2];
                IntPtr lIconH = IntPtr.Zero;
                IntPtr sIconH = IntPtr.Zero;
                ExtractIconEx(path, index, out lIconH, out sIconH, 1);
                icons[0] = (Icon)Icon.FromHandle(lIconH).Clone();
                icons[1] = (Icon)Icon.FromHandle(sIconH).Clone();
                DestroyIcon(lIconH);
                DestroyIcon(sIconH);
                return icons;
            }
            catch (Exception ex)
            {
                //nothing to do;
            }
            return null;
        }
        /// <summary>
        /// Get Small Icon From dll
        /// </summary>
        /// <param name="path">dll file path</param>
        /// <param name="index">icon index</param>
        /// <returns>Icon</returns>
        public static Icon getIcon_Small(string path, int index)
        {
            Icon[] icons = getIcon(path, index);
            if (icons == null) return null;
            return icons[1];
        }
        /// <summary>
        /// Get Large Icon From dll
        /// </summary>
        /// <param name="path">dll file path</param>
        /// <param name="index">icon index</param>
        /// <returns>Icon</returns>
        public static Icon getIcon_Large(string path, int index)
        {
            Icon[] icons = getIcon(path, index);
            if (icons == null) return null;
            return icons[0];
        }

    }
}