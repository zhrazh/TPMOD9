using System;
using TP_MODUL9_103022400015;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.WriteLine("Satuan suhu saat ini: " + config.satuan_suhu);

        // Input suhu
        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " + config.satuan_suhu + ": ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        // Input hari demam
        Console.Write("Berapa hari yang lalu anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;
        bool hariValid = false;

        // Cek suhu
        if (config.satuan_suhu.ToLower() == "celcius")
        {
            suhuValid = (suhu >= 36.5 && suhu <= 37.5);
        }
        else
        {
            suhuValid = (suhu >= 97.7 && suhu <= 99.5);
        }

        // Cek hari
        hariValid = (hari < config.batas_hari_demam);

        // Output
        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Test ubah satuan
        Console.WriteLine("\nMengubah satuan suhu...");
        config.UbahSatuan();
        Console.WriteLine("Satuan suhu sekarang: " + config.satuan_suhu);
    }
}