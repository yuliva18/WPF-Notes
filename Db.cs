using Microsoft.Data.Sqlite;
using Notes.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using static System.Net.Mime.MediaTypeNames;

namespace Notes
{
    internal class Db
    {
        FlowDocumentToStringConverter converter = new FlowDocumentToStringConverter();
        SqliteConnection connection;
        public Db() {
            string connectionString = "Data Source=notes.db";
            connection = new SqliteConnection(connectionString);
            connection.Open();
        }

        public void CreateTableIfNotExist()
        {
            string sql = "CREATE TABLE IF NOT EXISTS Note (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT, Body TEXT, Date DATETIME DEFAULT (Datetime('now','localtime')) NOT NULL);";
            new SqliteCommand(sql, connection).ExecuteNonQuery();
        }

        public ObservableCollection<Note> SelectAll()
        {
            string sql = "SELECT * FROM Note;";
            SqliteDataReader reader = new SqliteCommand(sql, connection).ExecuteReader();
            ObservableCollection<Note> notes = new ObservableCollection<Note>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Int64 id = (Int64)reader.GetValue(0);
                    FlowDocument? title = RtfToFD(reader.GetString(1));
                    FlowDocument? body = RtfToFD(reader.GetString(2));
                    string date = reader.GetString(3);
                    notes.Add(new Note(id, title, body, date));
                }
                return notes;
            }
            else
            {
                InsertNote();
                return SelectAll();
            }
        }

        private String FDToRtf(FlowDocument document)
        {
            TextRange docrange = new TextRange(document.ContentStart, document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            docrange.Save(stream, DataFormats.Rtf);
            stream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private FlowDocument RtfToFD(String s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            MemoryStream stream = new MemoryStream(bytes);
            FlowDocument? res = new FlowDocument();
            TextRange range = new TextRange(res.ContentStart, res.ContentEnd);
            range.Load(stream, DataFormats.Rtf);
            return res;
        }

        public int InsertNote(String title = "Новая заметка", String body = "Напишите здесь что-нибудь!")
        {
            FlowDocument titleFD = (FlowDocument)converter.ConvertBack(title, typeof(FlowDocument), null, CultureInfo.CurrentCulture);
            FlowDocument bodyFD = (FlowDocument)converter.ConvertBack(body, typeof(FlowDocument), null, CultureInfo.CurrentCulture);
            titleFD.FontSize = 16;
            bodyFD.FontSize = 14;
            string sql1 = String.Format("INSERT INTO Note(Title, Body) VALUES ('{0}', '{1}');", FDToRtf(titleFD), FDToRtf(bodyFD));
            return new SqliteCommand(sql1, connection).ExecuteNonQuery();
        }

        public int UpdateNote(Note note)
        {
            FlowDocument title = note.Title;
            FlowDocument body = note.Body;
            string sql = String.Format("UPDATE Note SET Title = '{0}', Body = '{1}' WHERE Id = {2}", FDToRtf(title), FDToRtf(body), note.Id);
            return new SqliteCommand(sql, connection).ExecuteNonQuery();
        }

        public int DeleteNote(Note note)
        {
            string sql = String.Format("DELETE FROM Note WHERE Id = {0}", note.Id);
            return new SqliteCommand(sql, connection).ExecuteNonQuery();
        }
    }
}
