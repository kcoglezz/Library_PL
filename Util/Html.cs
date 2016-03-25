using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Sistema.PL.Negocio.Util
{
    public class Html
    {
        public static TableCell CrearCeldaVisible(string strAncho, string strTexto, HorizontalAlign horAlign, string strEstilo, bool blVisible)
        {
            TableCell _objCell = CrearCelda(strAncho, strTexto, horAlign, strEstilo);
            _objCell.Visible = blVisible;
            return _objCell;
        }
        public static TableCell CrearCelda(string strAncho, string strTexto, HorizontalAlign horAlign, string strEstilo, bool blnWrap, int intColSpan)
        {
            TableCell _objCell = CrearCelda(strAncho, strTexto, horAlign, strEstilo, blnWrap);
            if (intColSpan > 0)
                _objCell.ColumnSpan = intColSpan;
            return _objCell;
        }

        public static TableCell CrearCelda(string strAncho, string strTexto, HorizontalAlign horAlign, string strEstilo, bool blnWrap)
        {
            TableCell _objCell = CrearCelda(strAncho, strTexto, horAlign, strEstilo);
            _objCell.Wrap = blnWrap;
            return _objCell;
        }

        public static TableCell CrearCelda(string strAncho, string strTexto, HorizontalAlign horAlign, string strEstilo)
        {
            TableCell _objCell = new TableCell();

            _objCell.Text = strTexto;
            _objCell.HorizontalAlign = horAlign;
            if (strAncho.Length > 0)
            {
                if (strAncho.IndexOf("%") > 0)
                    _objCell.Width = Unit.Percentage(int.Parse(strAncho.Replace("%", "")));
                else if (strAncho.Length > 0)
                    _objCell.Width = Unit.Pixel(int.Parse(strAncho));
            }
            _objCell.CssClass = strEstilo;
            return _objCell;
        }

        public static TableCell CrearCelda(string strAncho, string strTexto, HorizontalAlign horAlign, string strEstilo, int intRowspan)
        {
            TableCell _objCell = new TableCell();

            _objCell.Text = strTexto;
            _objCell.HorizontalAlign = horAlign;
            _objCell.RowSpan = intRowspan;
            if (strAncho.Length > 0)
            {
                if (strAncho.IndexOf("%") > 0)
                    _objCell.Width = Unit.Percentage(int.Parse(strAncho.Replace("%", "")));
                else if (strAncho.Length > 0)
                    _objCell.Width = Unit.Pixel(int.Parse(strAncho));
            }
            _objCell.CssClass = strEstilo;
            return _objCell;
        }

        public static TableCell CrearCelda(string strAncho, string strTexto, string strBGColor, HorizontalAlign horAlign,
            VerticalAlign verAlign, bool blnWrap, bool blnBold, int intAnchoBorde, string strEstilo)
        {
            TableCell _objCell = CrearCelda(strAncho, strTexto, horAlign, strEstilo, blnWrap);

            if (blnBold)
                _objCell.Text = "<b>" + strTexto + "</b>";
            _objCell.VerticalAlign = verAlign;
            _objCell.BackColor = System.Drawing.ColorTranslator.FromHtml(strBGColor);
            if (intAnchoBorde > 0)
                _objCell.BorderWidth = Unit.Pixel(intAnchoBorde);
            return _objCell;
        }

        public static TableCell CrearCelda(string strAncho, string strTexto, string strBGColor, HorizontalAlign horAlign,
            VerticalAlign verAlign, bool blnWrap, bool blnBold, int intAnchoBorde, string strEstilo,
            int intColspan, string strToolTip, int intRowSpan, string strID)
        {
            TableCell _objCell = new TableCell();

            _objCell.Text = strTexto;
            if (blnBold)
                _objCell.Text = "<b>" + strTexto + "</b>";
            _objCell.HorizontalAlign = horAlign;
            _objCell.VerticalAlign = verAlign;
            _objCell.BackColor = System.Drawing.ColorTranslator.FromHtml(strBGColor);
            if (strAncho.IndexOf("%") > 0)
                _objCell.Width = Unit.Percentage(int.Parse(strAncho.Replace("%", "")));
            else if (strAncho.Length > 0)
                _objCell.Width = Unit.Pixel(int.Parse(strAncho));
            if (intAnchoBorde > 0)
                _objCell.BorderWidth = Unit.Pixel(intAnchoBorde);
            _objCell.Wrap = blnWrap;
            if (intColspan > 1)
                _objCell.ColumnSpan = intColspan;
            if (intRowSpan > 1)
                _objCell.RowSpan = intRowSpan;
            if (strEstilo.Length > 0)
                _objCell.CssClass = strEstilo;
            if (strToolTip.Length > 0)
                _objCell.ToolTip = strToolTip;
            if (strID.Length > 0)
                _objCell.ID = strID;
            return _objCell;
        }

        public static TextBox CrearTexto(string strId, string strTexto, string strEstilo, int intMaxLength, int intTamano, string strAncho)
        {
            TextBox returnValue = null;
            returnValue = new TextBox();
            returnValue.ID = strId;
            returnValue.Text = strTexto;
            if (strEstilo.Length > 0)
                returnValue.CssClass = strEstilo;
            if (intMaxLength > -1)
                returnValue.MaxLength = intMaxLength;
            if (intTamano > -1)
                returnValue.Columns = intTamano;
            if (strAncho.IndexOf("%") > 0)
                returnValue.Width = Unit.Percentage(int.Parse(strAncho.Replace("%", "")));
            else if (strAncho.Trim().Length > 0)
                returnValue.Width = Unit.Pixel(int.Parse(strAncho));
            return returnValue;
        }

        //public static HyperLink CrearLink(string strTexto, string strUrl, string strToolTip)
        //{
        //    return CrearLink(strTexto, strUrl, strToolTip, string.Empty, string.Empty);
        //}

        //public static HyperLink CrearLink(string strTexto, string strUrl, string strToolTip, string strEstilo, string strTarget)
        //{
        //    HyperLink returnValue = new HyperLink();
        //    returnValue.Text = strTexto;
        //    if (strTarget.Length > 0)
        //        returnValue.Target = strTarget;
        //    returnValue.NavigateUrl = strUrl;
        //    returnValue.ToolTip = strToolTip;
        //    if (strEstilo.Length == 0) strEstilo = "c";
        //    returnValue.CssClass = strEstilo;
        //    return returnValue;
        //}
    }
}
