using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FileSearch.Windows
{
   /// <summary>
   ///
   /// </summary>
   public class API
   {

      private API(){}

      /// <summary>
      /// 
      /// </summary>
      [Flags] public enum HDI : uint
      {
         /// <summary></summary>
         HEIGHT     = 1,
         /// <summary></summary>
         WIDTH      = 1,
         /// <summary></summary>
         TEXT       = 2,
         /// <summary></summary>
         FORMAT     = 4,
         /// <summary></summary>
         LPARAM     = 8,
         /// <summary></summary>
         BITMAP     = 16,
         /// <summary></summary>
         IMAGE      = 0x20,
         /// <summary></summary>
         DI_SETITEM = 0x40,
         /// <summary></summary>
         ORDER      = 0x80,
         /// <summary></summary>
         HDI_FILTER = 0x100
      }

      /// <summary>
      /// 
      /// </summary>
      [Flags] public enum HDF : int
      {
         /// <summary></summary>
         LEFT            = 0,
         /// <summary></summary>
         RIGHT           = 1,
         /// <summary></summary>
         CENTER          = 2,
         /// <summary></summary>
         JUSTIFYMASK     = 3,
         /// <summary></summary>
         RTLREADING      = 4,
         /// <summary></summary>
         IMAGE           = 0x800,
         /// <summary></summary>
         BITMAP_ON_RIGHT = 0x1000,
         /// <summary></summary>
         BITMAP          = 0x2000,
         /// <summary></summary>
         STRING          = 0x4000,
         /// <summary></summary>
         OWNERDRAW       = 0x8000
      }

      /// <summary>
      /// 
      /// </summary>
      [Flags] public enum HDFT : uint
      {
         /// <summary></summary>
         ISSTRING   = 0x0000,
         /// <summary></summary>
         ISNUMBER   = 0x0001,
         /// <summary></summary>
         HASNOVALUE = 0x8000
      }

      /// <summary>
      /// 
      /// </summary>
      public enum WM : uint{}

      /// <summary>
      /// 
      /// </summary>
      public enum HDM : uint
      {
         /// <summary></summary>
         GETITEMCOUNT  = 0x1200,
         /// <summary></summary>
         GETITEM       = 0x120B,
         /// <summary></summary>
         SETITEM       = 0x120C,
         /// <summary></summary>
         SETIMAGELIST  = 0x1208
         /* other values omitted */
      }

      /// <summary>
      /// 
      /// </summary>
      public enum LVM : uint
      {
         /// <summary></summary>
         GETHEADER           = 0x101F,
         /// <summary></summary>
         SETCOLUMNORDERARRAY = 0x103A,
         /// <summary></summary>
         GETCOLUMNORDERARRAY = 0x103B
         /* other values omitted */
      }

      /// <summary>
      /// 
      /// </summary>
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
      public struct HDITEM
      {
         /// <summary></summary>
         public HDI    mask;
         /// <summary></summary>
         public int    cxy;
         /// <summary></summary>
         public string pszText;
         /// <summary></summary>
         public IntPtr hbm;
         /// <summary></summary>
         public int    cchTextMax;
         /// <summary></summary>
         public HDF    fmt;
         /// <summary></summary>
         public int    lParam;
         /// <summary></summary>
         public int    iImage;
         /// <summary></summary>
         public int    iOrder;
         /// <summary></summary>
         public HDFT   type;
         /// <summary></summary>
         public IntPtr pvFilter;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int SendMessage(IntPtr hWnd, uint msg, uint wParam, int lParam);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      public static int SendMessage(IntPtr hWnd, Enum msg, uint wParam, int lParam)
      {
         return SendMessage(hWnd, (uint)(WM)msg, wParam, lParam);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport("User32.dll",CharSet = CharSet.Auto,SetLastError=true)]
      public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      public static IntPtr SendMessage(IntPtr hWnd, Enum msg, IntPtr wParam, IntPtr lParam)
      {
         return SendMessage(hWnd, (uint)(WM)msg, wParam, lParam);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int SendMessage(IntPtr hWnd, uint msg, uint wParam, int[] lParam);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      public static int SendMessage(IntPtr hWnd, Enum msg, uint wParam, int[] lParam)
      {
         return SendMessage(hWnd, (uint)(WM)msg, wParam, lParam);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int SendMessage(IntPtr hWnd, uint msg, uint wParam, ref HDITEM lParam);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="msg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      public static int SendMessage(IntPtr hWnd, Enum msg, uint wParam, ref HDITEM lParam)
      {
         return SendMessage(hWnd, (uint)(WM)msg, wParam, ref lParam);
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="hwndHD"></param>
      /// <returns></returns>
      public static int Header_GetItemCount(IntPtr hwndHD)
      {
         return SendMessage(hwndHD, HDM.GETITEMCOUNT, 0, 0);
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="hwndHD"></param>
      /// <param name="index"></param>
      /// <param name="mask"></param>
      /// <returns></returns>
      public static HDITEM Header_GetItem(IntPtr hwndHD, int index, HDI mask)
      {
         HDITEM rtn = new HDITEM();

         rtn.mask = mask;
         if((mask & HDI.TEXT) == HDI.TEXT)
         {
            rtn.pszText = new string('\0', 512);
            rtn.cchTextMax = 512;
         }
         SendMessage(hwndHD, HDM.GETITEM, (uint)index, ref rtn);
         return rtn;
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="hwndHD"></param>
      /// <param name="index"></param>
      /// <param name="hdi"></param>
      /// <returns></returns>
      public static bool Header_SetItem(IntPtr hwndHD, int index, HDITEM hdi)
      {
         return SendMessage(hwndHD, HDM.SETITEM, (uint)index, ref hdi) != 0;
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="hwndLV"></param>
      /// <returns></returns>
      public static IntPtr GetHeader(IntPtr hwndLV)
      {
         return (IntPtr)SendMessage(hwndLV, LVM.GETHEADER, 0, 0);
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="hwndLV"></param>
      /// <returns></returns>
      public static int[] GetColumnOrderArray(IntPtr hwndLV)
      {
         int[] rtn = new int[Header_GetItemCount(GetHeader(hwndLV))];
         SendMessage(hwndLV, LVM.GETCOLUMNORDERARRAY, (uint)rtn.Length, rtn);
         return rtn;
      }

      /// <summary>
      ///
      /// </summary>
      /// <param name="hwndLV"></param>
      /// <param name="array"></param>
      /// <returns></returns>
      public static bool SetColumnOrderArray(IntPtr hwndLV, int[] array)
      {
         return SendMessage(hwndLV, LVM.SETCOLUMNORDERARRAY, (uint)array.Length, array) != 0;
      }

      /// <summary>
      /// Get a column's position
      /// </summary>
      /// <param name="hwndLV">handle to listview</param>
      /// <param name="ColumnIndex">Column index to retrieve</param>
      /// <returns>Position of column</returns>
      public static int GetColumnPosition(IntPtr hwndLV, int ColumnIndex)
      {
         return Header_GetItem(GetHeader(hwndLV), ColumnIndex, HDI.ORDER).iOrder;
      }

      /// <summary>
      /// Set a column's position
      /// </summary>
      /// <param name="hwndLV">handle to listview</param>
      /// <param name="ColumnIndex">Column Index to set</param>
      /// <param name="iOrder">Position to set</param>
      public static void SetColumnPosition(IntPtr hwndLV, int ColumnIndex, int iOrder)
      {
         HDITEM hdi = new HDITEM();
         hdi.mask = HDI.ORDER;
         hdi.iOrder = iOrder;
         Header_SetItem(GetHeader(hwndLV), ColumnIndex, hdi);
      }

      /// <summary>
      /// Set the Header Column image
      /// </summary>
      /// <param name="list">ListView</param>
      /// <param name="columnIndex">Current column index</param>
      /// <param name="order">Current sort order</param>
      /// <param name="showImage">Display image in column (turn on/off image)</param>
      public static void SetHeaderImage(ListView list, int columnIndex, SortOrder order, bool showImage)
      {
         IntPtr _header;
         HDITEM _hdItem = new HDITEM();
         int _iconNumber = 0;

         //set the image index based on sort order from the smallimagelist property
         if( order == SortOrder.Ascending )
            _iconNumber = 0;
         else
            _iconNumber = 1;

         //get a handle to the listview header component
         _header = GetHeader(list.Handle);

         //set up the required structure members
         _hdItem.mask = HDI.IMAGE | HDI.FORMAT;
         _hdItem.pszText = list.Columns[columnIndex].Text;

         // check to show the indicator image
         if( showImage )
         {
            _hdItem.fmt = HDF.STRING | HDF.IMAGE | HDF.BITMAP_ON_RIGHT;
            _hdItem.iImage = _iconNumber;
         }
         else
            _hdItem.fmt = HDF.STRING;

         //modify the header
         SendMessage(_header, HDM.SETITEM, (uint)columnIndex, ref _hdItem);
      }

      /// <summary>
      /// Set the ListView's header's imagelist
      /// </summary>
      /// <param name="hwndLV">ListView handle</param>
      /// <param name="hwndIL">ImageList handle</param>
      public static void SetHeaderImageList(IntPtr hwndLV, IntPtr hwndIL)
      {
         SendMessage(GetHeader(hwndLV),HDM.SETIMAGELIST,IntPtr.Zero,hwndIL);
      }     
   }
}