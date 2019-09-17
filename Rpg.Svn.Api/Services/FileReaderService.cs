using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Rpg.Svn.Api.Services
{
    public static class FileReaderService
    {
        private const string JSON_EXT = ".json";

        /// <summary>
        /// Reads a Json file into <typeparamref name="T"/> class
        /// </summary>
        /// <typeparam name="T">Type to deserialize into</typeparam>
        /// <param name="path">Path to the .json file</param>
        /// <returns></returns>
        public static T ReadJson<T>(string path)
        {
            if (!path.EndsWith(JSON_EXT))
            {
                throw new FormatException("File must end with .json extension.");
            }

            T obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(path, Encoding.UTF8));

            return obj;
        }
    }
}
