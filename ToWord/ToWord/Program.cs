using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;


namespace ToWord
{
    class Program
    {
        static void Main(string[] args)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "//endofdoc";
            Microsoft.Office.Interop.Word.Application oWord;
            Microsoft.Office.Interop.Word.Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            //插入表格

            WdLineStyle OutStyle = WdLineStyle.wdLineStyleThickThinLargeGap;
            WdLineStyle InStyle = WdLineStyle.wdLineStyleSingle;

            //Paragraph p = "hello word";
            AddTable.AddSimpleTable(oWord, oDoc, 12, 3, OutStyle, InStyle);
            oDoc.SaveAs2(@"d:\a.doc");
        }
    }

    class AddTable
    {
        public static void  AddSimpleTable(Application WordApp, Document WordDoc, int numrows, int numcolumns, WdLineStyle outStyle, WdLineStyle intStyle)
        {
            Object Nothing = System.Reflection.Missing.Value;
            //文档中创建表格

            Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, numrows, numcolumns, ref Nothing,ref Nothing);
            //设置表格样式

            newTable.Borders.OutsideLineStyle = outStyle;
            newTable.Borders.InsideLineStyle = intStyle;
            newTable.Columns[1].Width = 100f;
            newTable.Columns[2].Width = 220f;
            newTable.Columns[3].Width = 105f;

            //填充表格内容

            newTable.Cell(1, 1).Range.Text = "产品详细信息表";
            newTable.Cell(1, 1).Range.Bold = 2;//设置单元格中字体为粗体

            //合并单元格

            newTable.Cell(1, 1).Merge(newTable.Cell(1, 3));
            WordApp.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;//垂直居中

            WordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;//水平居中


            //填充表格内容

            newTable.Cell(2, 1).Range.Text = "产品基本信息";
            newTable.Cell(2, 1).Range.Font.Color = WdColor.wdColorDarkBlue;//设置单元格内字体颜色

            //合并单元格

            newTable.Cell(2, 1).Merge(newTable.Cell(2, 3));
            WordApp.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            //填充表格内容

            newTable.Cell(3, 1).Range.Text = "品牌名称：";
            newTable.Cell(3, 2).Range.Text = "品牌名称：";
            //纵向合并单元格

            newTable.Cell(3, 3).Select();//选中一行

            object moveUnit = WdUnits.wdLine;
            object moveCount = 5;
            object  moveExtend = WdMovementType.wdExtend;
            WordApp.Selection.MoveDown(ref moveUnit,ref moveCount,ref moveExtend);
            WordApp.Selection.Cells.Merge();


            //插入图片

            string  FileName = @"C:/1.jpg" ;
            //图片所在路径

            object  Anchor = WordDoc.Application.Selection.Range;
            float  Width = 200f;
            //图片宽度

            float  Height = 200f;
            //图片高度


            //将图片设置为四周环绕型

            WdWrapType wdWrapType = Microsoft.Office.Interop.Word.WdWrapType.wdWrapSquare;
            //AddPic.AddSimplePic(WordDoc, FileName, Width, Height, Anchor, wdWrapType);  

            newTable.Cell(12, 1).Range.Text = "产品特殊属性" ;
            newTable.Cell(12, 1).Merge(newTable.Cell(12, 3));
            //在表格中增加行

            WordDoc.Content.Tables[1].Rows.Add(ref Nothing);
        }


    }
}  





   
 



