using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ViewModel
{
    public class UnityConfigManager
    {
        private static UnityConfigManager _instance = null;
        public static UnityConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnityConfigManager();
                }
                return _instance;
            }
        }

        private UnityConfigManager()
        {
            InitContainer();
        }

        private void InitContainer()
        {
            container = new UnityContainer();
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            configSection.Configure(container, "aopContainer");
        }

        public IUnityContainer container { get; private set; }
    }
}
