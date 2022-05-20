using System.Diagnostics;
using UnityEngine;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
public class PrintingManager : MonoBehaviour
{
    private string path;
    private void Start()
    {
        path = Application.dataPath + "/Students.pdf";
    }

    public void GenerateFile()
    {
        if (File.Exists(path))
            File.Delete(path);
        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            var writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            document.NewPage();

            var p = new Paragraph("Informacion Estudiantes"); //iSFSObject.GetUtfString("TICKET_ID"
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            string json;
            using (var stream = new StreamReader(JsonManager.instance.PathJson))
            {
                json = stream.ReadToEnd();
                p = new Paragraph(json);
                p.Alignment = Element.ALIGN_CENTER;
                document.Add(p);

                document.Close();
                writer.Close();
            }

            PrintFiles();
        }
        

        void PrintFiles()
        {
            if (path == null)
                return;

            if (!File.Exists(path))
            {
                return;
            }

            var process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = path;

            process.Start();
        }
    }
}