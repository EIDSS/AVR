using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using bv.common.Configuration;
using System.Threading;

namespace eidss.model.Helpers
{
    public abstract class ExcelFileReader
    {
        protected IWorkbook workbook;
        protected DataFormatter dataFormatter;
        protected IFormulaEvaluator formulaEvaluator;

        //
        // Initialize from a stream of Excel file
        //
        protected void InitializeMembers(Stream excelFileStream)
        {
            this.workbook = WorkbookFactory.Create(excelFileStream);
            if (this.workbook != null)
            {
                this.dataFormatter = new DataFormatter(CultureInfo.InvariantCulture);
                this.formulaEvaluator = WorkbookFactory.CreateFormulaEvaluator(this.workbook);
            }
        }

        //
        // Get formatted value as string from the specified cell
        //
        protected string GetFormattedValue(ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated and formatted cell value
                    returnValue = this.dataFormatter.FormatCellValue(cell, this.formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = dataFormatter.FormatRawCellContents(cell.NumericCellValue, 0,
                                    cell.CellStyle.GetDataFormatString());
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }

        //
        // Get unformatted value as string from the specified cell
        //
        protected string GetUnformattedValue(ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated cell value
                    returnValue = (cell.CellType == CellType.Numeric ||
                    (cell.CellType == CellType.Formula &&
                    cell.CachedFormulaResultType == CellType.Numeric)) ?
                        formulaEvaluator.EvaluateInCell(cell).NumericCellValue.ToString() :
                        this.dataFormatter.FormatCellValue(cell, this.formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = cell.NumericCellValue.ToString();
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }
    }

    public class ExcelFileWrapper : ExcelFileReader, IDisposable
    {
        public ExcelFileWrapper()
        {
            workbook = new HSSFWorkbook();
            workbook.CreateSheet("506 file errors");
            if (workbook != null)
            {
                dataFormatter = new DataFormatter(CultureInfo.InvariantCulture);
                formulaEvaluator = WorkbookFactory.CreateFormulaEvaluator(workbook);
            }

        }
        public ExcelFileWrapper(IWorkbook book)
        {
            workbook = book;
        }
        internal bool ShoudDisposeWorkbook = true;
        bool m_Disposed;
        public void Dispose()
        {
            if (!m_Disposed)
            {
                if (ShoudDisposeWorkbook)
                    Clear();
                m_DuplicateRowCellStyles = null;
                m_CellStyles = null;
                m_Disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        private void Clear()
        {
            var disposable = workbook as IDisposable;
            if (disposable != null)
                disposable.Dispose();
            m_DuplicateRowCellStyles.Clear();
            m_CellStyles.Clear();
            workbook = null;
        }
        public void Read(string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    Read(stream);
                    stream.Close();
                }
            }
            catch (Exception)
            {
                Clear();
            }
        }

        public void Read(Stream excelFileStream)
        {
            InitializeMembers(excelFileStream);
        }

        public void Save(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
                file.Close();
            }
        }

        public IWorkbook Workbook
        {
            get { return workbook; }
        }

        public string GetCellText(ICell cell)
        {
            return GetFormattedValue(cell);
        }

        public object GetCellValue(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                        return cell.DateCellValue;
                    return GetFormattedValue(cell);
                case CellType.String:
                    return cell.StringCellValue;
                default:
                    return GetFormattedValue(cell);
            }
        }
        private Dictionary<short, ICellStyle> m_CellStyles = new Dictionary<short, ICellStyle>();
        private ICellStyle ThaiDateStyle = null;
        private const string ValidationCommentAuthor = "506 format validator";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="comment"></param>
        /// <returns>
        /// true  - if validation comment was successfully added
        /// false - if validation comment is presented in the cell already, no new validation comment is added (this means that all validation errors are written to the workboor already)
        /// </returns>
        public bool SetupErrorCell(ICell cell, string comment)
        {
            ICellStyle style;
            if (m_CellStyles.ContainsKey(cell.CellStyle.DataFormat))
                style = m_CellStyles[cell.CellStyle.DataFormat];
            else
            {
                style = Workbook.CreateCellStyle();
                style.DataFormat = cell.CellStyle.DataFormat;
                style.FillPattern = FillPattern.SolidForeground;
                style.FillForegroundColor = GetErrorBackground();
                m_CellStyles.Add(cell.CellStyle.DataFormat, style);
            }
            CreateCellComment(cell, comment, 3);
            cell.CellStyle = style;
            return true;
        }

        private short GetErrorBackground()
        {
            return IndexedColors.Coral.Index;
        }
        private short GetErrorRowBackground()
        {
            return IndexedColors.Gold.Index;
        }

        private void CreateCellComment(ICell cell, string comment, int commentWidth)
        {
            if (cell.CellComment != null)
                cell.RemoveCellComment();
            var linesCount = comment.Split('\n').Length + 1;
            var patr = cell.Sheet.CreateDrawingPatriarch();
            var c =
                patr.CreateCellComment(patr.CreateAnchor(0, 0, 0, 0, cell.ColumnIndex, cell.RowIndex,
                    cell.ColumnIndex + commentWidth, cell.RowIndex + linesCount));
            c.String = Workbook.GetCreationHelper().CreateRichTextString(comment);
            cell.CellComment = c;

        }
        private ICellStyle m_DuplicateRowStyle = null;
        private Dictionary<short, ICellStyle> m_DuplicateRowCellStyles = new Dictionary<short, ICellStyle>();
        internal void SetupErrorRow(IRow row, string comment)
        {
            if (m_DuplicateRowStyle == null)
            {
                m_DuplicateRowStyle = Workbook.CreateCellStyle();
                m_DuplicateRowStyle.FillPattern = FillPattern.SolidForeground;
                m_DuplicateRowStyle.FillForegroundColor = GetErrorRowBackground();
            }
            row.RowStyle = m_DuplicateRowStyle;
            for (int i = row.FirstCellNum; i <= row.LastCellNum; i++)
            {
                var cell = row.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                if (cell == null || (cell.CellComment != null && cell.CellComment.String.Length > 0))
                    continue;
                ICellStyle style;
                if (m_DuplicateRowCellStyles.ContainsKey(cell.CellStyle.DataFormat))
                    style = m_DuplicateRowCellStyles[cell.CellStyle.DataFormat];
                else
                {
                    style = Workbook.CreateCellStyle();
                    style.DataFormat = cell.CellStyle.DataFormat;
                    style.FillPattern = FillPattern.SolidForeground;
                    style.FillForegroundColor = GetErrorRowBackground();
                    m_DuplicateRowCellStyles.Add(cell.CellStyle.DataFormat, style);
                }
                cell.CellStyle = style;
                if (i == 0)
                {
                    CreateCellComment(cell, comment, 4);
                }
            }
        }

        public void ClearCommentStyles()
        {
            m_DuplicateRowStyle = null;
            m_DuplicateRowCellStyles.Clear();
            m_CellStyles.Clear();
        }

        private ICellStyle m_HeaderRowStyle;
        private ICellStyle GetHeaderRowStyle()
        {
            if(m_HeaderRowStyle == null)
            {
                m_HeaderRowStyle = Workbook.CreateCellStyle();
                m_HeaderRowStyle.GetFont(Workbook).Boldweight = (short)FontBoldWeight.Bold;
            }
            return m_HeaderRowStyle;
        }
        private ICellStyle m_DefaultRowStyle;
        private ICellStyle GetDefaultRowStyle()
        {
            if (m_DefaultRowStyle == null)
            {
                m_DefaultRowStyle = Workbook.CreateCellStyle();
                m_DefaultRowStyle.GetFont(Workbook).Boldweight = (short)FontBoldWeight.Normal;
            }
            return m_DefaultRowStyle;
        }
        public IRow CreateHeaderRow(List<string> captions, bool addRowNumColumn)
        {
            var sheet = workbook.GetSheetAt(0);
            if (sheet == null)
                sheet = workbook.CreateSheet();
            IRow row;
            if (sheet.PhysicalNumberOfRows > 0)
            {
                row = sheet.GetRow(0);
                sheet.RemoveRow(row);
            }
            row = sheet.CreateRow(0);
            row.RowStyle = GetHeaderRowStyle();
            if (addRowNumColumn)
            {
                row.CreateCell(0, CellType.String).SetCellValue("Row #");
            }
            int i = row.Cells.Count;
            foreach (var caption in captions)
            {
                row.CreateCell(i++, CellType.String).SetCellValue(caption);
            }
            return row;
        }

        public IRow CreateRow(int rowNum)
        {
            var sheet = workbook.GetSheetAt(0);
            if (sheet.PhysicalNumberOfRows > rowNum )
                return sheet.GetRow(rowNum);
            var row = sheet.CreateRow(rowNum);
            row.RowStyle = GetDefaultRowStyle();
            return row;
        }

        internal void SetCellValue(ICell cell, object value)
        {
            if (value == null)
                return;
            if (value is DateTime)
            {
                cell.SetCellValue((DateTime)value);
                if (ThaiDateStyle == null)
                {
                    ThaiDateStyle = Workbook.CreateCellStyle();
                    ThaiDateStyle.DataFormat = Workbook.CreateDataFormat().GetFormat("[$-1070000]d.mm.yyyy;@");
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
                }

                cell.CellStyle = ThaiDateStyle;
            }
            else if (value is int)
            {
                cell.SetCellValue((int)value);
            }
            else if (value is bool)
            {
                cell.SetCellValue((bool)value);
            }
            else
                cell.SetCellValue(value.ToString());

        }


    }
}
