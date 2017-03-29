using System.Data.Entity;
using System.Web;
using System.Web.Caching;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services
{
    public class Settings
    {
        private readonly SiteContext _db;
        private readonly Cache _cache;

        public Settings(SiteContext context)
        {
            _db = context;
            _cache = HttpContext.Current.Cache;
        }

        public string this[string key]
        {
            get
            {
                if (_cache[key] != null)
                    return _cache[key] as string;

                return _db.Settings.Find(key)?.Value;
            }
            set
            {
                var setting = _db.Settings.Find(key);
                if (setting == null)
                {
                    setting = new Setting { Id = key, Value = value };
                    _db.Settings.Add(setting);
                    _db.SaveChanges();
                }
                else
                {
                    setting.Value = value;
                    _db.Entry(setting).State = EntityState.Modified;
                    _db.SaveChanges();
                }

                _cache[key] = setting.Value;
            }
        }
    }
}