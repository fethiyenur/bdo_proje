using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace bdo_kod
{
    // İlaç bilgilerini tutan bir sınıf
    public class IlacTedarik
    {
        // İlaç bilgilerini tutan bir iç sınıf
        private class Ilac
        {
            public string Ad { get; set; }
            public int GuncelStok { get; set; }
            public int MinimumStok { get; set; }
        }

        private readonly Dictionary<string, int> ilacMinimumStok = new Dictionary<string, int>
        {
            { "AMİNOFİLİN ENJ.", 10000 },
            { "ANTİHİSTAMİNİK ENJ.", 9000 },
            { "OKSİJENLİ SU", 8000 },
            { "DİAZEPAM TAB.", 11000 },
            { "DİGOKSİN ENJ.", 9500 },
            { "FENOBARBİTAL TAB.", 10200 },
            { "FUROSEMİDE ENJ.", 10400 },
            { "İNSÜLİN KRİSTALİZE ENJ.", 10000 },
            { "İNSÜLİN NPH", 10000 },
            { "İSOSORBİT DİNİTRAT SUBLİNGUAL TAB.", 10700 },
            { "KORTİKOSTEROİD ENJ.", 9000 },
            { "TRİMETOBENZAMİD ENJ", 1000 },
            { "KLONOZEPAM TAB.", 8000 },
            { "KLORPROMAZİN ENJ.", 7500 },
            { "KALSİYUM ENJ.", 8000 },
            { "NİFEDİPİN TAB.", 7500 },
            { "NİTROGLİSERİN TAB./SPREY", 10000 }
            
        };

        private string inputFilePath;
        private string acilStokFilePath;
        private string tedarikFilePath;

        public IlacTedarik(string inputFilePath, string acilStokFilePath, string tedarikFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.acilStokFilePath = acilStokFilePath;
            this.tedarikFilePath = tedarikFilePath;
        }

        public void IlaclariKontrolEt()
        {
            List<Ilac> ilaclar = new List<Ilac>();

            // Dosyadan ilaç stok bilgilerini oku
            foreach (var line in File.ReadLines(inputFilePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string ilacAdi = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int guncelStok))
                    {
                        if (ilacMinimumStok.TryGetValue(ilacAdi, out int minStok))
                        {
                            ilaclar.Add(new Ilac { Ad = ilacAdi, GuncelStok = guncelStok, MinimumStok = minStok });
                        }
                    }
                }
            }

            List<string> acilStokList = new List<string>();
            List<string> tedarikList = new List<string>();

            // İlacları karşılaştır ve listelere ekle
            foreach (var ilac in ilaclar)
            {
                int fark = ilac.MinimumStok - ilac.GuncelStok;
                if (ilac.GuncelStok < ilac.MinimumStok)
                {
                    acilStokList.Add($"{ilac.Ad}, {fark + 100}");
                }
                else if (ilac.GuncelStok == ilac.MinimumStok)
                {
                    tedarikList.Add($"{ilac.Ad}, {fark + 100}");
                }
            }

            // Sonuçları dosyalara yaz
            File.WriteAllLines(acilStokFilePath, acilStokList);
            File.WriteAllLines(tedarikFilePath, tedarikList);
        }
    }
}
