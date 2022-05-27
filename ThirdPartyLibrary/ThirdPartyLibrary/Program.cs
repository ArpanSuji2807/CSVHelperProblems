using System;
using ThirdPartyLibrary;
class program
{
    public static void Main(string[] args)
    {
        CsvHandler handler = new CsvHandler();
        //handler.ImplementationCsv();
        handler.ImplementationJson();
    }
}