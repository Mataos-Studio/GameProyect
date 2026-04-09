using System;
using System.Collections.Generic;
using System.IO;

public class TextManager
{
    const char CSV_CELLS_SEPARATOR = ';';
    const string CODE_COLUMN_NAME = "key";
    const string NEXT_COLUMN_NAME = "next";

    int codeColumnPos = -1;
    int nextColumnPos = -1;

    readonly Dictionary<string, int> languages = new();
    string filePath;
    public string FilePath
    {
        get => filePath;
        set {
            filePath = value;
            LoadFile();
        }
    }

    string language;
    string Language
    {
        get => language;
        set
        {
            if (!languages.ContainsKey(value))
            {
                throw new TextManagerException($"There is no {value} language stored. Avaliable languages: {string.Join(", ", languages.Keys)}");
            }

            language = value;
        }
    }

    public TextManager(string filePath, string language)
    {
        FilePath = filePath;
        Language = language;
    }

    void LoadFile()
    {
        languages.Clear();
        nextColumnPos = codeColumnPos = -1;

        if (!File.Exists(FilePath))
        {
            throw new TextManagerException($"The file does not exists: {FilePath}");
        }

        if (FilePath.EndsWith("csv"))
        {
            throw new TextManagerException($"The file is not an csv file: {FilePath}");
        }

        var reader = new StreamReader(FilePath);

        var headers = reader.ReadLine().Split(CSV_CELLS_SEPARATOR);

        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i] == CODE_COLUMN_NAME)
            {
                codeColumnPos = i;
            } else if (headers[i] == NEXT_COLUMN_NAME)
            {
                nextColumnPos = i;
            } else
            {
                languages.Add(headers[i], i);
            }
        }

        if (codeColumnPos == -1 || nextColumnPos == -1)
        {
            throw new TextManagerException($"The code cannot find key columns on the csv file: Necessary columns: [{CODE_COLUMN_NAME}, {NEXT_COLUMN_NAME}]. Columns found on the file: {string.Join(", ", headers)}. File: {FilePath}");
        }

        reader.Close();
    }

    public TextChunk? Retrieve(string key)
    {
        var stream = new StreamReader(FilePath);

        string line;

        stream.ReadLine(); //skip headers

        while((line = stream.ReadLine()) != null)
        {
            var cells = line.Split(CSV_CELLS_SEPARATOR);
            if (cells[codeColumnPos] == key)
            {
                return new TextChunk(this, key, cells[languages[Language]], cells[nextColumnPos]);
            }
        }

        return null;
    }

    public class TextManagerException : Exception
    {
        public TextManagerException() : base() {}
        public TextManagerException(string message) : base(message) {}
    }
}