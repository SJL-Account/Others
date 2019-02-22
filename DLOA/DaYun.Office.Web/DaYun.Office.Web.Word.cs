using System.Text;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.XWPF.UserModel;
using System;
using System.Net;
namespace DaYun.Office.Web
{
    public static class Word
    {
        public static StringBuilder Read(string filepath)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream stream = File.OpenRead(filepath))
            {
                XWPFDocument doc = new XWPFDocument(stream);
                foreach (var para in doc.Paragraphs)
                {
                    string text = para.ParagraphText; //获得文本         ...       
                    var runs = para.Runs; 
                    string styleid = para.Style;
                    for (int i = 0; i < runs.Count; i++)
                    {
                        var run = runs[i];
                        text = run.ToString(); //获得run的文本
                    }
                }
            }
            return sb;
        }
        public static bool ConvertUrl2Doc(string Url,string DocPath) {
            return ConvertHtml2Doc(new WebClient().DownloadString(Url),DocPath);
        }

     
        /// <summary>
        /// 将Html文件转化为word
        /// </summary>
        /// <param name="html">html代码，注意：代码中的图片路径必须使用绝对路径，否则图片无法显示,Html代码要全，包含<head></head>节等信息，尤其是编码</param>
        /// <param name="fileName">Doc文件的绝对路径，如：c:\a.doc</param>
        /// <returns></returns>
        public static bool ConvertHtml2Doc(string html, string fileName)
        {
            try
            {


                using (WordprocessingDocument package = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
                {
                    string altChunkId = "AltChunkId" + (DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);

                    MainDocumentPart mainDocPart = package.MainDocumentPart;
                    if (mainDocPart == null)
                    {
                        mainDocPart = package.AddMainDocumentPart();
                    }
                    if (mainDocPart.Document == null)
                    {
                        mainDocPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                    }
                    if (mainDocPart.Document.Body == null)
                    {
                        mainDocPart.Document.AppendChild(new Body());
                        mainDocPart.Document.Body.AppendChild(new Paragraph());
                    }
                    AlternativeFormatImportPart chunk = mainDocPart.AddAlternativeFormatImportPart(
                          AlternativeFormatImportPartType.Html, altChunkId);

                    using (MemoryStream ms = new MemoryStream(UTF8Encoding.Default.GetBytes(html)))
                    {
                        chunk.FeedData(ms);
                    }

                    AltChunk altChunk = new AltChunk();
                    altChunk.Id = altChunkId;

                    // Embed AltChunk after the last paragraph.
                    mainDocPart.Document.Body.InsertAfter(
                        altChunk, mainDocPart.Document.Body.Elements<Paragraph>().Last());

                    package.MainDocumentPart.Document.Save();

                    AssertThatOpenXmlDocumentIsValid(package);
                    return true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static MemoryStream ConvertHtml2DocStream(string html, string fileName)
        {
            try
            {


                using (WordprocessingDocument package = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
                {
                    string altChunkId = "AltChunkId" + (DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);

                    MainDocumentPart mainDocPart = package.MainDocumentPart;
                    if (mainDocPart == null)
                    {
                        mainDocPart = package.AddMainDocumentPart();
                    }
                    if (mainDocPart.Document == null)
                    {
                        mainDocPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                    }
                    if (mainDocPart.Document.Body == null)
                    {
                        mainDocPart.Document.AppendChild(new Body());
                        mainDocPart.Document.Body.AppendChild(new Paragraph());
                    }
                    AlternativeFormatImportPart chunk = mainDocPart.AddAlternativeFormatImportPart(
                          AlternativeFormatImportPartType.Html, altChunkId);

                    using (MemoryStream ms = new MemoryStream(UTF8Encoding.Default.GetBytes(html)))
                    {
                        chunk.FeedData(ms);
                    }

                    AltChunk altChunk = new AltChunk();
                    altChunk.Id = altChunkId;

                    // Embed AltChunk after the last paragraph.
                    mainDocPart.Document.Body.InsertAfter(
                        altChunk, mainDocPart.Document.Body.Elements<Paragraph>().Last());
                  MemoryStream  memoSteam = new MemoryStream();
                    package.MainDocumentPart.Document.Save(memoSteam);

                    AssertThatOpenXmlDocumentIsValid(package);
                    return memoSteam;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       static void AssertThatOpenXmlDocumentIsValid(WordprocessingDocument wpDoc)
        {
            var validator = new OpenXmlValidator(FileFormatVersions.Office2010);
            var errors = validator.Validate(wpDoc);

            if (!errors.GetEnumerator().MoveNext())
                return;
            string errMsg = "不兼容的格式";
            foreach (ValidationErrorInfo error in errors)
            {
                errMsg = System.Environment.NewLine + error.Path.XPath +"("+ error.Description+")";
            }
            throw new Exception(errMsg);
        }
    }
}
