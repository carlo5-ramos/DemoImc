using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DemoIMC.Respaldo
{
    public class Backup
    {
        public void BackupDatabase()
        {
            var sqliteFilename = "db_imc.db";


            string SourcedocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            SourcedocumentsPath = Path.Combine(SourcedocumentsPath, sqliteFilename);

            string DestinationdocumentsPath = "";
            try
            {
                if (File.Exists(SourcedocumentsPath))// Source DB File exist to copy
                {
                    DestinationdocumentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(
                        Android.OS.Environment.DirectoryDownloads).ToString();
                    if (Directory.Exists(DestinationdocumentsPath))
                    // Create the connection
                    {
                        DestinationdocumentsPath += "/Demoimc/";

                        if (!Directory.Exists(DestinationdocumentsPath)) Directory.CreateDirectory(DestinationdocumentsPath);
                        if (Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db")).ToList() != null)
                        {
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                                File.Delete(DBBkpPath);
                            }
                        }
                        // DestinationdocumentsPath = Path.Combine(DestinationdocumentsPath, sqliteFilename);
                        if (!File.Exists(Path.Combine(DestinationdocumentsPath, sqliteFilename)))
                        {
                            List<string> PrevBack = Directory.GetFiles(SourcedocumentsPath).Where(x => x.Contains(".db")).ToList();
                            foreach (string DBBkpPath in PrevBack)
                            {
                                File.Copy(SourcedocumentsPath, Path.Combine(DestinationdocumentsPath, DBBkpPath), true);
                            }
                           // System.IO.File.Copy(SourcedocumentsPath, Path.Combine(DestinationdocumentsPath, sqliteFilename), true);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("mensaje", ex);
            }
        }

        public void Traer()
        {
            var sqliteFilename = "db_imc.db";
            var Sqlsource = "Demoimc/db_imc.db";



            string SourcedocumentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(
                        Android.OS.Environment.DirectoryDownloads).ToString();
            SourcedocumentsPath = Path.Combine(SourcedocumentsPath, Sqlsource);

            string DestinationdocumentsPath = "";
            try
            {
                if (File.Exists(SourcedocumentsPath))// Source DB File exist to copy
                {
                    DestinationdocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                    if (Directory.Exists(DestinationdocumentsPath))
                    // Create the connection
                    {
                        DestinationdocumentsPath += "";

                        if (!Directory.Exists(DestinationdocumentsPath)) Directory.CreateDirectory(DestinationdocumentsPath);
                        if (Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db")).ToList() != null)
                        {
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                                File.Delete(DBBkpPath);
                            }
                        }
                        // DestinationdocumentsPath = Path.Combine(DestinationdocumentsPath, sqliteFilename);
                        if (!File.Exists(Path.Combine(DestinationdocumentsPath, sqliteFilename)))
                        {
                            var enlace = Path.Combine(DestinationdocumentsPath, sqliteFilename);
                            //System.IO.File.Copy(SourcedocumentsPath, enlace, true);
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                               System.IO.File.Copy(SourcedocumentsPath, enlace, true);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("mensaje", ex);
            }
        }

    }
}
