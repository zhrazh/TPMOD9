using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace TP_MODUL9_103022400015
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public static string filePath = "covid_config.json";

        public CovidConfig()
        {
            satuan_suhu = "Celsius";
            batas_hari_demam = 14;
            pesan_ditolak = "Maaf, Anda tidak memenuhi syarat untuk masuk.";
            pesan_diterima = "Selamat, Anda memenuhi syarat untuk masuk.";
        }
        public static CovidConfig LoadConfig()
        {
            if (!File.Exists(filePath))
            {
                CovidConfig defaultConfig = new CovidConfig();
                defaultConfig.SaveConfig();
                return defaultConfig;
            }
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }
            public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        public void UbahSatuan()
        {
            if (satuan_suhu == "Celsius")
            {
                satuan_suhu = "Fahrenheit";
            }
            else
            {
                satuan_suhu = "Celsius";
        }
            SaveConfig();
        }
    }
}
