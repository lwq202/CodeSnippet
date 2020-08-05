
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using Spire.Pdf;

namespace PdfToImage
{

    public class PointComparer : IComparer<RectangleF>
    {
        public int Compare([AllowNull] RectangleF x, [AllowNull] RectangleF y)
        {
            var height = Math.Abs(x.Y - y.Y);//获取高度差
            //高度差在20以内，就相当于同一排
            if (height < 100)
            {
                return (int)((x.X) - (y.X));
            }
            return (int)((x.Y) - (y.Y));
            //return (int)((y.Y * 1 + y.Y)-(x.Y * 1 + x.X));
        }
    }

    
    class Program
    {
        /// <summary>
        /// 从pdf中导出图片
        /// </summary>
        /// <param name="pdfFilePath"></param>
        /// <param name="outDir"></param>
        public static void DealPdf(string pdfFilePath,string outDir)
        {
            //加载PDF文档
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(pdfFilePath);
            FileInfo file=new FileInfo(pdfFilePath);
            if (!file.Exists)
            {
                Console.WriteLine($"pdf文件不存在");
            }

            string path = Path.Combine(outDir, file.Name.Replace(".pdf", ""));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                Console.WriteLine($"处理第{i+1}页面图片");
                // 实例化一个Spire.Pdf.PdfPageBase对象
                PdfPageBase page = doc.Pages[i];
                var texts = page.FindAllText().Finds.Where(a =>
                        (a.Size.Height >= 9&&a.Size.Height<=10))
                    .OrderBy(a => a.Bounds, new PointComparer()).ToList();
                if (!texts.Any())
                {
                    texts = page.FindAllText().Finds.Where(a =>
                            (a.Size.Height >= 6 && a.Size.Height <= 7))
                        .OrderBy(a => a.Bounds, new PointComparer()).ToList();
                }
                var images = page.ImagesInfo.Where(a => a.Bounds.Size.Width < 300)
                    .OrderBy(a => a.Bounds, new PointComparer()).ToList();
                for (int j = 0; j < texts.Count; j++)
                {
                    try
                    {
                        images[j].Image.Save(Path.Combine(path, $"{i + 1}_{j + 1}_{texts[j].MatchText ?? texts[j].SearchText}.jpg"));
                    }
                    catch (Exception e)
                    {
                        
                    }
                    
                }
                //// 获取所有pages里面的图片
                //Image[] images = page.ExtractImages();
                //if (images != null && images.Length > 0)
                //{
                //    listImages.AddRange(images);
                //}

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入PDF文件目录：");
            string pdfDir = Console.ReadLine();

            Console.WriteLine("请输入导出目录：");
            string outDir = Console.ReadLine();
            DirectoryInfo directory=new DirectoryInfo(pdfDir);
            var files=directory.GetFiles("*.pdf", SearchOption.AllDirectories);
            foreach (var fileInfo in files)
            {
                try
                {
                    Console.WriteLine($"开始处理文件{fileInfo.Name}");
                    DealPdf(fileInfo.FullName, outDir);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                
            }
            //string path = "1 HW CL.pdf";
            //DealPdf(path,"output");
            //Console.ReadLine();
        }

        private static void ExtractImage(string pdfFile)

        {

            //PdfReader pdfReader = new PdfReader(pdfFile);
            //PdfDocument pdfDoc = new PdfDocument(pdfReader);
            //int numberOfPdfObjects = pdfDoc.GetNumberOfPdfObjects();
            //for (int pageNumber = 1; pageNumber <= numberOfPdfObjects; pageNumber++)

            //{


            //    PdfObject pdfObject = pdfDoc.GetPdfObject(pageNumber);
            //    if (pdfObject == null || !pdfObject.IsStream())
            //    {
            //        continue;
            //    }
            //    Console.WriteLine($"获取第{pageNumber}页数据,是否是文本{pdfObject.IsString()}");
            //    Console.WriteLine(pdfObject.ToString());
            //    //var dictionary = (PdfDictionary)pdfObject;
            //    //PdfObject type = dictionary.Get(PdfName.Type);
            //    //PdfObject subType = dictionary.Get(PdfName.Subtype);
            //    //PdfObject filter = dictionary.Get(PdfName.Filter);
            //    //PdfObject color = dictionary.Get(PdfName.Color);
            //    //if (PdfName.XObject.Equals(type))
            //    //{
            //    //    if (PdfName.XObject.Equals(type)
            //    //        && PdfName.Image.Equals(subType)
            //    //    )
            //    //    {
            //    //        if (PdfName.JPXDecode.Equals(filter))
            //    //        {
            //    //            string fileName = String.Format($"output\\test_{pageNumber}.jpg", pageNumber);
            //    //            ExportJpg2000FromPDF(dictionary, fileName);
            //    //        }
            //    //        else
            //    //        {
            //    //            string fileName = String.Format($"output\\test_{pageNumber}.jpg", pageNumber);
            //    //            ExportJpgFromPDF(dictionary, fileName);
            //    //            //if (filter is PdfArray)
            //    //            //{
            //    //            //    var filtes = (PdfArray)filter;
            //    //            //    if (filtes.Contains(PdfName.DCTDecode))
            //    //            //    {

            //    //            //    }
            //    //            //}
            //    //        }
            //    //    }
            //    //    else
            //    //    {

            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    var info=  ((PdfStream)pdfObject).GetBytes();
            //    //}
                

            //    #region old

            //    //PdfDictionary res = (PdfDictionary)(dictionary.Get(PdfName.Image));

            //    //PdfDictionary xobj = (PdfDictionary)(res.Get(PdfName.XObject));
            //    //var path = "output";
            //    //if (!Directory.Exists(path))
            //    //{
            //    //    Directory.CreateDirectory(path);
            //    //}
            //    //try

            //    //{
            //    //    var num = 1;
            //    //    Console.WriteLine($"一共获取了{xobj.Values().Count}个对象");
            //    //    foreach (PdfObject obj in xobj.Values())

            //    //    {


            //    //        if (obj.IsIndirect())
            //    //        {

            //    //            PdfDictionary tg = (PdfDictionary)obj;
            //    //            //PdfImage
            //    //            //var image= (PdfImageXObject) ;
            //    //            ////string width = tg.Get(PdfName.LENGTH).ToString();

            //    //            ////string height = tg.Get(PdfName.HEIGHT).ToString();
            //    //            //ImageRenderInfo info=new ImageRenderInfo();
            //    //            ////ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject((GraphicsState)new Matrix(float.Parse(width), float.Parse(height)), (PRIndirectReference)obj, tg);
            //    //            //var state = new GraphicsState();
            //    //            //ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject(state, (PRIndirectReference)obj, tg);

            //    //            ////RenderImage(imgRI);
            //    //            //var ctm= imgRI.GetImageCTM();
            //    //            //var color= imgRI.GetCurrentFillColor();
            //    //            //PdfImageObject image = imgRI.GetImage();

            //    //            //Image.GetInstance();
            //    //            //var dotnetImg = image.GetImageAsBytes();
            //    //            //if (dotnetImg != null)

            //    //            //{
            //    //            //    var filePath = $"{path}\\{pageNumber}_{num++}.png";
            //    //            //    using (FileStream file = new FileStream(filePath, FileMode.Create))
            //    //            //    {

            //    //            //        file.Write(dotnetImg);
            //    //            //        file.Flush();
            //    //            //    }


            //    //            //}



            //    //        }

            //    //    }

            //    //}
            //    //catch

            //    //{

            //    //    continue;

            //    //}

            //    #endregion
            //}

            
        }
    }
}
