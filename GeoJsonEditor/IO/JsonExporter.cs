using System.IO;
using GeoJsonEditor.Entities;
using Newtonsoft.Json;

namespace GeoJsonEditor.IO
{
    public class JsonExporter
    {
        public static void Export(TimeLine timelime, string path)
        {
            var json = JsonConvert.SerializeObject(timelime, Formatting.Indented);

            File.WriteAllText(path, json);
        }
    }
}