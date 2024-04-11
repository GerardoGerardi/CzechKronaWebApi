using System;
using System.IO;
using System.Xml;

namespace Common;

public class FileLogger
{
    private string _fileName;

    public FileLogger()
    {
        _fileName = "log.log";
    }

    public void Write(string message)
    {
        using(var sw=new StreamWriter(_fileName,true))
            sw.WriteLine($"{DateTime.Now}:{message}");
    }
}