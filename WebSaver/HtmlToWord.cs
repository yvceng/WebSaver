using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace WebSaver
{
    class HtmlToWord
    {
        String szHtml;
        _Application app;
        _Document doc;
        object missing = Type.Missing;
        public string title = "";
        String cont = "";
        public HtmlToWord()
        {
            app = new Word.Application();
            doc = null;
        }
        //析构函数
         ~HtmlToWord()
        {
            //app.Quit();
        }

        public void SetHtml(String htmlText)
        {
            szHtml = htmlText;
            title = getHtmlTitle();
            cont = getHtmlText();
        }
        string getHtmlText()
        {
            string cont = "";
            Regex reg_p = new Regex(@"(?<=<p class.*>)(.*?)(?=</p>)", RegexOptions.IgnoreCase);//[^(<p>))] 
            MatchCollection mc_p = reg_p.Matches(szHtml);

            string onespan="";
            foreach (Group p in mc_p)
            {
                Regex reg_span = new Regex(@"(?<=<span.*>)(.*?)(?=</span>)", RegexOptions.IgnoreCase);//[^(<span>))] 
                MatchCollection mc_span = reg_span.Matches(p.Value);

                int spancount = 0;
                foreach (Group span in mc_p)
                {
                    onespan = Regex.Replace(span.Value, "<.*?>|&nbsp;|\\s", "");//去除标签、空格等
                    if (!"".Equals(onespan))
                    {
                        cont += onespan;
                        spancount++;
                    }
                }
                if(spancount>0) cont += "\n";  //空行则跳过
            }
            return cont;
        }
        string getHtmlTitle()
        {
            string cont = "";
            //查找<h1>标题</h1>
            Regex reg = new Regex(@"(?<=<h1.*>)(.*?)(?=</h1>)", RegexOptions.IgnoreCase);//[^(<td>))]
            MatchCollection mc = reg.Matches(szHtml);
            cont += Regex.Replace(mc[0].Value, "<.*?>|&nbsp;|\\s", "");

            return cont;
        }
        public void MakeDoc()
        {
            doc.Paragraphs.Last.Range.Font.Name = "仿宋_GB2312";
            doc.Paragraphs.Last.Range.Font.Size = float.Parse("15");
            doc.Paragraphs.Last.Range.ParagraphFormat.SpaceBeforeAuto = 0;
            doc.Paragraphs.Last.Range.ParagraphFormat.SpaceBefore=float.Parse("0");//段前间距
            doc.Paragraphs.Last.Range.ParagraphFormat.SpaceAfterAuto = 0;
            doc.Paragraphs.Last.Range.ParagraphFormat.SpaceAfter = float.Parse("0");//段后间距
            doc.Paragraphs.Last.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceExactly;//固定行距
            doc.Paragraphs.Last.Range.ParagraphFormat.LineSpacing = float.Parse("28");//段后间距
            doc.Paragraphs.Last.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;

            doc.Paragraphs.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            doc.Paragraphs.Last.Range.Text = title+"\n";//将文字添加到word
            doc.Paragraphs.Last.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            doc.Paragraphs.Last.Range.Text = cont;//将文字添加到word
        }
        public void SaveToFile(String fileName)
        {
            string text = "";
            //doc = app.Documents.Open(fileName, missing, missing, missing, missing, missing,missing, missing, missing, missing, missing, missing, missing, missing, missing);
            doc = app.Documents.Add(missing, missing, missing);
            MakeDoc();
            Object fileFormat = Type.Missing;
            Object lockComments = Type.Missing;
            Object password = Type.Missing;
            Object addToRecentFiles = Type.Missing;
            Object writePassword = Type.Missing;
            Object readOnlyRecommended = Type.Missing;
            Object embedTrueTypeFonts = Type.Missing;
            Object saveNativePictureFormat = Type.Missing;
            Object saveFormsData = Type.Missing;
            Object saveAsAOCELetter = Type.Missing;
            Object encoding = Type.Missing;
            Object insertLineBreaks = Type.Missing;
            Object allowSubstitutions = Type.Missing;
            Object lineEnding = Type.Missing;
            Object addBiDiMarks = Type.Missing;

            doc.SaveAs(fileName, ref fileFormat, ref lockComments,
              ref password, ref addToRecentFiles, ref writePassword,
              ref readOnlyRecommended, ref embedTrueTypeFonts,
              ref saveNativePictureFormat, ref saveFormsData,
              ref saveAsAOCELetter, ref encoding, ref insertLineBreaks,
              ref allowSubstitutions, ref lineEnding, ref addBiDiMarks);
            app.NormalTemplate.Saved = true;
            doc.Close();
        }
    }
}
