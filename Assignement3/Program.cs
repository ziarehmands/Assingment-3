using System;
using System.Xml;
using Newtonsoft.Json;

// Database model with XML attribute
public class DatabaseModel
{
    public string XmlData { get; set; }
    public DatabaseModel() { 
        XmlData = string.Empty;
    }
    public DatabaseModel(string xmlData)
    {
        XmlData = xmlData;
    }
}

// Adapter to convert XML to JSON
public class XmlToJsonAdapter
{
    private DatabaseModel _databaseModel;

    public XmlToJsonAdapter(DatabaseModel databaseModel)
    {
        _databaseModel = databaseModel;
    }

    public string ConvertXmlToJson()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(_databaseModel.XmlData);
        string jsonText = JsonConvert.SerializeXmlNode(doc);

        return jsonText;
        //return _databaseModel.XmlData;
    }
}

// Display service using Singleton pattern
public class DisplayService
{
    private static DisplayService _instance;

    private DisplayService()
    { }

    public static DisplayService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DisplayService();
            }
            return _instance;
        }
    }

    public void PrintData(string data)
    {
        Console.WriteLine($"Printing JSON data {data}");
    }
}

class Program
{
    static void Main()
    {
        
        string XmlData = "<root><name>John</name><age>30</age></root>";
        DatabaseModel databaseModel = new DatabaseModel(XmlData);
        XmlToJsonAdapter xmltojsonadapter = new XmlToJsonAdapter(databaseModel);

        string jsondata = xmltojsonadapter.ConvertXmlToJson();

        DisplayService displayService = DisplayService.Instance;
        displayService.PrintData(jsondata);

    }
}
