using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TemplateEngine
{
    public class TemplateEngine
    {
        private string _template;
        private readonly Dictionary<string, string> _values = new Dictionary<string, string>();

        public void SetTemplate(string template)
        {
            _template = template;
        }

        public void SetName(string key, string value)
        {
            _values[key] = value;
        }

        public string Render()
        {
            string result = _template;
            foreach (var pair in _values)
            {
                result = Regex.Replace(result, $"{{{{{pair.Key}}}}}", pair.Value);
            }
            return result;
        }
    }
}

