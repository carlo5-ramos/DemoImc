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
            var sqliteFilename = "db_imc.db3";



            string SourcedocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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
                        DestinationdocumentsPath += "/DemoIMC/";
                        // if (!Directory.Exists(Path.Combine(DestinationdocumentsPath, "CompanyName/"))) Directory.CreateDirectory(DestinationdocumentsPath);
                        if (!Directory.Exists(DestinationdocumentsPath)) Directory.CreateDirectory(DestinationdocumentsPath);
                        if (Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db3")).ToList() != null)
                        {
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db3")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                                File.Delete(DBBkpPath);
                            }
                        }
                        // DestinationdocumentsPath = Path.Combine(DestinationdocumentsPath, sqliteFilename);
                        if (!File.Exists(Path.Combine(DestinationdocumentsPath, sqliteFilename)))
                        {
                            //  FileStream readStream = new FileStream(SourcedocumentsPath, FileMode.Open, FileAccess.Read);
                            //FileStream writeStream = new FileStream(DestinationdocumentsPath, FileMode.OpenOrCreate, FileAccess.Write);
                            //FileStream writeStream = new FileStream(Path.Combine(DestinationdocumentsPath, sqliteFilename), FileMode.CreateNew, FileAccess.ReadWrite);

                            //  FileStream writeStream = new FileStream(Path.Combine(DestinationdocumentsPath, sqliteFilename),FileMode.OpenOrCreate, System.Security.AccessControl.FileSystemRights.CreateFiles,FileShare.ReadWrite,1024,FileOptions.None);
                            // write to the stream
                            //  ReadWriteStream(readStream, writeStream);
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db3")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                                File.Copy(SourcedocumentsPath, Path.Combine(DestinationdocumentsPath, DBBkpPath), true);
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

        public void Traer()
        {
            var sqliteFilename = "db_imc.db3";
            var Sqlsource = "DemoIMC/db_imc.db3";
            string prueba = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            prueba = Path.Combine(prueba, sqliteFilename);


            string SourcedocumentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(
                        Android.OS.Environment.DirectoryDownloads).ToString();
            SourcedocumentsPath = Path.Combine(SourcedocumentsPath, Sqlsource);

            string DestinationdocumentsPath = "";
            try
            {
                if (File.Exists(SourcedocumentsPath))// Source DB File exist to copy
                {
                    DestinationdocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    if (Directory.Exists(DestinationdocumentsPath))
                    // Create the connection
                    {
                        DestinationdocumentsPath += "";
                        // if (!Directory.Exists(Path.Combine(DestinationdocumentsPath, "CompanyName/"))) Directory.CreateDirectory(DestinationdocumentsPath);
                        if (!Directory.Exists(DestinationdocumentsPath)) Directory.CreateDirectory(DestinationdocumentsPath);
                        if (Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db3")).ToList() != null)
                        {
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db3")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                                File.Delete(DBBkpPath);
                            }
                        }
                        // DestinationdocumentsPath = Path.Combine(DestinationdocumentsPath, sqliteFilename);
                        if (!File.Exists(Path.Combine(DestinationdocumentsPath, sqliteFilename)))
                        {
                            //  FileStream readStream = new FileStream(SourcedocumentsPath, FileMode.Open, FileAccess.Read);
                            //FileStream writeStream = new FileStream(DestinationdocumentsPath, FileMode.OpenOrCreate, FileAccess.Write);
                            //FileStream writeStream = new FileStream(Path.Combine(DestinationdocumentsPath, sqliteFilename), FileMode.CreateNew, FileAccess.ReadWrite);

                            //  FileStream writeStream = new FileStream(Path.Combine(DestinationdocumentsPath, sqliteFilename),FileMode.OpenOrCreate, System.Security.AccessControl.FileSystemRights.CreateFiles,FileShare.ReadWrite,1024,FileOptions.None);
                            // write to the stream
                            //  ReadWriteStream(readStream, writeStream);
                            List<string> PrevBackupFiles = Directory.GetFiles(DestinationdocumentsPath).Where(x => x.Contains(".db3")).ToList();
                            foreach (string DBBkpPath in PrevBackupFiles)
                            {
                                File.Copy(SourcedocumentsPath, Path.Combine(DestinationdocumentsPath, DBBkpPath), true);
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
