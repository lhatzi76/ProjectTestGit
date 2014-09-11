using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace eDoc_Operations
{
    class FileOperations
    {
        //These contants are passed to the OpenSqlFilestream()
        //API DesiredAccess parameter. They define the type
        //of BLOB access that is needed by the application.
        const UInt32 DESIRED_ACCESS_READ = 0x00000000;
        const UInt32 DESIRED_ACCESS_WRITE = 0x00000001;
        const UInt32 DESIRED_ACCESS_READWRITE = 0x00000002;

        //These contants are passed to the OpenSqlFilestream()
        //API OpenOptions parameter. They allow you to specify
        //how the application will access the FILESTREAM BLOB
        //data. If you do not want this ability, you can pass in
        //the value 0. In this code sample, the value 0 has
        //been defined as SQL_FILESTREAM_OPEN_NO_FLAGS.
        const UInt32 SQL_FILESTREAM_OPEN_NO_FLAGS = 0x00000000;
        const UInt32 SQL_FILESTREAM_OPEN_FLAG_ASYNC = 0x00000001;
        const UInt32 SQL_FILESTREAM_OPEN_FLAG_NO_BUFFERING = 0x00000002;
        const UInt32 SQL_FILESTREAM_OPEN_FLAG_NO_WRITE_THROUGH = 0x00000004;
        const UInt32 SQL_FILESTREAM_OPEN_FLAG_SEQUENTIAL_SCAN = 0x00000008;
        const UInt32 SQL_FILESTREAM_OPEN_FLAG_RANDOM_ACCESS = 0x00000010;

        //This structure defines the format of the final parameter to the
        //OpenSqlFilestream() API.

        //This statement imports the OpenSqlFilestream API so that it
        //can be called in the Main() method below.
        //[DllImport("sqlncli10.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        //static extern SafeFileHandle OpenSqlFilestream(
        //            string Filestreamath,
        //            uint DesiredAccess,
        //            uint OpenOptions,
        //            byte[] FilestreamTransactionContext,
        //            uint FilestreamTransactionContextLength,
        //            Int64 AllocationSize);
        [DllImport("sqlncli10.dll", SetLastError = true, CharSet = CharSet.Unicode)]
	    private static extern SafeFileHandle OpenSqlFilestream(
	      string path,
	      uint access,
	      uint options,
	      byte[] txnToken,
	      uint txnTokenLength,
          Int32 allocationSize);
        //[DllImport("sqlncli10.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        //private extern static IntPtr OpenSqlFilestream(
        //    string path,
        //    int access,
        //    int openOptions,
        //    byte[] txnContext,
        //    int contextLength,
        //    ref int allocationSize);

        //This statement imports the Win32 API GetLastError().
        //This is necessary to check whether OpenSqlFilestream
        //succeeded in returning a valid / handle

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern UInt32 GetLastError();

        public static void UploadFile(String strFileName)
        {
            // Establish db connection
            SqlConnection  sqlConnection = GetConnection();
            SqlTransaction transaction = null;
            SqlCommand     sqlCommand  = null;
            SqlCommand     sqlCommand2 = null;

            // Create a File Info object so you can easily get the
            // name and extenstion. As an alternative you could
            // choose to pass them in,  or use some other way
            // to extract the extension and name. 
            FileInfo fi = new FileInfo(strFileName);

            try
            {

                // Open the file as a stream
                FileStream sourceFile = new FileStream(strFileName, FileMode.Open, FileAccess.Read);

                // Create the row in the database
                sqlConnection.Open();

                transaction = sqlConnection.BeginTransaction();
                sqlCommand = new SqlCommand("dbo.myFileUpload", sqlConnection, transaction);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FullPathName", strFileName);
                sqlCommand.Parameters.AddWithValue("@FileName", fi.Name);
                sqlCommand.Parameters.AddWithValue("@DocExtension", fi.Extension);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                sqlDataReader.Read();
                String id = sqlDataReader.GetSqlGuid(sqlDataReader.GetOrdinal("SYS_ID")).ToString();
                String path = sqlDataReader.GetString(sqlDataReader.GetOrdinal("PATH_NAME"));
                sqlDataReader.Close();

                // Now upload the file. It must be done inside a transaction.
                //transaction = sqlConnection.BeginTransaction("mainTranaction");
                sqlCommand2 = new SqlCommand();
                sqlCommand2.Connection = sqlConnection;
                sqlCommand2.Transaction = transaction;
                sqlCommand2.CommandText = "SELECT GET_FILESTREAM_TRANSACTION_CONTEXT() "
                 + "FROM dbo.DOC_REPOSITORY "
                 + "WHERE SYS_ID = '" + id + "' ";
                SqlDataReader rdr = sqlCommand2.ExecuteReader();
                if (!rdr.Read())
                {
                    throw new Exception("Could not get file stream context");
                }

                // Get a file stream context
                byte[] context = (byte[])rdr[0];
                int length = context.Length;
                rdr.Close();

                // Now use the API to get a reference (handle) to the filestream
                SafeFileHandle handle = OpenSqlFilestream(path
                  , DESIRED_ACCESS_WRITE
                  , SQL_FILESTREAM_OPEN_NO_FLAGS
                  , context, (UInt32)length, 0);

                // Now create a true .Net filestream to the database
                // using the handle we got in the step above
                FileStream dbStream = new FileStream(handle, FileAccess.Write);

                // Setup a buffer to hold the data we read from disk
                int blocksize = 1024 * 512;
                byte[] buffer = new byte[blocksize];

                // Read from file and write to DB
                int bytesRead = sourceFile.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    dbStream.Write(buffer, 0, buffer.Length);
                    bytesRead = sourceFile.Read(buffer, 0, buffer.Length);
                }

                // Done reading, close all of our streams and commit the file
                dbStream.Close();
                sourceFile.Close();
                transaction.Commit();

            }
            catch (System.IO.IOException exIO)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                Logger m_Logger = new Logger();
                m_Logger.AddLogMessage(exIO.Message);
            }
            catch (Exception e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                Logger m_Logger = new Logger();
                m_Logger.AddLogMessage(e.Message);
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        //// Get a file stored in our database and save it to disk
        //public static void GetFile(int ID, String outputPath)
        //{
        //    // Setup database connection
        //    SqlConnection sqlConnection = GetConnection();

        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Connection = sqlConnection;

        //    try
        //    {
        //        sqlConnection.Open();

        //        // Everything we do with FILESTREAM must always be in 
        //        // the context of a transaction, so we'll start with 
        //        // creating one.
        //        SqlTransaction transaction
        //          = sqlConnection.BeginTransaction("mainTranaction");
        //        sqlCommand.Transaction = transaction;

        //        // The SQL gives us 3 values. First the PathName() method of 
        //        // the Document field is called, we'll need it to use the API
        //        // Second we call a special function that will tell us what
        //        // the context is for the current transaction, in this case 
        //        // the "mainTransaction" we started above. Finally it gives
        //        // the name of the document, which the app will use when it
        //        // creates the document but is not strictly required as 
        //        // part of the FILESTREAM.
        //        sqlCommand.CommandText
        //          = "SELECT Document.PathName()"
        //          + ", GET_FILESTREAM_TRANSACTION_CONTEXT() "
        //          + ", DOC_NAME "
        //          + "FROM dbo.DOC_REPOSITORY "
        //          + "WHERE ID=@theID ";

        //        sqlCommand.Parameters.Add(
        //          "@theID", SqlDbType.Int).Value = ID;

        //        SqlDataReader reader = sqlCommand.ExecuteReader();
        //        if (reader.Read() == false)
        //        {
        //            throw new Exception("Unable to get BLOB data");
        //        }

        //        // OK we have some data, pull it out of the reader into locals
        //        String path = (String)reader[0];
        //        byte[] context = (byte[])reader[1];
        //        String outputFilename = (String)reader[2];
        //        int length = context.Length;
        //        reader.Close();

        //        // Now we need to use the API we declared at the top of this class
        //        // in order to get a handle. 
        //        SafeFileHandle handle = OpenSqlFilestream(
        //          path
        //          , DESIRED_ACCESS_READ
        //          , SQL_FILESTREAM_OPEN_NO_FLAGS
        //          , context
        //          , (UInt32)length, 0);

        //        // Using the handle we just got, we can open up a stream from 
        //        // the database.
        //        FileStream databaseStream = new FileStream(
        //          handle, FileAccess.Read);

        //        // This file stream will be used to copy the data to disk
        //        FileStream outputStream
        //          = File.Create(outputPath + outputFilename);

        //        // Setup a buffer to hold the streamed data
        //        int blockSize = 1024 * 512;
        //        byte[] buffer = new byte[blockSize];

        //        // There are two ways we could get the data. The simplest way
        //        // is to read the data, then immediately feed it to the output
        //        // stream using it's Write feature (shown below, commented out.
        //        // The second way is to load the data into an array of bytes
        //        // (here implemented using the generic LIST). This would let
        //        // you manipulate the data in memory, then write it out (as
        //        // shown here), reupload it to another data stream, or do
        //        // something else entirely. 
        //        // If you want to go the simple way, just remove all the
        //        // fileBytes lines and uncomment the outputStream line.
        //        List<byte> fileBytes = new List<byte>();
        //        int bytesRead = databaseStream.Read(buffer, 0, buffer.Length);
        //        while (bytesRead > 0)
        //        {
        //            bytesRead = databaseStream.Read(buffer, 0, buffer.Length);
        //            //outputStream.Write(buffer, 0, buffer.Length);
        //            foreach (byte b in buffer)
        //                fileBytes.Add(b);
        //        }

        //        // Write out what is in the LIST to disk
        //        foreach (byte b in fileBytes)
        //        {
        //            byte[] barr = new byte[1];
        //            barr[0] = b;
        //            outputStream.Write(barr, 0, 1);
        //        }

        //        // Close the stream from the databaseStream
        //        databaseStream.Close();

        //        // Write out the file
        //        outputStream.Close();

        //        // Finally we should commit the transaction. 
        //        sqlCommand.Transaction.Commit();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //    return;

        //}

        protected static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection(
                "Integrated Security=true;server=ST211\\SQL2008R2;Initial Catalog=EDOC_TEST");

            return cn;
        }
    }
}
