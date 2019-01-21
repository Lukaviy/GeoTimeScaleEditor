using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoJsonEditor.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoJsonEditor.IO
{
    class JsonImporter
    {
        public static TimeLine Import(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }

            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<TimeLine>(json);
        }
    }
}
